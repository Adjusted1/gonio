using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

using Goniometer.Functions;

using Goniometer_Controller.Motors;
using Goniometer_Controller.Sensors;

namespace Goniometer
{
    public partial class TestProgress : Form
    {
        private double[] _vRange;
        private double[] _hRange;

        private MotorController _motor;
        private MinoltaTTenController _sensor;

        private BackgroundWorker _worker;

        public TestProgress(double[] hRange, double[] vRange)
        {
            InitializeComponent();

            _hRange = hRange;
            _vRange = vRange;
        }

        private void TestProgress_Load(object sender, EventArgs e)
        {
            _motor = MotorControllerFactory.getMotorController();
            _sensor = MinoltaTTenControllerFactory.GetSensorController();

            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
            _worker.ProgressChanged += new ProgressChangedEventHandler(_worker_ProgressChanged);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);

            _worker.RunWorkerAsync();
        }

        #region worker methods
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<Tuple<double, double, double>> data = new List<Tuple<double, double, double>>();

                _worker.ReportProgress(0, "Test Started");

                for (int h = 0; h < _hRange.Length; h++)
                {
                    _worker.ReportProgress((int)h / _hRange.Length, String.Format("Preparing Horizontal Angle: {0}", _hRange[h]));
                    _motor.SetHorizontalAngleAndWait(_hRange[h]);

                    for (int v = 0; v < _vRange.Length; v++)
                    {
                        if (_worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        int progress = (int)(h / _hRange.Length) * (v / _vRange.Length);
                        _worker.ReportProgress(progress, String.Format("Preparing Vertical Angle: {0}", _vRange[v]));
                        _motor.SetVerticalAngleAndWait(_vRange[v]);

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
                        data.Add(new Tuple<double,double,double>(_hRange[h], _vRange[v], avg));
                    }
                }

                _worker.ReportProgress(100, "Test Complete");

                e.Result = data;
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                SimpleLogger.Logging.WriteToLog(ex.Message);
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
            txtStatus.Text += e.UserState.ToString() + "\n";

            long time = ReportUtils.TimeEstimate(_hRange.Length, _vRange.Length).Ticks * ((100 - e.ProgressPercentage) / 100);
            lblCompletionTime.Text = String.Format("{0:hh\\:mm}", new TimeSpan(time));
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkEmail.Checked)
            {
                if (e.Cancelled)
                {
                    string subject = "Goniometer Test Canceled";
                    string body = "The Goniometer Test has been canceled.\n\nProgress:\n" + txtStatus.Text;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
                else
                {
                    var data = e.Result as Tuple<double, double, double>;


                    string subject = "Goniometer Test Completed";
                    string body = "The Goniometer Test has completed";
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnCancel.Text = "Canceling";
            txtStatus.Text += "Canceling\n";

            _worker.CancelAsync();
        }
    }
}
