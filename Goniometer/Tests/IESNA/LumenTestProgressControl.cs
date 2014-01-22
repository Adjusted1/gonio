using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

using Goniometer.Functions;
using Goniometer.Reports;
using Goniometer_Controller;
using Goniometer_Controller.Models;
using Goniometer_Controller.Sensors;
using Goniometer_Controller.Functions;

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

        private double _kCal;
        private double _kTheta;
        private double _distance;

        private List<BaseSensor> _sensors;
        #endregion

        #region results variables
        private MeasurementCollection _lightData;
        private MeasurementCollection _strayData;
        #endregion

        #region public variables
        public bool EmailNotifications
        {
            get { return chkEmail.Checked; }
            set { chkEmail.Checked = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string DataFolder
        {
            get { return lblDataFolder.Text; }
            set { lblDataFolder.Text = value; }
        }

        #region lamp information
        public string TestName { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int NumberofLamps { get; set; }

        public string Wattage { get; set; }

        //lumonous opening dimensions
        public string OpeningLength { get; set; }

        public string OpeningWidth { get; set; }

        public string OpeningHeight { get; set; }
        #endregion
        #endregion

        public LumenTestProgressControl()
        {
            InitializeComponent();
        }

        #region public methods
        public void BeginTestAsync(IEnumerable<BaseSensor> sensors, 
            double[] hRange, double[] vRange, 
            double[] hStrayRange, double[] vStrayRange, 
            double kCal, double kTheta, double distance)
        {
            _hRange = hRange;
            _vRange = vRange;
            _hStrayRange = hStrayRange;
            _vStrayRange = vStrayRange;

            _kCal = kCal;
            _kTheta = kTheta;
            _distance = distance;

            _sensors = sensors.ToList();

            //setup workers
            SetupStandardTest();
            SetupStrayTest();

            //schedule the stray test when the standard is finished
            LightTestFinished += new EventHandler((o, e) => BeginStrayTestAsync());

            //schedule test finalization when the stray test is finished
            StrayTestFinished += new EventHandler((o, e) => FinalizeTest());

            //start with stray test
            BeginStandardTestAsync();

            _startTime = DateTime.Now;
            timerElapsed.Enabled = true;
        }

        public void PauseTestAsync()
        {
            txtStatus.AppendText("Pausing\n");

            if (_strayWorker != null)
                _strayWorker.PauseAsync();

            if (_lightWorker != null)
                _lightWorker.PauseAsync();
        }

        public void UnpauseTestAsync()
        {
            txtStatus.AppendText("Unpausing\n");

            if (_strayWorker != null)
                _strayWorker.UnPauseAsync();

            if (_lightWorker != null)
                _lightWorker.UnPauseAsync();
        }

        public void CancelTestAsync()
        {
            txtStatus.AppendText("Cancelling\n");

            if (_strayWorker != null)
                _strayWorker.CancelAsync();

            if (_lightWorker != null)
                _lightWorker.CancelAsync();
        }

        public event EventHandler TestCompleted;
        #endregion

        #region stray lumen test
        private void SetupStrayTest()
        {
            _strayWorker = new GoniometerWorker(_hStrayRange, _vStrayRange, _sensors);
            _strayWorker.ProgressChanged += OnProgressChanged;
            _strayWorker.RunWorkerCompleted += OnStrayLightTestFinished;
            _strayWorker.Error += OnError;
            _strayWorker.MeasurementTaken += OnMeasurementTaken;
        }

        private void BeginStrayTestAsync()
        {
            var result = MessageBox.Show("Please ensure that the mirror is properly covered");
            _strayWorker.RunAsync();
        }

        public event EventHandler StrayTestFinished;
        private void OnStrayLightTestFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            //unsubscribe
            _strayWorker.ProgressChanged -= OnProgressChanged;
            _strayWorker.RunWorkerCompleted -= OnStrayLightTestFinished;

            //check status
            if (e.Cancelled)
            {
                //inform user
                if (chkEmail.Checked)
                {
                    string subject = "Goniometer Lumen Test Canceled";
                    string body = "The Goniometer Lumen Test has been canceled.\n\nProgress:\n" + txtStatus.Text;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
            }
            else if (e.Error != null)
            {
                SimpleLogger.Logging.WriteToLog(e.Error.Message);

                //inform user
                if (chkEmail.Checked)
                {
                    string subject = "Goniometer Lumen Test Failed";
                    string body = "The Goniometer Lumen Test has failed with the following error:\n\n" + e.Error.Message;
                    body += "\n\nStack:\n\n" + e.Error.StackTrace;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
            }
            else

            //record results
            _strayData = e.Result as MeasurementCollection;

            //inform user
            if (chkEmail.Checked)
            {
                string subject = "Goniometer Lumen Test Requires Attention!";
                string body = "The Goniometer Lumen Test requires your input to continue";
                ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
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
            _lightWorker = new GoniometerWorker(_hRange, _vRange, _sensors);
            _lightWorker.ProgressChanged += OnProgressChanged;
            _lightWorker.RunWorkerCompleted += OnLightTestFinished;
            _lightWorker.Error += OnError;
            _lightWorker.MeasurementTaken += OnMeasurementTaken;
        }

        private void BeginStandardTestAsync()
        {
            var result = MessageBox.Show("Please ensure that the mirror is properly exposed");
            _lightWorker.RunAsync();
        }

        public event EventHandler LightTestFinished; 
        protected virtual void OnLightTestFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            //unsubscribe
            _lightWorker.ProgressChanged -= OnProgressChanged;
            _lightWorker.RunWorkerCompleted -= OnLightTestFinished;

            if (e.Cancelled)
            {
                if (chkEmail.Checked)
                {
                    string subject = "Goniometer Lumen Test Canceled";
                    string body = "The Goniometer Lumen Test has been canceled.\n\nProgress:\n" + txtStatus.Text;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
            }
            else if (e.Error != null)
            {
                SimpleLogger.Logging.WriteToLog(e.Error.Message);

                if (chkEmail.Checked)
                {
                    string subject = "Goniometer Lumen Test Failed";
                    string body = "The Goniometer Lumen Test has failed with the following error:\n\n" + e.Error.Message;
                    body += "\n\nStack:\n\n" + e.Error.StackTrace;
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
                }
            }

            //record results
            _lightData = e.Result as MeasurementCollection;

            //inform user
            if (chkEmail.Checked)
            {
                string subject = "Goniometer Lumen Test Requires Attention!";
                string body = "The Goniometer Lumen Test requires your input to continue";
                ReportUtils.EmailResults(subject, body, txtEmail.Text, null);
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
            string message = String.Empty;

            var measurementExc = e.Exception as InvalidMeasurementException;
            if (measurementExc != null && measurementExc.Measurement != null)
            {
                var measurement = measurementExc.Measurement;
                message = String.Format("Measurement Error Occured. Stop Test (Abort), Retest (Retry), or Skip Reading (Ignore)\nMeasurement:\n{0}:{1}", measurement.Key, measurement.Value);
            }
            else
            {
                message = String.Format("Error Occured. Stop Test (Abort), Retest (Retry), or Skip Reading (Ignore)?");
            }

            var result = MessageBox.Show(message, "Gonio Error", MessageBoxButtons.AbortRetryIgnore);

            if (result == DialogResult.Abort)
            {
                e.Stop = true;
                e.Skip = true;
            }
            else if (result == DialogResult.Retry)
            {
                e.Stop = false;
                e.Skip = false;
            }
            else //ignore
            {
                e.Stop = false;
                e.Skip = true;
            }
        }

        /// <summary>
        /// Call to advance progress bar
        /// </summary>
        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
            txtStatus.AppendText(String.Format("{0:yyyy-MM-dd-HH:mm:ss} - {1}\n", DateTime.Now, e.UserState));

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

            //if successful, generate report
            string reportFilepath = "";
            if (_lightData != null && _strayData != null)
            {
                reportFilepath = GenerateReport();

                if (chkEmail.Checked)
                {
                    string subject = "Goniometer Lumen Test Completed";
                    string body = "The Goniometer Lumen Test has completed";
                    Attachment attachment = new Attachment(reportFilepath);
                    ReportUtils.EmailResults(subject, body, txtEmail.Text, attachment);
                }
            }

            var temp = TestCompleted;
            if (TestCompleted != null)
                TestCompleted(this, null);
        }

        private string GenerateReport()
        {
            //convert any candle values to candelas
            _lightData = LightMath.PrepareLuminousMeasurements(_lightData, _distance, _kCal, _kTheta);
            _strayData = LightMath.PrepareLuminousMeasurements(_strayData, _distance, _kCal, _kTheta);

            //calculate corrected values from stray
            var correctedData = _lightData.SubstractStray(_strayData);

            //calculate lumens from corrected values
            var report = new iesna(correctedData);
            report.TestName     = this.TestName;
            report.Manufacturer = this.Manufacturer;
            report.Model        = this.Model;
            report.Wattage      = this.Wattage;
            report.Length       = this.OpeningLength;
            report.Width        = this.OpeningWidth;
            report.Height       = this.OpeningHeight;
            report.IssueDate    = DateTime.Now;

            //generate report file
            string fullpath = iesna.WriteToFile(report, DataFolder);
            return fullpath;
        }

        private void OnMeasurementTaken(object sender, GoniometerWorker.MeasurementEventArgs e)
        {
            var measurements = e.Measurements;

            //check directory existance
            if (!Directory.Exists(this.DataFolder))
                Directory.CreateDirectory(this.DataFolder);

            //write out recorded measurement immediately
            string filePath = String.Format("{0}/{1:yyyyMMdd} {2} {3}_raw.csv", this.DataFolder, DateTime.Now, this.TestName, this.Model);
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                foreach (var measurement in measurements)
                {
                    sw.WriteLine(MeasurementBase.ToCSV(measurement));
                }

                sw.Flush();
                sw.Close();
            }
        }
    }
}
