using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

using SimpleLogger;

namespace Goniometer_Controller.Sensors
{
    public class MinoltaTTenController : INotifyPropertyChanged
    {
        private object _sensorLock = new object();
        private MinoltaTTenSensor _sensor;
        private int _refreshRate = 100; //milliseconds

        private double _reading;
        private Timer _updateTimer;

        internal MinoltaTTenController(string portName)
        {
            SerialPort port = new SerialPort(portName);
            port.BaudRate = 9600;
            port.DataBits = 7;
            port.StopBits = StopBits.One;
            port.Parity = Parity.Even;

            if (port.IsOpen)
                port.Close();

            port.Open();

            _sensor = new MinoltaTTenSensor(port);

            _sensor.Connect();
            _sensor.Run();

            _updateTimer = new Timer(UpdateReading, this, 0, _refreshRate);
        }

        public double reading
        {
            get
            {
                return this._reading;
            }
            set
            {
                if (_reading != value)
                {
                    this._reading = value;
                    NotifyPropertyChanged("reading");
                }
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

        public bool continuousRead = false;
        private void UpdateReading(object state)
        {
            if (!continuousRead)
                return;

            if (Monitor.TryEnter(_sensorLock))
            {
                try
                {
                    reading = _sensor.Read();
                }
                catch (Exception ex)
                {
                    Logging.WriteToLog(ex.Message);
                }
                finally
                {
                    Monitor.Exit(_sensorLock);
                }
            }
        }
    }
}
