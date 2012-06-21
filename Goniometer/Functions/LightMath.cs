using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer.Functions
{
    public static class LightMath
    {
        public static double Radians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public static double SolidAngle(double degrees)
        {
            return 2 * Math.PI * (1 - Math.Cos(Radians(degrees)));
        }

        /// <summary>
        /// Average horizontal readings, then calculate Lumens
        /// </summary>
        /// <param name="data">Units: hAngle degrees, vAngle degrees, footcandles</param>
        /// <returns></returns>
        public static double CalculateLumensByHorizontalAverage(List<Tuple<double, double, double>> data)
        {
            //vAngle, footcandle
            List<Tuple<double, double>> candleReadings = new List<Tuple<double, double>>();

            double[] vRange = data.Select((item) => item.Item2).Distinct().ToArray();
            foreach (double v in vRange)
            {
                double candles = data.Where((item) => item.Item2 == v)
                                     .Average((item) => item.Item3);

                candleReadings.Add(Tuple.Create(v, candles));
            }

            return CalculateLumens(candleReadings);
        }

        /// <summary>
        /// Calculate the Lumen value of a vertical array and average them together
        /// </summary>
        /// <param name="data">Units: hAngle degrees, vAngle degrees, footcandles</param>
        /// <returns></returns>
        public static double CalculateLumensByVertical(List<Tuple<double, double, double>> data)
        {
            //hAngle, lumen
            List<Tuple<double, double>> lumenReadings = new List<Tuple<double, double>>();
            
            double[] hRange = data.Select((item) => item.Item1).Distinct().ToArray();
            foreach(double h in hRange)
            {
                var vData = data.Where((item) => item.Item1 == h)
                                .Select((item) => Tuple.Create(item.Item2, item.Item3))
                                .ToList();

                lumenReadings.Add(Tuple.Create(h, CalculateLumens(vData)));
            }

            //average by hAngle
            return lumenReadings.Average((item) => item.Item2);
        }

        /// <summary>
        /// Calculate Lumen data along single vertical axis
        /// </summary>
        /// <param name="data">Units: degrees, footcandles</param>
        /// <returns></returns>
        public static double CalculateLumens(List<Tuple<double, double>> data)
        {
            //must be sorted by angle
            data.Sort();

            double total = 0;

            //we are only measuring the horizontal component
            Func<double, double, double> HorizontalComponent = (t1, t2) => 
                { return Math.Cos(Radians(t1)) - Math.Cos(Radians(t2)); };

            for (int i = 0; i < data.Count; i++)
            {
                //get midrange between this and previous angle
                double theta1;
                if (i == 0)
                    theta1 = data[i].Item1;
                else
                    theta1 = data[i].Item1 - (data[i].Item1 - data[i - 1].Item1) / 2;

                //get midrange between this and next angle
                double theta2;
                if (i == data.Count - 1)
                    theta2 = data[i].Item1;
                else
                    theta2 = data[i].Item1 + (data[i + 1].Item1 - data[i].Item1) / 2;

                //determine horizontal component of reading
                double h = HorizontalComponent(theta1, theta2);

                //sum component values
                total += data[i].Item2 * h;
            }

            //get angle range for solid angle calculations
            double angle = data.Max(t => t.Item1) - data.Min(t => t.Item1);

            //return calculated lumen as: sum of components * 2 * PI * SolidAngle
            return total * SolidAngle(angle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1">x1, y1</param>
        /// <param name="p2">x2, y2</param>
        /// <param name="x">x0</param>
        /// <returns>y0</returns>
        public static double LinearExtrapolation(Tuple<double, double> p1, Tuple<double, double> p2, double x)
        {
            double m = (p1.Item2 - p2.Item2) / (p1.Item1 - p2.Item1);
            double c = m * p1.Item1 - p1.Item2;

            return m * x + c;
        }

        public static double BiLinearExtrapolation(
            Tuple<double, double, double> p1, Tuple<double, double, double> p2,
            Tuple<double, double, double> p3, Tuple<double, double, double> p4,
            double x, double y)
        {
            throw new NotImplementedException();
        }
    }
}
