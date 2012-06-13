using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Goniometer_Controller
{
    public class BaseMotor
    {
        public readonly double accuracy = 0.02; //degrees

        private MotorSocket socket;
        private int motorNumber;

        public BaseMotor(MotorSocket socket, int motorNumber)
        {
            this.socket = socket;
            this.motorNumber = motorNumber;
        }

        public void ZeroMotor()
        {
            string cmd = "pset";
            cmd += ','.Multiply(motorNumber);
            cmd += "0:";
            
            socket.Write(cmd);
        }

        #region motion commands
        public void SendAccelerationCommand(double acceleration)
        {
            string cmd = "";

            //acceleration
            cmd = "a";
            cmd += ','.Multiply(motorNumber);
            cmd += acceleration + ":";

            //average acceleration
            cmd = "aa";
            cmd += ','.Multiply(motorNumber);
            cmd += acceleration + ":";

            //deceleration
            cmd = "ad";
            cmd += ','.Multiply(motorNumber);
            cmd += acceleration + ":";

            //average deceleration
            cmd = "ada";
            cmd += ','.Multiply(motorNumber);
            cmd += acceleration + ":";
            
            socket.Write(cmd);
        }

        public void SendVelocityCommand(double velocity)
        {
            string cmd = "v";
            cmd += ','.Multiply(motorNumber);
            cmd += velocity + ":";

            socket.Write(cmd);
        }

        public void SendAngleCommand(double angle)
        {
            string cmd = "d";
            cmd += ','.Multiply(motorNumber);
            cmd += angle + ":";

            socket.Write(cmd);
        }

        public void ExecuteCommands()
        {
            string cmd = "!go";
            cmd += 'x'.Multiply(motorNumber);
            cmd += "1:";

            socket.Write(cmd);
        }

        public void EmergencyStop()
        {
            string cmd = "!k";
            cmd += 'x'.Multiply(motorNumber);
            cmd += "1:";

            socket.Write(cmd);
        }
        #endregion

        public double GetAngle()
        {
            string cmd = "!";
            cmd += motorNumber + 1; //controller is 1-indexed
            cmd += "tpe:";
            short timeout = 0;

            socket.WriteBlocking(cmd, timeout);

            string value = socket.Read();

            return Double.Parse(value);
        }
    }
}
