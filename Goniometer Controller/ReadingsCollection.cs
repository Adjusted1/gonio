using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Goniometer_Controller.Functions;

namespace Goniometer_Controller
{
    public class ReadingsCollection
    {
        private List<Tuple<double, double, double>> _values;

        public ReadingsCollection()
        {
            _values = new List<Tuple<double, double, double>>();
        }

        #region get/set
        public void Add(double horizontal, double vertical, double reading)
        {
            var existing = _values.FirstOrDefault(t => t.Item1 == horizontal & t.Item2 == vertical);
            if (existing != null)
                throw new Exception();

            _values.Add(Tuple.Create(horizontal, vertical, reading));
        }

        public double GetReading(double horizontal, double vertical)
        {
            var existing = _values.FirstOrDefault(t => t.Item1 == horizontal & t.Item2 == vertical);
            if (existing == null)
                throw new Exception();

            return existing.Item3;
        }

        private double GetEstimateReading(double horizontal, double vertical)
        {
            //try for an exact match:
            var match = _values.Find(t => t.Item1 == horizontal & t.Item2 == vertical);
            if (match != null)
                return match.Item3;

            //if any horizontal angles are valid, use them for linear extrapoliation
            var horizontalmatches = _values.FindAll(t => t.Item1 == horizontal);
            if (horizontalmatches != null)
            {
                //split points into those above and below vAngle, already proved there is not value at exact vAngle
                var above = horizontalmatches.Where(t => t.Item2 > vertical).ToList();
                var below = horizontalmatches.Where(t => t.Item2 < vertical).ToList();

                if (above.Count == 0)
                {
                    //all values are below, return closest one
                    return below.OrderByDescending(t => t.Item2).First().Item3;
                }
                else if (below.Count == 0)
                {
                    //all values are above, return closest one
                    return above.OrderBy(t => t.Item2).First().Item3;
                }
                else
                {
                    var top = below.OrderByDescending(t => t.Item2).First();
                    var bot = above.OrderBy(t => t.Item2).First();

                    return LightMath.LinearExtrapolation(Tuple.Create(top.Item2, top.Item3), Tuple.Create(top.Item2, top.Item3), vertical);
                }
            }

            //find 3 close values and 
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<double, double>> GetVerticalReadings(double horizontal)
        {
            return _values.Where(t => t.Item1 == horizontal)
                          .Select(t => Tuple.Create(t.Item2, t.Item3));
        }

        public double[] GetHorizontalRange()
        {
            return _values.Select(t => t.Item1).Distinct().ToArray();
        }

        public double[] GetVerticalRange()
        {
            return _values.Select(t => t.Item2).Distinct().ToArray();
        }
        #endregion

        public override string ToString()
        {
            string result = "";
            foreach (var val in _values)
            {
                result += String.Format("{0:0.0},{1:0.0},{2:0.0}\n", val.Item1, val.Item2, val.Item3);
            }
            return result;
        }

        public double CalculateLumens()
        {
            return LightMath.CalculateLumens(_values);
        }

        public static ReadingsCollection RemoveStrayLight(ReadingsCollection readings, ReadingsCollection strayReadings)
        {
            ReadingsCollection results = new ReadingsCollection();
            
            foreach(var t in readings._values)
            {
                double r = t.Item3 - strayReadings.GetEstimateReading(t.Item1, t.Item2);
                results.Add(t.Item1, t.Item2, r);
            }

            return results;
        }

        public static ReadingsCollection ApplyOffsetFactor(ReadingsCollection readings, double factor)
        {
            ReadingsCollection results = new ReadingsCollection();
            
            foreach(var t in readings._values)
            {
                double r = t.Item3 * factor;
                results.Add(t.Item1, t.Item2, r);
            }

            return results;
        }
    }
}
