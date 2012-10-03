using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Goniometer_Controller.Sensors
{
    public static class MinoltaSensorProvider
    {
        private static object _sensorsLock = new object();
        private static List<MinoltaBaseSensor> _sensors = new List<MinoltaBaseSensor>();
        
        static MinoltaSensorProvider()
        {
            LoadSensorConfiguration();
        }

        private static void LoadSensorConfiguration()
        {
            var config = GoniometerControllerConfigurationSection.GetConfigurationSection();
            foreach (GoniometerControllerConfigurationSection.SensorConfigurationElement sensorInfo in config.Sensors)
            {
                var port = SerialPortProvider.GetPort(sensorInfo.Port);
                var sensor = CreateSensor(sensorInfo.Name, sensorInfo.Type, port);

                AddSensor(sensor);
            }
        }

        public static void SaveSensorConfiguration()
        {

        }

        public static IEnumerable<string> GetSensorTypes()
        {
            var types = new List<string>();

            types.Add(MinoltaT10Controller.Type);
            types.Add(MinoltaCL200Controller.Type);

            return types;
        }

        public static MinoltaBaseSensor CreateSensor(string name, string type, SerialPort port)
        {
            switch (type)
            {
                case (MinoltaT10Controller.Type):
                    return new MinoltaT10Controller(name, port);

                case (MinoltaCL200Controller.Type):
                    return new MinoltaCL200Controller(name, port);

                default:
                    throw new ArgumentException("Unknown Sensor by that sensorname");
            } 
        }

        public static void AddSensor(MinoltaBaseSensor sensor)
        {
            lock (_sensorsLock)
            {
                _sensors.Add(sensor);
            }
        }

        public static bool RemoveSensor(MinoltaBaseSensor sensor)
        {
            lock (_sensorsLock)
            {
                return _sensors.Remove(sensor);
            }
        }

        public static IEnumerable<MinoltaBaseSensor> GetSensors()
        {
            return _sensors.ToList();
        }
    }
}
