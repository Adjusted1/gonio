using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

using Goniometer_Controller.Models;
using Goniometer_Controller.Motors;
using Goniometer_Controller.Sensors;

namespace Goniometer_Controller
{
    public class GoniometerWorker
    {
        private BackgroundWorker _worker;

        private MinoltaBaseSensor _sensor;

        private double[] _hRange;
        private double[] _vRange;
        private MeasurementCollection _data = new MeasurementCollection();
        private DateTime _startTime;
        private DateTime _stopTime;

        private bool _running = false;
        private bool _paused = false;

        public GoniometerWorker(double[] hRange, double[] vRange, MinoltaBaseSensor sensor)
        {
            _hRange = hRange;
            _vRange = vRange;

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork             += DoWork;
            _worker.ProgressChanged    += OnProgressChanged;
            _worker.RunWorkerCompleted += OnRunWorkerCompleted;

            _sensor = sensor;
        }

        /// <summary>
        /// Requests termination of goniometer process
        /// </summary>
        public void CancelAsync()
        {
            _worker.CancelAsync();
        }

        /// <summary>
        /// Requests temporary pause of goniometer process
        /// </summary>
        public void PauseAsync()
        {
            _paused = true;
            //TODO: Pause motor movement
        }

        /// <summary>
        /// Resumes temporary pause of goniometer process
        /// </summary>
        public void UnPauseAsync()
        {
            _paused = false;
        }

        /// <summary>
        /// Starts execution of goniometer
        /// </summary>
        public void RunAsync()
        {
            if (_running)
                throw new Exception("Goniometer is already running a test");

            _startTime = DateTime.Now;
            _running = true;

            _worker.RunWorkerAsync();
        }

        #region worker methods
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            _worker.ReportProgress(0, "Test Started");

            for (int h = 0; h < _hRange.Length; h++)
            {
                //update progress, move horizontal motor
                _worker.ReportProgress((int)h / _hRange.Length, String.Format("Preparing Horizontal Angle: {0}", _hRange[h]));
                MotorController.SetHorizontalAngleAndWait(_hRange[h]);

                for (int v = 0; v < _vRange.Length; v++)
                {
                    try
                    {
                        //loop if paused
                        do
                        {
                            //check for cancel
                            Thread.Sleep(100);
                            if (_worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }

                        } while (_paused);

                        //update progress, move vertical arm
                        int progress = (int)(h + 1 / _hRange.Length) * (v / _vRange.Length);
                        _worker.ReportProgress(progress, String.Format("Preparing Vertical Angle: {0}", _vRange[v]));
                        MotorController.SetVerticalAngleAndWait(_vRange[v]);

                        //collect and validate measurements before continuing
                        _worker.ReportProgress(progress, "Taking Measurements");
                        var measurements = _sensor.CollectMeasurements(_hRange[h], _vRange[v]);

                        //validate measurements
                        var measurement = measurements.FirstOrDefault(m => m.key == MeasurementKeys.IlluminanceEv);
                        if (measurement != null && measurement.value < 0.01)
                        {
                            var args = new GonioErrorEventArgs();
                            OnError(this, args);

                            if (args.stop)
                            {
                                //halt test
                                e.Cancel = true;
                                return;
                            }
                            else if (!args.skip)
                            {
                                //go back one step and start over
                                h--;
                                continue;
                            }
                        }

                        //measurements validated, add to collection
                        _data.AddRange(measurements);

                    }
                    catch (Exception ex)
                    {
                        var args = new GonioErrorEventArgs();
                        OnError(this, args);
                    }
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
            _stopTime = DateTime.Now;

            var temp = RunWorkerCompleted;
            if (temp != null)
                temp(this, e);
        }

        public event EventHandler<GonioErrorEventArgs> Error;
        protected virtual void OnError(object sender, GonioErrorEventArgs e)
        {
            var temp = Error;
            if (temp != null)
                temp(this, e);
        }
        #endregion

        public MeasurementCollection GetResults()
        {
            if (_running)
                throw new InvalidOperationException("Progress not complete.");

            return _data;
        }

        public class GonioErrorEventArgs : EventArgs
        {
            /// <summary>
            /// indicates that failure is unrecoverable and the test should halt
            /// set to false if test should continue
            /// </summary>
            public bool stop = true;

            /// <summary>
            /// indicates that failure is recoverable and the test should continue at next datapoint
            /// set to true if datapoint should recollect
            /// </summary>
            public bool skip = true;

            public GonioErrorEventArgs() : base()
            {
            
            }
        }
    }
}
