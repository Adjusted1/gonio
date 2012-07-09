using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Goniometer_Controller.Motors;
using Goniometer_Controller.Sensors;

namespace Goniometer_Controller
{
    public class GoniometerControllerFactory
    {
        private static object _lock = new object();
        private static GoniometerController _instance;
        
        private static MinoltaTTenController _sensor;

        public static GoniometerController getController()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_sensor == null)
                        throw new Exception("SensorController is null. Configure the factory before requesting an instance");

                    if (_instance == null)
                        _instance = new GoniometerController(_sensor);
                }
            }

            return _instance;
        }

        public static void SetSensorController(MinoltaTTenController sensor)
        {
            lock (_lock)
            {
                _sensor = sensor;

                if (_instance != null)
                    _instance.SetSensorController(_sensor);
            }
        }
    }
}
