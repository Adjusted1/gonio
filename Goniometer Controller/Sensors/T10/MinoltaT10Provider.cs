using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Sensors
{
    public static class MinoltaT10Provider
    {
        private static object _lock = new object();
        private static MinoltaT10Controller _instance;
        private static string _portName;

        public static MinoltaT10Controller GetController()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (String.IsNullOrEmpty(_portName))
                        throw new InvalidOperationException("PortName is null or empty. Configure the factory before requesting an instance");

                    if (_instance == null)
                        _instance = new MinoltaT10Controller(_portName);
                }
            }

            return _instance;
        }

        public static void SetPortName(string portName)
        {
            lock (_lock)
            {
                _portName = portName;
                _instance = new MinoltaT10Controller(_portName);
            }
        }
    }
}
