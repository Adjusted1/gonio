using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Sensors
{
    public static class MinoltaTTenControllerFactory
    {
        private static object _lock = new object();
        private static MinoltaTTenController _instance;
        private static string _portName;

        public static MinoltaTTenController GetSensorController()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (String.IsNullOrEmpty(_portName))
                        throw new Exception("PortName is null or empty. Configure the factory before requesting an instance");

                    if (_instance == null)
                        _instance = new MinoltaTTenController(_portName);
                }
            }

            return _instance;
        }

        public static void ConfigureMotorController(string portName)
        {
            lock (_lock)
            {
                _portName = portName;
            }
        }
    }
}
