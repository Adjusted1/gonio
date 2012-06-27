using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace Goniometer_Controller.Sensors
{
    public class MinoltaCLTwoHundredSensor : MinoltaBaseSensor
    {
        public MinoltaCLTwoHundredSensor(SerialPort port)
            : base(port)
        {
        }

        /// <summary>
        /// Open SerialPort if Closed
        /// Set sensor to PC Mode, Hold Mode, and EXT Mode
        /// </summary>
        public void Connect()
        {
            if (!_port.IsOpen)
                _port.Open();

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

        public enum CalibrationModeEnum
        {
            NORM,
            MULTI,
        }
    }
}
