using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer.Functions
{
    public static class MathExtensions
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
        /// 
        /// </summary>
        /// <param name="data">must already be sorted by Item1. Units degrees, footcandles</param>
        /// <returns></returns>
        public static double CalculateLumens(List<Tuple<double, double>> data)
        {
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
                double h = HorizontalComponent(theta2, theta2);

                //sum component value
                total += data[i].Item2 * h;
            }

            double angle = data.Max(t => t.Item1) - data.Min(t => t.Item1);

            //return calculated lumen as: sum of components * 2 * PI * SolidAngle
            return 2 * Math.PI * total * SolidAngle(angle);
        }
    }
}
