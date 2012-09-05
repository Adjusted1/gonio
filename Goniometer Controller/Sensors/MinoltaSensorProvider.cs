using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

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

        public static IEnumerable<MinoltaBaseSensor> GetSensors()
        {
            List<MinoltaBaseSensor> sensors = new List<MinoltaBaseSensor>();

            string[] portnames = SerialPort.GetPortNames();
            string[] sensornames = GetSensorNames();

            //iterate every known sensor type for all available ports
            foreach (string portname in portnames)
            foreach (string sensorname in sensornames)
            {   
                try
                {
                    SerialPort port = SerialPortProvider.GetPort(portname);
                    MinoltaBaseSensor sensor = GetSensorByName(sensorname, port);

                    if (sensor.TestStatus())
                        sensors.Add(sensor);
                }
                catch (Exception)
                {
                    //unknown failure, move onto the next type
                }
            }

            return sensors;
        }

        public static MinoltaBaseSensor GetSensorByName(string name, SerialPort port)
        {
            switch (name)
            {
                case (MinoltaT10Controller.Name):
                    return new MinoltaT10Controller(port);

                case (MinoltaCL200Controller.Name):
                    return new MinoltaCL200Controller(port);

                default:
                    throw new ArgumentException("Unknown Sensor by that sensorname");
            } 
        }
    }
}
