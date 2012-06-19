using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer.Functions;

namespace Goniometer
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = chkEmail.Checked;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            //calculate test ranges
            double[] hRange = CalculateHorizontalRange();
            double[] vRange = CalculateVerticalRange();

            using (var view = new TestProgress(hRange, vRange))
            {
                view.chkEmail.Checked = chkEmail.Checked;
                view.txtEmail.Text    = txtEmail.Text;

                view.ShowDialog();
            }

            this.Close();
        }

        private void txtVerticalResolution_TextChanged(object sender, EventArgs e)
        {
            UpdateEstimate();
        }

        private void txtHorizontalResolution_TextChanged(object sender, EventArgs e)
        {
            UpdateEstimate();
        }

        private void UpdateEstimate()
        {
            try
            {
                lblTime.Text = "00:00";

                double[] hRange = CalculateHorizontalRange();
                double[] vRange = CalculateVerticalRange();

                var result = ReportUtils.TimeEstimate(hRange.Length, vRange.Length);
                lblTime.Text = String.Format("{0:hh\\:mm}", result);
            }
            catch
            {
                //omnomnom
            }
        }

        private double[] CalculateHorizontalRange()
        {
            double hRes = 0; //resolution between steps
            int hRange = 0;  //total range in degrees

            hRes = Double.Parse(txtHorizontalResolution.Text);
            hRange = 360;

            return ReportUtils.Range(hRes, 0, hRange);
        }

        private double[] CalculateVerticalRange()
        {
            double vRes = 0;        //resolution between steps
            int vRangeStart = 0;    //start of range in degrees
            int vRangeStop = 0;     //stop of range in degrees

            vRes = Double.Parse(txtVerticalResolution.Text);

            if (radVerticalTop.Checked)
            {
                vRangeStart = 90;
                vRangeStop = 180;
            }
            else if (radVerticalBottom.Checked)
            {
                vRangeStart = 0;
                vRangeStop = 90;
            }
            else
            {
                vRangeStart = 0;
                vRangeStop = 180;
            }

            return ReportUtils.Range(vRes, vRangeStart, vRangeStop);
        }
    }
}
