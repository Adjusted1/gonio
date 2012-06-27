﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Goniometer_Controller.Motors
{
    public class BaseMotor : INotifyPropertyChanged
    {
        public readonly double accuracy = 0.02; //degrees

        private object _lock = new object();
        private MotorSocket _socket;

        private int _axisNumber;
        private Timer _updateTimer;

        private double _angle;
        public double angle
        {
            get
            {
                return _angle;
            }
            private set
            {
                double oldValue = _angle;
                if (oldValue != value)
                {
                    this._angle = value;
                    NotifyPropertyChanged("angle");
                }
            }
        }

        public BaseMotor(MotorSocket socket, int axisNumber)
        {
            this._socket = socket;
            this._axisNumber = axisNumber;
            this._updateTimer = new Timer(UpdateAngle, null, 0, 1000);
        }

        public void ZeroMotor()
        {
            lock (_lock)
            {
                string cmd = "pset";
                cmd += ','.Multiply(_axisNumber);
                cmd += "0:";

                _socket.Write(cmd); 
            }
        }

        #region motion commands
        public void SendAccelerationCommand(double acceleration)
        {
            lock (_lock)
            {
                string cmd = "";

                //acceleration
                cmd = "a";
                cmd += ','.Multiply(_axisNumber);
                cmd += acceleration + ":";

                //average acceleration
                cmd = "aa";
                cmd += ','.Multiply(_axisNumber);
                cmd += acceleration + ":";

                //deceleration
                cmd = "ad";
                cmd += ','.Multiply(_axisNumber);
                cmd += acceleration + ":";

                //average deceleration
                cmd = "ada";
                cmd += ','.Multiply(_axisNumber);
                cmd += acceleration + ":";

                _socket.Write(cmd); 
            }
        }

        public void SendVelocityCommand(double velocity)
        {
            lock (_lock)
            {
                string cmd = "v";
                cmd += ','.Multiply(_axisNumber);
                cmd += velocity + ":";

                _socket.Write(cmd); 
            }
        }

        public void SendAngleCommand(double angle)
        {
            lock (_lock)
            {
                string cmd = "d";
                cmd += ','.Multiply(_axisNumber);
                cmd += angle + ":";

                _socket.Write(cmd); 
            }
        }

        public void SendCommand(string cmd, string data)
        {
            lock (_lock)
            {
                cmd += ','.Multiply(_axisNumber);
                cmd += data + ":";

                _socket.Write(cmd); 
            }
        }

        public void ExecuteCommands()
        {
            lock (_lock)
            {
                string cmd = "!go";
                cmd += 'x'.Multiply(_axisNumber);
                cmd += "1:";

                _socket.Write(cmd); 
            }
        }

        public void EmergencyStop()
        {
            lock (_lock)
            {
                string cmd = "!k";
                cmd += 'x'.Multiply(_axisNumber);
                cmd += "1:";

                _socket.Write(cmd); 
            }
        }
        #endregion
        
        private void UpdateAngle(object state)
        {
            lock (_lock)
            {
                string cmd = "!";
                cmd += _axisNumber + 1; //controller is 1-indexed
                cmd += "tpe:";

                _socket.Write(cmd);

                //wait 1 second
                Thread.Sleep(new TimeSpan(0, 0, 1));

                string value = _socket.Read();
                this.angle = Double.Parse(value); 
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            var notify = PropertyChanged;
            if (notify != null)
            {
                notify(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
