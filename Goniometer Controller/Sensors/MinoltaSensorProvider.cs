using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Sensors
{
    public static class MinoltaSensorProvider
    {
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
            switch (name)
            {
                case (MinoltaT10Controller.Name):
                    return MinoltaT10Provider.GetController();

                case (MinoltaCL200Controller.Name):
                    return MinoltaCL200Provider.GetController();

                default:
                    throw new ArgumentException("Unknown Sensor by that name");
            }
        }

        public static void ConfigureControllers(string portname)
        {
            MinoltaT10Provider.SetPortName(portname);
            MinoltaCL200Provider.SetPortName(portname);
        }
    }
}
