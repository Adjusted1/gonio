using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer.Functions;
using Goniometer_Controller.Sensors;

namespace Goniometer
{
    public partial class LumenTestSetupControl : UserControl, INotifyPropertyChanged
    {
        public LumenTestSetupControl()
        {
            InitializeComponent();
        }

        #region public values
        public MinoltaBaseSensor Sensor
        {
            get { return controlSensorSetup.Sensor; }
        }

        public string DataFolder
        {
            get { return txtDataFolder.Text; }
        }

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

        public string TestNumber
        {
            get { return txtTestNumber.Text; }
        }

        public string Manufacturer
        {
            get { return txtManufacturer.Text; }
        }

        public int NumberOfLamps
        {
            get { return Int32.Parse(txtNumberOfLamps.Text); }
        }

        public double HorizontalResolution
        {
            get
            {
                double value;
                if (Double.TryParse(txtHorizontalResolution.Text, out value))
                    return value;
                else
                    return 0;
            }
        }

        public double HorizontalStrayResolution
        {
            get
            {
                double value;
                if (Double.TryParse(txtHorizontalStrayResolution.Text, out value))
                    return value;
                else
                    return 0;
            }
        }

        public double VerticalResolution
        {
            get
            {
                double value;
                if (Double.TryParse(txtVerticalResolution.Text, out value))
                    return value;
                else
                    return 0;
            }
        }

        public double VerticalStrayResolution
        {
            get
            {
                double value;
                if (Double.TryParse(txtVerticalStrayResolution.Text, out value))
                    return value;
                else
                    return 0;
            }
        }

        public VerticalSymmetryEnum VerticalSymmetry
        {
            get
            {
                if (radVerticalTop.Checked)
                    return VerticalSymmetryEnum.TopOnly;
                else if (radVerticalBottom.Checked)
                    return VerticalSymmetryEnum.BottomOnly;

                return VerticalSymmetryEnum.Full;
            }
        }

        public HorizontalSymmetryEnum HorizontalSymmetry
        {
            get
            {
                if (radHorizontalFull.Checked)
                    return HorizontalSymmetryEnum.Full;
                else if (radHorizontalHalf.Checked)
                    return HorizontalSymmetryEnum.Half;
                else if (radHorizontalQuarter.Checked)
                    return HorizontalSymmetryEnum.Quarter;
                    
                return HorizontalSymmetryEnum.Single;
            }
        }
        #endregion

        #region range calculations
        public double[] CalculateHorizontalRange()
        {
            return CalculateHorizontalRange(HorizontalResolution);
        }

        public double[] CalculateStrayHorizontalRange()
        {
            return CalculateHorizontalRange(HorizontalStrayResolution);
        }

        private double[] CalculateHorizontalRange(double resolution)
        {
            int hRange = 0;  //total range in degrees
            switch(HorizontalSymmetry)
            {
                case HorizontalSymmetryEnum.Full:
                    hRange = 360;
                    break;

                case HorizontalSymmetryEnum.Half:
                    hRange = 180;
                    break;

                case HorizontalSymmetryEnum.Quarter:
                    hRange = 90;
                    break;

                case HorizontalSymmetryEnum.Single:
                    return new double[] { 0 };
            }

            if (resolution <= 0 || resolution > hRange)
                return new double[] { 0, hRange };

            return ReportUtils.Range(resolution, 0, hRange);
        }

        public double[] CalculateVerticalRange()
        {
            return CalculateVerticalRange(VerticalResolution);
        }

        public double[] CalculateStrayVerticalRange()
        {
            return CalculateVerticalRange(VerticalStrayResolution);
        }
        private double[] CalculateVerticalRange(double resolution)
        {
            int vRangeStart = 0;     //start of range in degrees
            int vRangeStop = 180;     //stop of range in degrees

            if (VerticalSymmetry == VerticalSymmetryEnum.TopOnly)
                vRangeStart = 90;
            else if (VerticalSymmetry == VerticalSymmetryEnum.BottomOnly)
                vRangeStop = 90;

            if (resolution <= 0 || resolution > vRangeStop - vRangeStart)
                return new double[] { vRangeStart, vRangeStop };

            return ReportUtils.Range(resolution, vRangeStart, vRangeStop);
        }
        #endregion

        #region resolution textboxes
        private void txtHorizontalResolution_TextChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("HorizontalResolution");
            UpdateEstimate();
        }

        private void txtVerticalResolution_TextChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("VerticalResolution");
            UpdateEstimate();
        }

        private void cboStrayResolution_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtVerticalStrayResolution_TextChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("HorizontalStrayResolution");
        }

        private void txtHorizontalStrayResolution_TextChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("VerticalStrayResolution");
        }
        #endregion

        #region vertical radios
        private void radVerticalFull_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("VerticalSymmetry");
            UpdateEstimate();
        }

        private void radVerticalTop_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("VerticalSymmetry");
            UpdateEstimate();
        }

        private void radVerticalBottom_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("VerticalSymmetry");
            UpdateEstimate();
        }
        #endregion

        #region horizontal radios
        private void radHorizontalFull_CheckedChanged(object sender, EventArgs e)
        {
            txtHorizontalResolution.Enabled = true;

            NotifyPropertyChanged("HorizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalHalf_CheckedChanged(object sender, EventArgs e)
        {
            txtHorizontalResolution.Enabled = true;

            NotifyPropertyChanged("HorizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalQuarter_CheckedChanged(object sender, EventArgs e)
        {
            txtHorizontalResolution.Enabled = true;
            
            NotifyPropertyChanged("HorizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalSingle_CheckedChanged(object sender, EventArgs e)
        {
            txtHorizontalResolution.Enabled = false;
            txtHorizontalResolution.Text = String.Format("{0}", 0);
            
            NotifyPropertyChanged("HorizontalSymmetry");
            UpdateEstimate();
        }
        #endregion

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = chkEmail.Checked;
        }

        private void btnDataFolder_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();
            
            if (result == DialogResult.OK)
                txtDataFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void txtNumberOfLamps_KeyDown(object sender, KeyEventArgs e)
        {
            //only digits valid
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                return;

            e.SuppressKeyPress = true;
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

        /// <summary>
        /// set the estimate label based on horizontal and vertical steps
        /// </summary>
        private void UpdateEstimate()
        {
            lblTime.Text = "00:00:00";

            //regular test
            double[] hRange = CalculateHorizontalRange();
            double[] vRange = CalculateVerticalRange();
            TimeSpan test = ReportUtils.TimeEstimate(hRange.Length, vRange.Length);

            //stray test
            double[] hStrayRange = CalculateStrayHorizontalRange();
            double[] vStrayRange = CalculateStrayVerticalRange();
            TimeSpan stray = ReportUtils.TimeEstimate(hStrayRange.Length, vStrayRange.Length);

            var result = test + stray;

            lblTime.Text = String.Format("{0:hh\\:mm\\:ss}", result);
        }

        /// <summary>
        /// Check if setup values are valid
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (controlSensorSetup.Sensor == null)
                return false;

            if (String.IsNullOrEmpty(txtDataFolder.Text))
                return false;

            if (String.IsNullOrEmpty(txtTestNumber.Text))
                return false;

            if (String.IsNullOrEmpty(txtManufacturer.Text))
                return false;

            if (this.HorizontalResolution <= 0)
                return false;

            if (this.VerticalResolution <= 0)
                return false;

            if (this.HorizontalStrayResolution <= 0)
                return false;

            if (this.VerticalStrayResolution <= 0)
                return false;

            return true;
        }
    }
}
