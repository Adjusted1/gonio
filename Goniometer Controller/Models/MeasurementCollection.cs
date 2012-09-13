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
                      m.Theta == measurement.Theta 
                    & m.Phi   == measurement.Phi
                    & m.Key   == measurement.Key);

            if (existing != null)
                throw new Exception();

            _values.Add(measurement);
        }

        public void AddRange(IEnumerable<MeasurementBase> measurements)
        {
            foreach (var measurement in measurements)
                Add(measurement);
        }

        public void AddRange(MeasurementCollection collection)
        {
            this.AddRange(collection._values);
        }

        public void Remove(MeasurementBase measurement)
        {
            _values.Remove(measurement);
        }

        /// <summary>
        /// Get all measurement of a certain type
        /// </summary>
        /// <param sensorname="Key"></param>
        /// <returns></returns>
        public IEnumerable<MeasurementBase> FindAll(string key)
        {
            return _values.Where(m => m.Key == key);
        }

        /// <summary>
        /// Get all measurements for a certain type and Theta angle
        /// </summary>
        /// <param sensorname="Theta"></param>
        /// <returns></returns>
        public IEnumerable<MeasurementBase> FindAll(string key, double theta)
        {
            return _values.Where(m =>
                      m.Key   == key
                    & m.Theta == theta);
        }

        /// <summary>
        /// Get all measurements for a theat and Phi angle
        /// </summary>
        /// <param sensorname="Theta"></param>
        /// <param sensorname="Phi"></param>
        /// <returns></returns>
        public IEnumerable<MeasurementBase> FindAll(double theta, double phi)
        {
            return _values.Where(m => 
                      m.Theta == theta 
                    & m.Phi   == phi);
        }

        /// <summary>
        /// Get specific measurement
        /// </summary>
        /// <param sensorname="Theta"></param>
        /// <param sensorname="Phi"></param>
        /// <param sensorname="Key"></param>
        /// <returns></returns>
        public MeasurementBase Find(string key, double theta, double phi)
        {
            return _values.FirstOrDefault(m => 
                      m.Key   == key
                    & m.Theta == theta 
                    & m.Phi   == phi);
        }

        public string[] GetKeys()
        {
            return _values.Select(m => m.Key).Distinct().ToArray();
        }

        /// <summary>
        /// Array of distinct Theta values in collection
        /// </summary>
        /// <returns></returns>
        public double[] GetThetaRange()
        {
            return _values.Select(m => m.Theta).Distinct().ToArray();
        }

        /// <summary>
        /// Array of distinct Phi values in collection
        /// </summary>
        /// <returns></returns>
        public double[] GetPhiRange()
        {
            return _values.Select(m => m.Phi).Distinct().ToArray();
        }
        #endregion

        #region operators
        public static MeasurementCollection SubtractFrom(MeasurementCollection source, MeasurementCollection estimates)
        {
            MeasurementCollection results = new MeasurementCollection();

            foreach (var m in source._values)
            {
                double estimate = MeasurementCollection.GetEstimateReading(estimates, m.Key, m.Theta, m.Phi).Value;
                results.Add(MeasurementBase.Create(m.Theta, m.Phi, m.Key, m.Value - estimate, m.SensorName, m.PortName));
            }

            return results;
        }

        public static MeasurementCollection MultiplyBy(MeasurementCollection source, double value)
        {
            MeasurementCollection results = new MeasurementCollection();

            foreach (var m in source._values)
            {
                results.Add(MeasurementBase.Create(m.Theta, m.Phi, m.Key, m.Value * value, m.SensorName, m.PortName));
            }

            return results;
        }
        #endregion

        public static MeasurementBase GetEstimateReading(MeasurementCollection source, string key, double theta, double phi)
        {
            //find closest vertical band
            double closeTheta = source.FindAll(key).MinSelectMember(t => Math.Abs(t.Theta - theta)).Theta;

            //find closest member
            return source.FindAll(key, closeTheta).MinSelectMember(t => Math.Abs(t.Phi - phi));
        }

        public static MeasurementBase GetEstimateReading_Extrapolation(MeasurementCollection source, string key, double theta, double phi)
        {
            //try for an exact match:
            var match = source.Find(key, theta, phi);
            if (match != null)
                return match;

            //if any vertical angles are valid, use them for linear extrapoliation
            var vMatches = source.FindAll(key, theta);
            if (vMatches.Count() > 0)
            {
                //split points into those above and below vAngle, already proved there is not Value at exact vAngle
                var above = vMatches.Where(t => t.Theta > theta).ToList();
                var below = vMatches.Where(t => t.Theta < theta).ToList();

                if (above.Count == 0)
                {
                    //all values are below, return closest one
                    return below.OrderByDescending(t => t.Theta).First();
                }
                else if (below.Count == 0)
                {
                    //all values are above, return closest one
                    return above.OrderBy(t => t.Theta).First();
                }
                else
                {
                    var top = below.OrderByDescending(t => t.Theta).First();
                    var bot = above.OrderBy(t => t.Theta).First();

                    double estimate = LightMath.LinearExtrapolation(Tuple.Create(top.Theta, top.Value), Tuple.Create(bot.Theta, top.Value), theta);
                    return MeasurementBase.Create(theta, phi, key, estimate);
                }
            }

            //find 3 close values and 
            throw new NotImplementedException();
            //or not
        }

        public static string ToCSV(MeasurementCollection collection)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in collection._values)
            {
                sb.AppendLine(MeasurementBase.ToCSV(value));
            }
            return sb.ToString();
        }

        public static MeasurementCollection FromCSV(string s)
        {
            var collection = new MeasurementCollection();

            string[] lines = s.Split('\n');
            foreach (string line in lines)
            {
                if (String.IsNullOrWhiteSpace(line))
                    continue;

                var measurement = MeasurementBase.FromCSV(line);
                collection.Add(measurement);
            }
            return collection;
        }
    }
}
