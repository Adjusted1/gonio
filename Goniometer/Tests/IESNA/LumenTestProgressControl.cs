using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

using Goniometer.Functions;
using Goniometer.Reports;
using Goniometer_Controller;
using Goniometer_Controller.Motors;
using Goniometer_Controller.Sensors;

namespace Goniometer
{
    public partial class LumenTestProgressControl : UserControl
    {
        private GoniometerController _controller;

        #region setup variables
        private double[] _hRange;
        private double[] _vRange;

        private double[] _hStrayRange;
        private double[] _vStrayRange;

        private double _k;
        #endregion

        #region results variables
        private ReadingsCollection _candles;
        private ReadingsCollection _strayCandles;
        #endregion

        public LumenTestProgressControl()
        {
            InitializeComponent();
        }

        public void BeginTestAsync(IMinoltaTTenController sensor, double[] hRange, double[] vRange, double[] hStrayRange, double[] vStrayRange, double k)
        {
            _hRange = hRange;
            _vRange = vRange;
            _hStrayRange = hStrayRange;
            _vStrayRange = vStrayRange;
            _k = k;

            _controller = GoniometerControllerFactory.getController();
            _controller.ProgressChanged += OnProgressChanged;

            BeginStrayTestAsync();
        }

        public void BeginStrayTestAsync()
        {
            var result = MessageBox.Show("Please ensure that the mirror is properly covered");

            _controller.RunWorkerCompleted += OnStrayLightTestFinished;
            _controller.RunAsync(_hStrayRange, _vStrayRange);
        }

        public void BeginLightTestAsync()
        {
            var result = MessageBox.Show("Please ensure that the mirror is properly exposed");

            _controller.RunWorkerCompleted += OnLightTestFinished;
            _controller.RunAsync(_hRange, _vRange);
        }

        public void CancelTestAsync()
        {
            txtStatus.Text += "Canceling\n";
            _controller.CancelAsync();
        }

        #region controller callback methods
        protected virtual void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
            txtStatus.Text += e.UserState.ToString() + "\n";

            long time = ReportUtils.TimeEstimate(_hRange.Length, _vRange.Length).Ticks * ((100 - e.ProgressPercentage) / 100);
            lblCompletionTime.Text = String.Format("{0:hh\\:mm}", new TimeSpan(time));
        }

        protected virtual void OnStrayLightTestFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            //record results
            _strayCandles = e.Result as ReadingsCollection;

            //unsubscribe
            _controller.RunWorkerCompleted -= OnStrayLightTestFinished;

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

            //if successful, start the next step
            if (_strayCandles != null)
                BeginLightTestAsync();
        }

        public event EventHandler LightTestFinished;
        protected virtual void OnLightTestFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            //record results
            _candles = e.Result as ReadingsCollection;

            //unsubscribe
            _controller.RunWorkerCompleted -= OnLightTestFinished;

            //if successful, generate report
            string reportFilepath = "";
            if (_candles != null)
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

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = chkEmail.Checked;
        }

        private string GenerateReport()
        {
            //calculate corrected values from stray
            var correctedData = ReadingsCollection.RemoveStrayLight(_candles, _strayCandles);

            //calculate lumens from corrected values
            var report = new iesna(correctedData);

            //generate report file
            string filepath = ConfigurationManager.AppSettings["reportFolder"];
            string fullpath = iesna.WriteToFile(report, filepath);
            return fullpath;
        }
    }
}
