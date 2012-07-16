using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Threading;
using Goniometer_Controller.Models;

namespace Goniometer_Controller.Sensors
{
    public class MinoltaCL200Controller : MinoltaBaseSensor
    {
        public const string Name = "Minolta CL200";
        public override string GetName()
        {
            return MinoltaCL200Controller.Name;
        }

        public MinoltaCL200Controller(string portName)
        {
            base._port = new SerialPort(portName);
            base._port.BaudRate = 9600;
            base._port.DataBits = 7;
            base._port.StopBits = StopBits.One;
            base._port.Parity = Parity.Even;
            
            base._port.ReadTimeout = 100;
            base._port.WriteTimeout = 100;
        }

        public MinoltaCL200Controller(SerialPort port)
            : base(port)
        {
        }

        /// <summary>
        /// Open SerialPort if Closed
        /// Set sensor to PC Mode, Hold Mode, and EXT Mode
        /// </summary>
        public override void Connect()
        {
            base.Connect();

            //command 54 = set device to pc mode
            //data = 1\s\s\s = Connect
            //[Connect][Empty][Empty][Empty]
            SendCommand(0, 54, "1   ");
            Thread.Sleep(500);

            //read out confirmation
            _port.ReadLine();
            
            //command 55 = set hold status
            //data = 1\s\s0 = 
            //[][][][]
            SendCommand(99, 55, "1  0");
            Thread.Sleep(500);
            
            /* no response to read */

            //command 40 = set EXT mode
            //data = 10\s\s = EXT MODE
            //[][][][]
            SendCommand(0, 40, "10  ");
            Thread.Sleep(175);

            //read out confirmation
            //TODO: check error code
            _port.ReadLine();
        }

        #region measurement methods
        /// <summary>
        /// Take a measurement on all receptors. Call this before using the read commands
        /// </summary>
        public void TakeMeasurement()
        {
            int receptor = 99;      //send command to all heads
            int command = 40;       //EXT Command
            string data = "21  ";   //"21\s\s"

            SendCommand(receptor, command, data);
            Thread.Sleep(500);
        }

        public void ReadXYZ(int receptor, bool useCF, CalibrationModeEnum mode,
            out double x, out double y, out double z)
        {
            int command = 1;
            ReadMeasurement(receptor, command, useCF, mode, out x, out y, out z);
        }

        public void ReadEvXY(int receptor, bool useCF, CalibrationModeEnum mode,
            out double Ev, out double x, out double y)
        {
            int command = 2;
            ReadMeasurement(receptor, command, useCF, mode, out Ev, out x, out y);
        }

        public void ReadEvUV(int receptor, bool useCF, CalibrationModeEnum mode,
            out double Ev, out double u, out double v)
        {
            int command = 3;
            ReadMeasurement(receptor, command, useCF, mode, out Ev, out u, out v);
        }

        public void ReadEvTcpUV(int receptor, bool useCF, CalibrationModeEnum mode,
            out double Ev, out double Tcp, out double uv)
        {
            int command = 8;
            ReadMeasurement(receptor, command, useCF, mode, out Ev, out Tcp, out uv);
        }

        public void ReadEvDWP(int receptor, bool useCF, CalibrationModeEnum mode,
            out double Ev, out double dw, out double p)
        {
            int command = 15;
            ReadMeasurement(receptor, command, useCF, mode, out Ev, out dw, out p);
        }

        public void ReadX2YZ(int receptor, bool useCF, CalibrationModeEnum mode,
            out double x2, out double y, out double z)
        {
            int command = 45;
            ReadMeasurement(receptor, command, useCF, mode, out x2, out y, out z);
        }

        private void ReadMeasurement(int receptor, int command, bool useCF, CalibrationModeEnum mode,
            out double r1, out double r2, out double r3)
        {
            string data = "1";
            data += useCF ? "2" : "3";
            data += "0";

            if (mode == CalibrationModeEnum.NORM)
                data += "0";
            else
                data += "1";

            SendCommand(receptor, command, data);
            string res = ReadResponse(out receptor, out command);

            //res.Substring(0, 1); "1" or "5"
            //string error = res.Substring(1, 1);
            //string range = res.Substring(2, 1);
            //string batLv = res.Substring(3, 1);   //battery level, 0 == normal

            r1 = ParseReadingValue(res.Substring(4, 6));
            r2 = ParseReadingValue(res.Substring(10, 6));
            r3 = ParseReadingValue(res.Substring(16, 6));
        } 
        #endregion

        public override List<MeasurementBase> CollectMeasurements(double theta, double phi)
        {
            double eps = 0.02;
            bool useCF = false;
            CalibrationModeEnum mode = CalibrationModeEnum.NORM;

            //Take two measurements. Make sure they are similar within some epsilon. Return the first measurement
            //If the measurements differ significantly, start over
            List<MeasurementBase> m1, m2;
            bool valid;

            do
            {
                //start over!
                valid = true;
                m1 = CollectMeasurements(theta, phi, 0, useCF, mode);
                m2 = CollectMeasurements(theta, phi, 0, useCF, mode);

                //compare for each key
                foreach(string key in m1.Select(m => m.key))
                {
                    double v1 = m1.First(m => m.key == key).value;
                    double v2 = m2.First(m => m.key == key).value;

                    //validate measurement within some epsilon
                    if (Math.Abs(v1 - v2) > eps)
                        valid = false;
                }
            
            } while (!valid);

            return m1;
        }

        private List<MeasurementBase> CollectMeasurements(double theta, double phi, int receptor, bool useCF, CalibrationModeEnum mode)
        {
            var measurements = new List<MeasurementBase>();
            TakeMeasurement();

            double Ev1, u, v;
            ReadEvUV(receptor, useCF, mode, out Ev1, out u, out v);
            measurements.Add(MeasurementBase.Create(theta, phi, MeasurementKeys.IlluminanceEv, Ev1));
            measurements.Add(MeasurementBase.Create(theta, phi, MeasurementKeys.ColorU, u));
            measurements.Add(MeasurementBase.Create(theta, phi, MeasurementKeys.ColorV, v));

            double Ev2, Tcp, Duv;
            ReadEvTcpUV(receptor, useCF, mode, out Ev2, out Tcp, out Duv);
            measurements.Add(MeasurementBase.Create(theta, phi, MeasurementKeys.ColorTemp, Tcp));
            measurements.Add(MeasurementBase.Create(theta, phi, MeasurementKeys.ColorDiff, Duv));

            return measurements;
        }

        public enum CalibrationModeEnum
        {
            NORM,
            MULTI,
        }
    }
}
