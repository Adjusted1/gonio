using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Goniometer_Controller.Motors
{
    public static class MotorControllerFactory
    {
        private static object _lock = new object();
        private static MotorController _instance;
        private static IPAddress _address;

        public static MotorController getMotorController()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_address == null)
                        throw new Exception("IPAddress is null. Configure the factory before requesting an instance");

                    if (_instance == null)
                        _instance = new MotorController(_address);
                }
            }

            return _instance;
        }

        public static void ConfigureMotorController(IPAddress address)
        {
            lock (_lock)
            {
                _address = address;
                _instance = null;
            }
        }
    }
}
