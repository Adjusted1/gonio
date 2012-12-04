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
        }

        public static void LoadSensorConfiguration()
        {
            //reload sensor list
            _sensors = new List<MinoltaBaseSensor>();
            var config = GoniometerControllerConfigurationSection.GetConfigurationSection();

            foreach (GoniometerControllerConfigurationSection.SensorConfigurationElement sensorInfo in config.Sensors)
            {
                var port = SerialPortProvider.GetPort(sensorInfo.Port);
                var sensor = CreateSensor(sensorInfo.Name, sensorInfo.Type, port);
                sensor.Connect();

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
            MinoltaBaseSensor sensor;

            switch (type)
            {
                case (MinoltaT10Controller.Type):
                    sensor = new MinoltaT10Controller(port);
                    break;

                case (MinoltaCL200Controller.Type):
                    sensor = new MinoltaCL200Controller(port);
                    break;

                default:
                    throw new ArgumentException("Unknown Sensor by that sensorname");
            }

            sensor.Name = name;
            return sensor;
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
