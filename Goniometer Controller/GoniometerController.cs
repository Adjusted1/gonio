using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

using Goniometer_Controller.Motors;
using Goniometer_Controller.Sensors;

namespace Goniometer_Controller
{
    public class GoniometerController
    {
        private BackgroundWorker _worker;

        private IMinoltaTTenController _sensor;

        private double[] _hRange;
        private double[] _vRange;
        private ReadingsCollection _data = new ReadingsCollection();

        private bool _running = false;
        private bool _paused = false;

        internal GoniometerController(IMinoltaTTenController sensor)
        {
            _worker = new BackgroundWorker();
            _worker.DoWork             += DoWork;
            _worker.ProgressChanged    += OnProgressChanged;
            _worker.RunWorkerCompleted += OnRunWorkerCompleted;

            SetSensorController(sensor);
        }

        public void SetSensorController(IMinoltaTTenController sensor)
        {
            _sensor = sensor;
        }

        /// <summary>
        /// Requests termination of goniometer process
        /// </summary>
        public void CancelAsync()
        {
            _worker.CancelAsync();
        }

        public void PauseAsync()
        {
            _paused = true;
            //TODO: Pause motor movement
        }

        public void UnPauseAsync()
        {
            _paused = false;
        }

        /// <summary>
        /// Starts execution of goniometer
        /// </summary>
        public void RunAsync(double[] hRange, double[] vRange)
        {
            if (_running)
                throw new Exception("Goniometer is already running a test");

            _running = true;

            _hRange = hRange;
            _vRange = vRange;

            _worker.RunWorkerAsync();
        }

        #region worker methods
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            _worker.ReportProgress(0, "Test Started");

            for (int h = 0; h < _hRange.Length; h++)
            {
                _worker.ReportProgress((int)h / _hRange.Length, String.Format("Preparing Horizontal Angle: {0}", _hRange[h]));
                MotorController.SetHorizontalAngleAndWait(_hRange[h]);

                for (int v = 0; v < _vRange.Length; v++)
                {
                    //check for cancel
                    if (_worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    //loop if paused
                    while (_paused)
                    {
                        //while paused check for cancellation
                        Thread.Sleep(100);
                        if (_worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }

                    int progress = (int)(h / _hRange.Length) * (v / _vRange.Length);
                    _worker.ReportProgress(progress, String.Format("Preparing Vertical Angle: {0}", _vRange[v]));
                    MotorController.SetVerticalAngleAndWait(_vRange[v]);

                    _worker.ReportProgress(progress, "Taking Measurements");

                    //wait while sensor collects more information
                    Thread.Sleep(1000);

                    double r1 = 0, r2 = 0;
                    double eps = 0.2;

                    //take two readings
                    do
                    {
                        r1 = _sensor.reading;
                        Thread.Sleep(600);
                        //the sensor takes a reading every 0.5 seconds

                        r2 = _sensor.reading;
                        Thread.Sleep(600);

                    } while (r1 - r2 < eps);
                    //a valid set of readings must fall in the epsilon

                    double avg = (r1 + r2) / 2;

                    //record raw value
                    _data.Add(_hRange[h], _vRange[v], avg);
                }
            }

            _worker.ReportProgress(100, "Test Complete");

            e.Result = _data;
        }

        /// <summary>
        /// Receive updates on progress. 
        /// 
        /// e.UserState is a string with status information.
        /// </summary>
        public event ProgressChangedEventHandler ProgressChanged;
        protected virtual void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var temp = ProgressChanged;
            if (temp != null)
                temp(this, e);
        }

        /// <summary>
        /// Receive notification of completion. 
        /// 
        /// e.Cancelled indicates success/failure.
        /// e.Result contains List of Tuples(double,double,double): hAngle,vAngle,reading
        /// e.Error contains any errors that may have been encountered
        /// </summary>
        public event RunWorkerCompletedEventHandler RunWorkerCompleted;
        protected virtual void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _running = false;

            var temp = RunWorkerCompleted;
            if (temp != null)
                temp(this, e);
        }
        #endregion

        public ReadingsCollection GetResults()
        {
            if (_running)
                throw new InvalidOperationException("Progress not complete.");

            return _data;
        }
    }
}
