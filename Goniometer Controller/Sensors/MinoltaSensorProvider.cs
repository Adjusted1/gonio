using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Goniometer_Controller.Sensors
{
    public static class MinoltaSensorProvider
    {
        private static object _lock = new object();
        private static SerialPort _port;

        public static string[] GetSensorNames()
        {
            return new string[]
            {
                MinoltaT10Controller.Name,
                MinoltaCL200Controller.Name
            };
        }

        public static List<MinoltaBaseSensor> GetSensors()
        {
            var result = new List<MinoltaBaseSensor>();

            foreach (var name in GetSensorNames())
            {
                try
                {
                    result.Add(GetSensorByName(name));
                }
                catch (InvalidOperationException) { /*uninitialized controller*/ }
            }

            return result;
        }

        public static MinoltaBaseSensor GetSensorByName(string name)
        {
            lock (_lock)
            {
                if (_port == null)
                    throw new InvalidOperationException("PortName is null or empty. Configure the factory before requesting an instance");

                switch (name)
                {
                    case (MinoltaT10Controller.Name):
                        return new MinoltaT10Controller(_port);

                    case (MinoltaCL200Controller.Name):
                        return new MinoltaCL200Controller(_port);

                    default:
                        throw new ArgumentException("Unknown Sensor by that name");
                } 
            }
        }

        public static void ConfigureControllers(string portname)
        {
            lock (_lock)
            {
                if (_port != null)
                    _port.Dispose();

                _port = new SerialPort(portname);
                _port.BaudRate = 9600;
                _port.DataBits = 7;
                _port.StopBits = StopBits.One;
                _port.Parity = Parity.Even;

                _port.ReadTimeout = 100;
                _port.WriteTimeout = 100;
            }
        }
    }
}
