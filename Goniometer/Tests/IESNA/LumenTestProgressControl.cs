using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

using Goniometer.Functions;
using Goniometer.Reports;
using Goniometer_Controller;
using Goniometer_Controller.Models;
using Goniometer_Controller.Sensors;

namespace Goniometer
{
    /* Standard Lumen Test
     * 
     * Order:
     *    Light test -> Stray test
     * 
     * 
     * 
     * */

    public partial class LumenTestProgressControl : UserControl
    {
        private GoniometerWorker _lightWorker;
        private GoniometerWorker _strayWorker;

        private DateTime _startTime;

        #region setup variables
        private double[] _hRange;
        private double[] _vRange;

        private double[] _hStrayRange;
        private double[] _vStrayRange;

        private double _k;

        private MinoltaBaseSensor _sensor;
        #endregion

        #region results variables
        private MeasurementCollection _lightData;
        private MeasurementCollection _strayData;
        #endregion

        public LumenTestProgressControl()
        {
            InitializeComponent();
        }

        #region public methods
        public void BeginTestAsync(MinoltaBaseSensor sensor, double[] hRange, double[] vRange, double[] hStrayRange, double[] vStrayRange, double k)
        {
            _hRange = hRange;
            _vRange = vRange;
            _hStrayRange = hStrayRange;
            _vStrayRange = vStrayRange;
            _k = k;

            _sensor = sensor;

            //setup workers
            SetupStrayTest();
            SetupStandardTest();

            //schedule the standard test when the stray is finished
            StrayTestFinished += new EventHandler((o, e) => BeginStandardTestAsync());

            //schedule test finalization when the light test is finished
            LightTestFinished += new EventHandler((o, e) => FinalizeTest());

            //start with stray test
            BeginStrayTestAsync();

            _startTime = DateTime.Now;
            timerElapsed.Enabled = true;
        }

        public void PauseTestAsync()
        {
            txtStatus.Text += "Pausing\n";

            if (_strayWorker != null)
                _strayWorker.PauseAsync();

            if (_lightWorker != null)
                _lightWorker.PauseAsync();
        }

        public void UnpauseTestAsync()
        {
            txtStatus.Text += "Unpausing\n";

            if (_strayWorker != null)
                _strayWorker.UnPauseAsync();

            if (_lightWorker != null)
                _lightWorker.UnPauseAsync();
        }

        public void CancelTestAsync()
        {
            txtStatus.Text += "Cancelling\n";

            if (_strayWorker != null)
                _strayWorker.CancelAsync();

            if (_lightWorker != null)
                _lightWorker.CancelAsync();
        }
        #endregion

        #region stray lumen test
        private void SetupStrayTest()
        {
            _strayWorker = new GoniometerWorker(_hStrayRange, _vStrayRange, _sensor);
            _strayWorker.ProgressChanged += OnProgressChanged;
            _strayWorker.RunWorkerCompleted += OnStrayLightTestFinished;
            _strayWorker.Error += OnError;
        }

        private void BeginStrayTestAsync()
        {
            var result = MessageBox.Show("Please ensure that the mirror is properly covered");
            _strayWorker.RunAsync();
        }

        public event EventHandler StrayTestFinished;
        private void OnStrayLightTestFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            //record results
            _strayData = e.Result as MeasurementCollection;

            //unsubscribe
            _strayWorker.ProgressChanged -= OnProgressChanged;
            _strayWorker.RunWorkerCompleted -= OnStrayLightTestFinished;

