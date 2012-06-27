﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Goniometer_Controller.Sensors
{
    abstract class MinoltaBaseSensor : IDisposable
    {
        protected SerialPort _port;

        public MinoltaBaseSensor(SerialPort port)
        {
            _port = port;
        }

        /// <summary>
        /// Open SerialPort
        /// </summary>
        public void Connect()
        {
            if (!_port.IsOpen)
                _port.Open();
        }

        /// <summary>
        /// Close SerialPort
        /// </summary>
        public void Disconnect()
        {
            if (_port != null && _port.IsOpen)
                _port.Close();
        }

        public void IDisposable.Dispose()
        {
            Disconnect();
        }

        /// <summary>
        /// Send Command to sensor
        /// </summary>
        /// <param name="receptor"></param>
        /// <param name="command"></param>
        /// <param name="data"></param>
        protected void SendCommand(int receptor, int command, string data)
        {
            string cmd = "";

            cmd += receptor.ToString("0#");
            cmd += command.ToString("0#");
            cmd += data;
            cmd += "\u0003";            //end bytes

            string bcc = BlockCheckChar(cmd);

            _port.Write("\u0002");       //start bytes
            _port.Write(cmd);
            _port.Write(bcc);
            _port.Write("\u000D\u000A"); //new line with carriage return
        }

        /// <summary>
        /// Read Response from sensor
        /// </summary>
        /// <param name="receptor"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        protected string ReadResponse(out int receptor, out int command)
        {
            string res = _port.ReadLine();

            /* 
             * res.Substring(0, 1);    //Start of Text     \u0002
             * res.Substring(1, 2);    //Receptor #        "00"
             * res.Substring(3, 2);    //Command #         "10"
             * 
             * //Data, Length Unknown
             * res.Substring(4, L-6);
             * 
             * res.Substring(L-5, 1);   //End of Text       \u0003
             * res.Substring(L-4, 2);   //BCC
             * res.Substring(L-2, 2);   //newline
             * */

            //length validation
            //minimum message contains 10 char
            if (res.Length < 10)
                throw new Exception("Message Malformed");

            //REMOVE, the device doesn't provide valid checksums back
            //checksum validation
            string bcc = BlockCheckChar(res.Substring(1, 27));
            if (bcc != res.Substring(28, 2))
                throw new Exception("Message Malformed");

            //error informaiton
            if (res.Substring(6, 1) != " ")
                throw new Exception("Device Error Reported");
            
            receptor = Int32.Parse(res.Substring(1, 2));
            command = Int32.Parse(res.Substring(3, 2));

            return res.Substring(5, res.Length - 5);
        }

        /// <summary>
        /// Block Check Character
        /// </summary>
        /// <param name="payload">string to checksum</param>
        /// <returns>checksum byte, in hex, as a string</returns>
        private string BlockCheckChar(string payload)
        {
            if (String.IsNullOrEmpty(payload))
                throw new ArgumentNullException("payload cannot be null or empty");

            byte[] payloadBytes = Encoding.ASCII.GetBytes(payload);

            int value = 0x00;
            for (int i = 0; i < payloadBytes.Length; i++)
                value ^= payloadBytes[i];

            //return hex as 2 digits
            return value.ToString("X2");
        }

        /// <summary>
        /// Parse Minolta Long-Communication Number-Format
        /// </summary>
        /// <param name="payload">Value to Parse</param>
        /// <returns></returns>
        protected double ParseReadingValue(string payload)
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
