using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Models
{
    public class MeasurementBase
    {
        public readonly double theta;
        public readonly double phi;
        public readonly string key;
        public readonly double value;

        public MeasurementBase(double theta, double phi, string key, double value)
        {
            this.theta = theta;
            this.phi = phi;
            this.key = key;
            this.value = value;
        }

        public static MeasurementBase Create(double theta, double phi, string key, double value)
        {
            return new MeasurementBase(theta, phi, key, value);
        }
    }
}
