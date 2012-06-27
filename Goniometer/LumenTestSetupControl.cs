using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer.Functions;

namespace Goniometer
{
    public partial class LumenTestSetupControl : UserControl, INotifyPropertyChanged
    {
        public LumenTestSetupControl()
        {
            InitializeComponent();
        }

        private void LumenTestSetupControl_Load(object sender, EventArgs e)
        {

        }

        #region parsed values
        public double? offset
        {
            get
            {
                double value;
                if (Double.TryParse(txtOffset.Text, out value))
                    return value;
                else
                    return null;
            }
        }

        public double? horizontalResolution
        {
            get
            {
                double value;
                if (Double.TryParse(txtHorizontalResolution.Text, out value))
                    return value;
                else
                    return null;
            }
            set
            {
                txtHorizontalResolution.Text = String.Format("{0:0.0}", value);
            }
        }

        public double? horizontalStrayResolution
        {
            get
            {
                double value;
                if (Double.TryParse(txtHorizontalResolution.Text, out value))
                    return value;
                else
                    return null;
            }
        }

        public double? verticalResolution
        {
            get
            {
                double value;
                if (Double.TryParse(txtVerticalResolution.Text, out value))
                    return value;
                else
                    return null;
            }
            set
            {
                txtVerticalResolution.Text = String.Format("{0:0.0}", value);
            }
        }

        public double? verticalStrayResolution
        {
            get
            {
                double value;
                if (Double.TryParse(txtVerticalStrayResolution.Text, out value))
                    return value;
                else
                    return null;
            }
            set
            {
                txtVerticalStrayResolution.Text = String.Format("{0:0.0}", value);
            }
        }

        public VerticalSymmetryEnum? verticalSymmetry
        {
            get
            {
                if (radVerticalFull.Checked)
                    return VerticalSymmetryEnum.Full;
                else if (radVerticalTop.Checked)
                    return VerticalSymmetryEnum.TopOnly;
                else if (radVerticalBottom.Checked)
                    return VerticalSymmetryEnum.BottomOnly;
                else
                    return null;
            }
            set
            {

            }
        }

        public HorizontalSymmetryEnum? horizontalSymmetry
        {
            get
            {
                if (radHorizontalFull.Checked)
                    return HorizontalSymmetryEnum.Full;
                else if (radHorizontalHalf.Checked)
                    return HorizontalSymmetryEnum.Half;
                else if (radHorizontalQuarter.Checked)
                    return HorizontalSymmetryEnum.Quarter;
                else if (radHorizontalSingle.Checked)
                    return HorizontalSymmetryEnum.Single;
                else
                    return null;
            }
            set
            {

            }
        }
        #endregion

        #region range calculations
        public double[] CalculateHorizontalRange()
        {
            if (horizontalResolution == null || horizontalResolution <= 0)
                return new double[0];

            if (horizontalSymmetry == null)
                return new double[0];

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
                default:
                    return new double[] { 0 };
            }

            return ReportUtils.Range(horizontalResolution.Value, 0, hRange);
        }

        public double[] CalculateStrayHorizontalRange()
        {
            return CalculateHorizontalRange();
        }

        public double[] CalculateVerticalRange()
        {
            if (verticalResolution == null || verticalResolution <= 0)
                return new double[0];

            if (verticalSymmetry == null)
                return new double[0];

            int vRangeStart = 0;     //start of range in degrees
            int vRangeStop = 180;     //stop of range in degrees

            if (verticalSymmetry == VerticalSymmetryEnum.TopOnly)
                vRangeStart = 90;
            else if (verticalSymmetry == VerticalSymmetryEnum.BottomOnly)
                vRangeStop = 90;

            return ReportUtils.Range(verticalResolution.Value, vRangeStart, vRangeStop);
        }

        public double[] CalculateStrayVerticalRange()
        {
            if (verticalStrayResolution == null || verticalStrayResolution <= 0)
                return new double[0];

            int vRangeStart = 0;     //start of range in degrees
            int vRangeStop = 180;     //stop of range in degrees

            if (verticalSymmetry == VerticalSymmetryEnum.TopOnly)
                vRangeStart = 90;
            else if (verticalSymmetry == VerticalSymmetryEnum.BottomOnly)
                vRangeStop = 90;

            return ReportUtils.Range(verticalStrayResolution.Value, vRangeStart, vRangeStop);
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

        private void txtVerticalStrayResolution_TextChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("verticalStrayResolution");
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
            NotifyPropertyChanged("horizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalHalf_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("horizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalQuarter_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("horizontalSymmetry");
            UpdateEstimate();
        }

        private void radHorizontalSingle_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("horizontalSymmetry");
            UpdateEstimate();
        }
        #endregion

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = chkEmail.Checked;
        }

        public event EventHandler StartClicked;
        private void btnStart_Click(object sender, EventArgs e)
        {
            var notify = StartClicked;
            if (notify != null)
            {
                StartClicked(this, null);
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

        private void UpdateEstimate()
        {
            try
            {
                lblTime.Text = "00:00";

                //regular test
                double[] hRange = CalculateHorizontalRange();
                double[] vRange = CalculateVerticalRange();
                TimeSpan test = ReportUtils.TimeEstimate(hRange.Length, vRange.Length);

                //stray test
                double[] hStrayRange = CalculateStrayHorizontalRange();
                double[] vStrayRange = CalculateStrayVerticalRange();
                TimeSpan stray = ReportUtils.TimeEstimate(hStrayRange.Length, vStrayRange.Length);

                var result = test + stray;

                lblTime.Text = String.Format("{0:hh\\:mm}", result);
            }
            catch
            {
                //omnomnom
            }
        }
    }
}
