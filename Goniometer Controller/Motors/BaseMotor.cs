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
        protected readonly double _accuracy = 0.5; //scaled units

        protected short _axisNumber;
        protected double _scale;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axisNumber">zero indexed</param>
        /// <param name="scale"></param>
        public BaseMotor(short axisNumber, double scale)
        {
            this._axisNumber = axisNumber;
            this._scale = scale;
        }

        public virtual double GetAngle()
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
        /// Set motor encoder offset Value to zero
        /// </summary>
        public virtual void ZeroMotor()
        {
            string cmd = "pset";
            cmd += ','.Multiply(_axisNumber);
            cmd += "0:";

            MotorSocketProvider.Write(cmd); 
        }

        #region initialize commands

        #endregion

        #region motion commands
        /// <summary>
        /// Instruct Motor to move
        /// This method makes no guarantee that the motor will reach its destination
        /// in a timely manner (or at all)
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="velocity"></param>
        /// <param name="acceleration"></param>
        public virtual void Move(double distance, double velocity, double acceleration)
        {
            string cmd = "";

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

        /// <summary>
        /// Instruct Motor to move, return when completed within some epsilon
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="velocity"></param>
        /// <param name="acceleration"></param>
        /// <exception cref="TimeoutException">Throw if the motor does not reach it's destination in a timely manner</exception>
        public virtual void MoveAndWait(double distance, double velocity, double acceleration)
        {
            TimeSpan timeout = new TimeSpan(0, 1, 0);

            Move(distance, velocity, acceleration);

            DateTime startTime = DateTime.Now;
            while (Math.Abs(GetAngle() - distance) > _accuracy)
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
