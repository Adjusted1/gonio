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
    public class MinoltaTTenController : INotifyPropertyChanged, IDisposable
    {
        private object _sensorLock = new object();
        private MinoltaTTenSensor _sensor;
        private int _refreshRate = 100; //milliseconds

        private double _reading;
        private string _status;
        private Timer _updateTimer;

        #region construction
        internal MinoltaTTenController(string portName)
        {
            SerialPort port = new SerialPort(portName);
            port.BaudRate = 9600;
            port.DataBits = 7;
            port.StopBits = StopBits.One;
            port.Parity = Parity.Even;

            if (port.IsOpen)
            {
                status = "Closing Port";
                port.Close();
            }

            status = "Opening Port";
            port.Open();

            _sensor = new MinoltaTTenSensor(port);

            status = "Connecting with Device";
            _sensor.Connect();

            status = "Enabling Device";
            _sensor.Run();

            status = "Starting Measurement";
            _updateTimer = new Timer(UpdateReading, this, 0, _refreshRate);

            status = "Measuring";
        }
        #endregion

        #region IDisposable Members
        private bool _disposed = false;
        public void Dispose()
        {
            lock (_sensorLock)
            {
                if (_updateTimer != null)
                    _updateTimer.Dispose();

                if (_sensor != null)
                    _sensor.Disconnect();
            }

            _disposed = false;
        }
        #endregion

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

        public string status
        {
            get
            {
                return this._status;
            }
            set
            {
                if (_status != value)
                {
                    this._status = value;
                    NotifyPropertyChanged("status");
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

        private void UpdateReading(object state)
        {
            if (Monitor.TryEnter(_sensorLock))
            {
                try
                {
                    if (_disposed)
                        return;

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
