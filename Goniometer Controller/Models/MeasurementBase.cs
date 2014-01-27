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
        /// <summary>
        /// Horizontal/Azimuthal angle from lamp reference
        /// </summary>
        public double Theta { get { return _theta; } }

        private readonly double _phi;
        /// <summary>
        /// Vertical Angle from bottom
        /// </summary>
        public double Phi { get { return _phi; } }

        private readonly string _key;
        public string Key { get { return _key; } }

        private readonly double _value;
        public double Value { get { return _value; } }

        private readonly string _sensorname;
        public string SensorName { get { return _sensorname; } }

        private readonly string _portname;
        public string PortName { get { return _portname; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta">Horizontal/Azimuthal angle from lamp reference</param>
        /// <param name="phi">Vertical Angle from bottom</param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="sensorname"></param>
        /// <param name="portname"></param>
        public MeasurementBase(double theta, double phi, string key, double value, string sensorname = "", string portname = "")
        {
            this._theta = theta;
            this._phi = phi;
            this._key = key;
            this._value = value;
            this._sensorname = sensorname;
            this._portname = portname;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theta">Horizontal/Azimuthal angle from lamp reference</param>
        /// <param name="phi">Vertical Angle from bottom</param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="sensorname"></param>
        /// <param name="portname"></param>
        /// <returns></returns>
        public static MeasurementBase Create(double theta, double phi, string key, double value, string sensorname = "", string portname = "")
        {
            return new MeasurementBase(theta, phi, key, value, sensorname, portname);
        }

        public static string ToCSV(MeasurementBase measurement)
        {
            string s = "";
            s += measurement.SensorName + ",";
            s += measurement.PortName   + ",";
            s += measurement.Theta      + ",";
            s += measurement.Phi        + ",";
            s += measurement.Key        + ",";
            s += measurement.Value;
            return s;
        }

        public static MeasurementBase FromCSV(string measurement)
        {
            string[] values = measurement.Split(',');
            if (values.Length != 6)
                throw new ArgumentException("Expected comma separated string with 6 values");

            string sensorname = values[0];
            string portname   = values[1];
            double theta      = Double.Parse(values[2]);
            double phi        = Double.Parse(values[3]);
            string key        = values[4];
            double value      = Double.Parse(values[5]);

            return MeasurementBase.Create(theta, phi, key, value, sensorname, portname);
        }
    }
}
