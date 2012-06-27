using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace Goniometer_Controller.Sensors
{
    public class MinoltaTTenSensor : MinoltaBaseSensor
    {
        public MinoltaTTenSensor(SerialPort port)
            : base(port)
        {
        }

        public override void Connect()
        {
            base.Connect();

            //command 54 = set device to pc mode
            //data = 1\s\s\s = Connect
            //[Connect][Empty][Empty][Empty]
            SendCommand(0, 54, "1   ");
            Thread.Sleep(1000);

            //read out confirmation
            _port.ReadLine();

            //99 = send to all receptors
            //command 55 = set hold to all connected recptors
            //data = 1  1 = Run, Slow
            //[Run/Hold][Empty][Empty][Fast/Slow]
            SendCommand(99, 55, "1  1");
            Thread.Sleep(5000);
            
            /* no response to read */
        }

        public double Read()
        {
            //00 = send to first receptor
            //command 10 = read illuminance
            //data = "0220" = Run, CCF_Off, Range..., Fast
            //[Run/Hold][CCF][Range][Fast/Slow]

            SendCommand(0, 10, "0200");
            return ReadResult();
        }

        private double ReadResult()
        {
            string res = _port.ReadLine();

            /* 
             * res.Substring(0, 1);    //Start of Text     \u0002
             * res.Substring(1, 2);    //Receptor #        "00"
             * res.Substring(3, 2);    //Command #         "10"
             * 
             * //Data 4, Reading Metadata
             * res.Substring(5, 1);    //HOLD status       "0, 2, 4, 6" or "1, 3, 5, 7"
             * res.Substring(6, 1);    //Error Info
             * res.Substring(7, 1);    //Range             "0" or "1 - 5"
             * res.Substring(8, 1);    //Battery Info      "0, 2"
             * 
             * //Data 3, Illuminance Value
             * res.Substring(9, 6);
             * 
             * //Data 2, Delta Value
             * res.Substring(15, 6);   
             * 
             * //Data 1, % Value
             * res.Substring(21, 6);   
             * 
             * res.Substring(27, 1);   //End of Text       \u0003
             * 
             * res.Substring(28, 2);   //BCC
             * 
             * res.Substring(30, 2);   //newline
             * */

            //length validation
            //31 or 32 depending on if the system considers the newline one or two chars
            if (res.Length != 31 & res.Length != 32)
                throw new Exception("Message Malformed");

            //REMOVE, the device doesn't provide valid checksums back
            //checksum validation
            string bcc = BlockCheckChar(res.Substring(1, 27));
            if (bcc != res.Substring(28, 2))
                throw new Exception("Message Malformed");

            //error informaiton
            if (res.Substring(6, 1) != " ")
                throw new Exception("Device Error Reported");
            
            return ParseReadingValue(res.Substring(9, 6));
        }

        private double ParseReadingValue(string payload)
        {
            if (payload == null || payload.Length != 6)
                throw new ArgumentException("reading must be length of 6");

            /*
             * payload.Substring(0, 1);   //Sign              "+, -, ="
             * payload.Substring(1, 4);   //Reading           "0 - 9"
             * payload.Substring(5, 1);   //Magnitude         "0 - 9" => (10^-4) - (10^5)
             * 
             * example:
             * 
             * "+ 3343" becomes 33.4
             * "-00011" becomes -0.001
             * */

            double reading = Double.Parse(payload.Substring(1, 4).Trim());
            double power = Double.Parse(payload.Substring(5, 1)) - 4;

            if (payload.Substring(0, 1) == "-")
                reading *= -1;

            reading *= Math.Pow(10, power);

            return reading;
        }
    }
}
