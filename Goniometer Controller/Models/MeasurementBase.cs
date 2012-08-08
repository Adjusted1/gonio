using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Models
{
    [Serializable]
    public class MeasurementBase
    {
        private readonly double _theta;
        public double Theta { get { return _theta; } }

        private readonly double _phi;
        public double Phi { get { return _phi; } }

        private readonly string _key;
        public string Key { get { return _key; } }

        private readonly double _value;
        public double Value { get { return _value; } }

        public MeasurementBase(double theta, double phi, string key, double value)
        {
            this._theta = theta;
            this._phi = phi;
            this._key = key;
            this._value = value;
        }

        public static MeasurementBase Create(double theta, double phi, string key, double value)
        {
            return new MeasurementBase(theta, phi, key, value);
        }

        public static string ToCSV(MeasurementBase measurement)
        {
            string s = "";
            s += measurement.Theta + ",";
            s += measurement.Phi   + ",";
            s += measurement.Key   + ",";
            s += measurement.Value;
            return s;
        }

        public static MeasurementBase FromCSV(string measurement)
        {
            string[] values = measurement.Split(',');
            if (values.Length != 4)
                throw new ArgumentException("Expected comma separated string with 4 values");

            double theta = Double.Parse(values[0]);
            double phi   = Double.Parse(values[1]);
            string key   = values[2];
            double value = Double.Parse(values[3]);

            return MeasurementBase.Create(theta, phi, key, value);
        }
    }
}
