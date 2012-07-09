using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Goniometer_Controller.Motors
{
    internal class BaseMotor
    {
        public readonly double accuracy = 0.02; //scaled units

        private short _axisNumber;
        private double _scale;

        public BaseMotor(short axisNumber, double scale)
        {
            this._axisNumber = axisNumber;
            this._scale = scale;
        }

        public double GetAngle()
        {
            //string cmd = "!";
            //cmd += _axisNumber + 1; //controller is 1-indexed
            //cmd += "tpe:";

            //string res = MotorSocketProvider.WriteForResponse(cmd);

            //return Double.Parse(res); 

            short axis = (short) (_axisNumber + 1);
            int pos = MotorSocketProvider.GetEncoderPosition(axis);
            return pos / _scale;
        }

        /// <summary>
        /// Set motor encoder offset value to zero
        /// </summary>
        public void ZeroMotor()
        {
            string cmd = "pset";
            cmd += ','.Multiply(_axisNumber);
            cmd += "0:";

            MotorSocketProvider.Write(cmd); 
        }

        #region initialize commands

        #endregion

        #region motion commands
        public void Move(double distance, double velocity, double acceleration, bool absolute)
        {
            string cmd = "";

            ////stop current movement
            //cmd += "!s";
            //cmd += '0'.Multiply(_axisNumber);
            //cmd += "1:";

            //enable drive
            cmd += "drive";
            cmd += 'x'.Multiply(_axisNumber);
            cmd += "1:";

            //distance
            cmd += "d";
            cmd += ','.Multiply(_axisNumber);
            cmd += distance + ":";

            //velocity
            cmd += "v";
            cmd += ','.Multiply(_axisNumber);
            cmd += velocity + ":";

            //acceleration
            cmd += "a";
            cmd += ','.Multiply(_axisNumber);
            cmd += acceleration + ":";

            //average acceleration
            cmd += "aa";
            cmd += ','.Multiply(_axisNumber);
            cmd += acceleration + ":";

            //deceleration
            cmd += "ad";
            cmd += ','.Multiply(_axisNumber);
            cmd += acceleration + ":";

            //average deceleration
            cmd += "ada";
            cmd += ','.Multiply(_axisNumber);
            cmd += acceleration + ":";

            //execute
            cmd += "!go";
            cmd += 'x'.Multiply(_axisNumber);
            cmd += "1:";

            MotorSocketProvider.Write(cmd); 
        }

        public void MoveAndWait(double distance, double velocity, double acceleration, bool absolute)
        {
            TimeSpan timeout = new TimeSpan(0, 1, 0);

            Move(distance, velocity, acceleration, absolute);

            DateTime startTime = DateTime.Now;
            while (GetAngle() - distance < accuracy)
            {
                if (DateTime.Now - startTime > timeout)
                    //we've exceeded our alloted time
                    throw new TimeoutException();
                else
                    //sleep then check again
                    Thread.Sleep(100);
            } 
        }

        public void EmergencyStop()
        {
            string cmd = "!k";
            cmd += 'x'.Multiply(_axisNumber);
            cmd += "1:";

            MotorSocketProvider.Write(cmd); 
        }
        #endregion

        public void SendCommand(string cmd, string data)
        {
            cmd += ','.Multiply(_axisNumber);
            cmd += data + ":";

            MotorSocketProvider.Write(cmd); 
        }
    }
}
