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
        public MinoltaBaseSensor Sensor
        {
            get
            {
                return controlSensorSetup.Sensor;
            }
        }

        public LumenTestSetupControl()
        {
            InitializeComponent();
        }

        #region parsed values
        public double horizontalResolution
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

        public double horizontalStrayResolution
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

        public double verticalResolution
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

        public double verticalStrayResolution
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

        public VerticalSymmetryEnum verticalSymmetry
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

        public HorizontalSymmetryEnum horizontalSymmetry
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
            int hRange = 0;  //total range in degrees
            switch(horizontalSymmetry)
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

            if (horizontalResolution <= 0 || horizontalResolution > hRange)
                return new double[] { 0, hRange };

            return ReportUtils.Range(horizontalResolution, 0, hRange);
        }

        public double[] CalculateStrayHorizontalRange()
        {
            return CalculateHorizontalRange();
        }

        public double[] CalculateVerticalRange()
        {
            int vRangeStart = 0;     //start of range in degrees
            int vRangeStop = 180;     //stop of range in degrees

            if (verticalSymmetry == VerticalSymmetryEnum.TopOnly)
                vRangeStart = 90;
            else if (verticalSymmetry == VerticalSymmetryEnum.BottomOnly)
                vRangeStop = 90;

            if (verticalResolution <= 0 || verticalResolution > vRangeStop - vRangeStart)
                return new double[] { vRangeStart, vRangeStop };

            return ReportUtils.Range(verticalResolution, vRangeStart, vRangeStop);
        }

        public double[] CalculateStrayVerticalRange()
        {
            return CalculateVerticalRange();
        }
        #endregion

        #region resolution textboxes
        private void txtHorizontalResolution_TextChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("horizontalResolution");
            UpdateEstimate();
        }

        private void txtVerticalResolution_TextChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("verticalResolution");
            UpdateEstimate();
        }
        #endregion

        #region vertical radios
        private void radVerticalFull_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("verticalSymmetry");
            UpdateEstimate();
        }

        private void radVerticalTop_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("verticalSymmetry");
            UpdateEstimate();
        }

        private void radVerticalBottom_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("verticalSymmetry");
            UpdateEstimate();
        }
        #endregion

        #region horizontal radios
        private void radHorizontalFull_CheckedChanged(object sender, EventArgs e)
        {
            txtHorizontalResolution.Enabled = true;

            NotifyPropertyChanged("horizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalHalf_CheckedChanged(object sender, EventArgs e)
        {
            txtHorizontalResolution.Enabled = true;

            NotifyPropertyChanged("horizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalQuarter_CheckedChanged(object sender, EventArgs e)
        {
            txtHorizontalResolution.Enabled = true;
            
            NotifyPropertyChanged("horizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalSingle_CheckedChanged(object sender, EventArgs e)
        {
            txtHorizontalResolution.Enabled = false;
            txtHorizontalResolution.Text = String.Format("{0}", 0);
            
            NotifyPropertyChanged("horizontalSymmetry");
            UpdateEstimate();
        }
        #endregion

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = chkEmail.Checked;
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

        private void UpdateEstimate()
        {
            try
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
            catch
            {
                //omnomnom
            }
        }

        /// <summary>
        /// Check if setup values are valid
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (controlSensorSetup.Sensor == null)
                return false;

            return true;
        }
    }
}