            //inform user
            if (chkEmail.Checked)
            {
                if (e.Cancelled)
                {
                    string subject = "Goniometer Lumen Test Canceled";
                    string body = "The Goniometer Lumen Test has been canceled.\n\nProgress:\n" + txtStatus.Text;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
                else if (e.Error != null)
                {
                    SimpleLogger.Logging.WriteToLog(e.Error.Message);

                    string subject = "Goniometer Lumen Test Failed";
                    string body = "The Goniometer Lumen Test has failed with the following error:\n\n" + e.Error.Message;
                    body += "\n\nStack:\n\n" + e.Error.StackTrace;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
                else
                {
                    var data = e.Result as Tuple<double, double, double>;

                    string subject = "Goniometer Lumen Test Requires Attention!";
                    string body = "The Goniometer Lumen Test requires your input to continue";
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
            }

            //test completed
            var notify = StrayTestFinished;
            if (notify != null)
                notify(this, null);
        }
        #endregion

        #region standard lumen test
        private void SetupStandardTest()
        {
            _lightWorker = new GoniometerWorker(_hRange, _vRange, _sensor);
            _lightWorker.ProgressChanged += OnProgressChanged;
            _lightWorker.RunWorkerCompleted += OnLightTestFinished;
            _lightWorker.Error += OnError;
        }

        private void BeginStandardTestAsync()
        {
            var result = MessageBox.Show("Please ensure that the mirror is properly exposed");
            _lightWorker.RunAsync();
        }

        public event EventHandler LightTestFinished; 
        protected virtual void OnLightTestFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            //record results
            _lightData = e.Result as MeasurementCollection;

            //unsubscribe
            _lightWorker.ProgressChanged -= OnProgressChanged;
            _lightWorker.RunWorkerCompleted -= OnLightTestFinished;

            //if successful, generate report
            string reportFilepath = "";
            if (_lightData != null)
                reportFilepath = GenerateReport();

            if (chkEmail.Checked)
            {
                if (e.Cancelled)
                {
                    string subject = "Goniometer Lumen Test Canceled";
                    string body = "The Goniometer Lumen Test has been canceled.\n\nProgress:\n" + txtStatus.Text;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
                else if (e.Error != null)
                {
                    SimpleLogger.Logging.WriteToLog(e.Error.Message);

                    string subject = "Goniometer Lumen Test Failed";
                    string body = "The Goniometer Lumen Test has failed with the following error:\n\n" + e.Error.Message;
                    body += "\n\nStack:\n\n" + e.Error.StackTrace;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
                else
                {
                    var data = e.Result as Tuple<double, double, double>;

                    string subject = "Goniometer Lumen Test Completed";
                    string body = "The Goniometer Lumen Test has completed";
                    Attachment attachment = new Attachment(reportFilepath);
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, attachment);
                }
            }

            //test completed
            var notify = LightTestFinished;
            if (notify != null)
                notify(this, null);
        }
        #endregion

        #region interface methods
        private void OnError(object sender, GoniometerWorker.GonioErrorEventArgs e)
        {
            e.stop = true;
            e.skip = false;
        }

        /// <summary>
        /// Call to advance progress bar
        /// </summary>
        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
            txtStatus.Text += String.Format("{0:yyyy-MM-dd-HH:mm:ss} - {1}\n", DateTime.Now, e.UserState);

            long time = ReportUtils.TimeEstimate(_hRange.Length, _vRange.Length).Ticks * ((100 - e.ProgressPercentage) / 100);
            lblCompletionTime.Text = String.Format("{0:hh\\:mm\\:ss}", new TimeSpan(time));
        }

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = chkEmail.Checked;
        }

        private void timerElapsed_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = _startTime - DateTime.Now;
            lblElapsed.Text = String.Format("{0:hh\\:mm\\:ss}", elapsed);
        }
        #endregion

        private void FinalizeTest()
        {
            timerElapsed.Enabled = false;
            progressbar.Value = progressbar.Maximum;

            GenerateReport();
            WriteRawData();
        }

        private string GenerateReport()
        {
            //calculate corrected values from stray
            var correctedData = CandlePowerMeasurement.RemoveStrayLight(_lightData, _strayData);

            //calculate lumens from corrected values
            var report = new iesna(correctedData);

            //generate report file
            string filepath = ConfigurationManager.AppSettings["reportFolder"];
            string fullpath = iesna.WriteToFile(report, filepath);
            return fullpath;
        }

        private void WriteRawData()
        {
            DateTime now = DateTime.Now;
            string filepath = ConfigurationManager.AppSettings["reportFolder"];

            string standard_fullpath = filepath + String.Format("//raw_standard_{0:yyyyMMddHHmmss}.csv", now);
            using (FileStream fs = new FileStream(standard_fullpath, FileMode.CreateNew))
            using (StringWriter sw = new StringWriter())
            {
                sw.Write(_lightData.GetRaw());
            }

            string stray_fullpath    = filepath + String.Format("//raw_stray_{0:yyyyMMddHHmmss}.csv",    now);
            using (FileStream fs = new FileStream(stray_fullpath, FileMode.CreateNew))
            using (StringWriter sw = new StringWriter())
            {
                sw.Write(_strayData.GetRaw());
            }
        }

        
    }
}
