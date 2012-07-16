using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Goniometer_Controller.Functions;

namespace Goniometer_Controller.Models
{
    public class MeasurementCollection
    {
        private List<MeasurementBase> _values;

        public MeasurementCollection()
        {
            _values = new List<MeasurementBase>();
        }

        #region get/set
        public void Add(MeasurementBase measurement)
        {
            var existing = _values.FirstOrDefault(m => 
                      m.theta == measurement.theta 
                    & m.phi   == measurement.phi
                    & m.key   == measurement.key);

            if (existing != null)
                throw new Exception();

            _values.Add(measurement);
        }

        public void AddRange(IEnumerable<MeasurementBase> measurements)
        {
            foreach (var measurement in measurements)
                Add(measurement);
        }

        public void Remove(MeasurementBase measurement)
        {
            _values.Remove(measurement);
        }

        /// <summary>
        /// Get all measurement of a certain type
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<MeasurementBase> FindAll(string key)
        {
            return _values.Where(m => m.key == key);
        }

        /// <summary>
        /// Get all measurements for a certain type and theta angle
        /// </summary>
        /// <param name="theta"></param>
        /// <returns></returns>
        public IEnumerable<MeasurementBase> FindAll(string key, double theta)
        {
            return _values.Where(m =>
                      m.key   == key
                    & m.theta == theta);
        }

        /// <summary>
        /// Get all measurements for a theat and phi angle
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="phi"></param>
        /// <returns></returns>
        public IEnumerable<MeasurementBase> FindAll(double theta, double phi)
        {
            return _values.Where(m => 
                      m.theta == theta 
                    & m.phi   == phi);
        }

        /// <summary>
        /// Get specific measurement
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="phi"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public MeasurementBase Find(string key, double theta, double phi)
        {
            return _values.FirstOrDefault(m => 
                      m.key   == key
                    & m.theta == theta 
                    & m.phi   == phi);
        }

        public string[] GetKeys()
        {
            return _values.Select(m => m.key).Distinct().ToArray();
        }

        /// <summary>
        /// Array of distinct Theta values in collection
        /// </summary>
        /// <returns></returns>
        public double[] GetThetaRange()
        {
            return _values.Select(m => m.theta).Distinct().ToArray();
        }

        /// <summary>
        /// Array of distinct Phi values in collection
        /// </summary>
        /// <returns></returns>
        public double[] GetPhiRange()
        {
            return _values.Select(m => m.phi).Distinct().ToArray();
        }

        public MeasurementBase GetEstimateReading(string key, double theta, double phi)
        {
            //try for an exact match:
            var match = this.Find(key, theta, phi);
            if (match != null)
                return match;

            //if any vertical angles are valid, use them for linear extrapoliation
            var vMatches = this.FindAll(key, theta);
            if (vMatches.Count() > 0)
            {
                //split points into those above and below vAngle, already proved there is not value at exact vAngle
                var above = vMatches.Where(t => t.theta > theta).ToList();
                var below = vMatches.Where(t => t.theta < theta).ToList();

                if (above.Count == 0)
                {
                    //all values are below, return closest one
                    return below.OrderByDescending(t => t.theta).First();
                }
                else if (below.Count == 0)
                {
                    //all values are above, return closest one
                    return above.OrderBy(t => t.theta).First();
                }
                else
                {
                    var top = below.OrderByDescending(t => t.theta).First();
                    var bot = above.OrderBy(t => t.theta).First();

                    double estimate = LightMath.LinearExtrapolation(Tuple.Create(top.theta, top.value), Tuple.Create(bot.theta, top.value), theta);
                    return MeasurementBase.Create(theta, phi, key, estimate);
                }
            }

            //find 3 close values and 
            throw new NotImplementedException();
            //or not
        }
        #endregion

        public string GetRaw()
        {
            string s = "";
            foreach (var value in _values)
            {
                s += value.theta + ",";
                s += value.phi   + ",";
                s += value.key   + ",";
                s += value.value + "\n";
            }
            return s;
        }

        public static MeasurementCollection FromRaw(string s)
        {
            var collection = new MeasurementCollection();

            string[] lines = s.Split('\n');
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                
                double theta = Double.Parse(values[0]);
                double phi   = Double.Parse(values[1]);
                string key   = values[2];
                double value = Double.Parse(values[3]);

                collection.Add(MeasurementBase.Create(theta, phi, key, value));
            }
            return collection;
        }
    }
}
