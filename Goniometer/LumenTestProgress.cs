using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Goniometer.Functions;
using Goniometer.Reports;

using Goniometer_Controller;
using System.Net.Mail;

namespace Goniometer
{
    public partial class LumenTestProgress : Form
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
        private List<Tuple<double, double, double>> _candles;
        private List<Tuple<double, double, double>> _strayCandles;
        #endregion

        public LumenTestProgress(double[] hRange, double[] vRange, double[] hStrayRange, double[] vStrayRange, double k)
        {
            InitializeComponent();

            _hRange = hRange;
            _vRange = vRange;
            _hStrayRange = hStrayRange;
            _vStrayRange = vStrayRange;
            _k = k;

            _controller = new GoniometerController();
            _controller.ProgressChanged += OnProgressChanged;
        }

        private void LumenTestProgress_Load(object sender, EventArgs e)
        {
            //start test
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
            _strayCandles = e.Result as List<Tuple<double, double, double>>;

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

        protected virtual void OnLightTestFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            //record results
            _candles = e.Result as List<Tuple<double, double, double>>;

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
            this.Close();
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnCancel.Text = "Canceling";
            txtStatus.Text += "Canceling\n";

            _controller.CancelAsync();
        }

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = chkEmail.Checked;
        }

        private string GenerateReport()
        {
            //calculate corrected values from stray and offset
            var correctedData = new List<Tuple<double, double, double>>();
            foreach (var item in _candles)
            {
                double correctedValue = (item.Item3 - GetStrayLight(item.Item1, item.Item2)) * _k;
                correctedData.Add(Tuple.Create(item.Item1, item.Item2, correctedValue));
            }

            //calculate lumens from corrected values
            double lumens =  LightMath.CalculateLumensByHorizontalAverage(correctedData);

            var report = new iesna
            {
                data = correctedData,
                lumens = lumens,
            };

            //generate report file
            string filepath = ConfigurationManager.AppSettings["reportFolder"];
            string fullpath = iesna.WriteToFile(report, filepath);
            return fullpath;
        }

        private double GetStrayLight(double hAngle, double vAngle)
        {
            //try for an exact match:
            var match = _strayCandles.Find((item) => item.Item1 == hAngle & item.Item2 == vAngle);
            if (match != null)
                return match.Item3;

            //if any horizontal angles are valid, use them for linear extrapoliation
            var horizontalmatches = _strayCandles.FindAll((item) => item.Item1 == hAngle);
            if (horizontalmatches != null)
            {
                //split points into those above and below vAngle, already proved there is not value at exact vAngle
                var above = horizontalmatches.Where((item) => item.Item2 > vAngle).ToList();
                var below = horizontalmatches.Where((item) => item.Item2 < vAngle).ToList();

                if (above.Count == 0)
                {
                    //all values are below, return closest one
                    return below.OrderByDescending((item) => item.Item2).First().Item3;
                }
                else if (below.Count == 0)
                {
                    //all values are above, return closest one
                    return above.OrderBy((item) => item.Item2).First().Item3;
                }
                else
                {
                    var top = below.OrderByDescending((item) => item.Item2).First();
                    var bot = above.OrderBy((item) => item.Item2).First();

                    return LightMath.LinearExtrapolation(Tuple.Create(top.Item2, top.Item3), Tuple.Create(top.Item2, top.Item3), vAngle);
                }
            }

            //find 3 close values and 
            throw new NotImplementedException();
        }
    }
}
