using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

using Goniometer_Controller.Motors;

namespace Goniometer
{
    public partial class MotorView : Form
    {
        public MotorView()
        {
            InitializeComponent();
        }

        protected void MotorView_Load(object sender, EventArgs e)
        {
            SetZeroingMode(false);
        }

        protected void timerMotor_Tick(object sender, EventArgs e)
        {
            try
            {
                double horizontalMotorAngle = MotorController.GetHorizontalAngle();
                lblHorizontalMotorAngle.Text = horizontalMotorAngle.ToString("0.##");
                if (horizontalMotorAngle < gaugeHorizontal.Range.Minimum)
                    gaugeHorizontal.Value = gaugeHorizontal.Range.Minimum;
                else if (horizontalMotorAngle > gaugeHorizontal.Range.Maximum)
                    gaugeHorizontal.Value = gaugeHorizontal.Range.Maximum;
                else
                    gaugeHorizontal.Value = horizontalMotorAngle;
                
                double verticalMotorAngle = MotorController.GetVerticalAngle();
                lblVerticalMotorAngle.Text = verticalMotorAngle.ToString("0.##");
                if (verticalMotorAngle < gaugeVertical.Range.Minimum)
                    gaugeVertical.Value = gaugeVertical.Range.Minimum;
                else if (verticalMotorAngle > gaugeVertical.Range.Maximum)
                    gaugeVertical.Value = gaugeVertical.Range.Maximum;
                else
                    gaugeVertical.Value = verticalMotorAngle;
            }
            catch (InvalidOperationException)
            {
                //omnomnom, (connectivity problems)
            }
            catch (Exception)
            {
            }
        }

        #region address and connection
        private void txtIPAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Return)
                Connect();
        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {
            IPAddress address;
            if (IPAddress.TryParse(txtIPAddress.Text, out address))
                btnConnect.Enabled = true;
            else
                btnConnect.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            try
            {
                IPAddress address = IPAddress.Parse(txtIPAddress.Text);
                MotorController.Connect(address);
            }
            catch (Exception)
            {
                MessageBox.Show("Failure to connect");
            }
        }
        #endregion

        #region zeroing buttons
        private void btnVerticalCW5_Click(object sender, EventArgs e)
        {
            MoveVertical(5);
        }

        private void btnVerticalCW1_Click(object sender, EventArgs e)
        {
            MoveVertical(1);
        }

        private void btnVerticalCW01_Click(object sender, EventArgs e)
        {
            MoveVertical(0.1);
        }

        private void btnVerticalCCW5_Click(object sender, EventArgs e)
        {
            MoveVertical(-5);
        }

        private void btnVerticalCCW1_Click(object sender, EventArgs e)
        {
            MoveVertical(-1);
        }

        private void btnVerticalCCW01_Click(object sender, EventArgs e)
        {
            MoveVertical(-0.1);
        }

        private void MoveVertical(double distance)
        {
            MotorController.SetVerticalAngle(distance);
        }

        private void btnHorizontalCW5_Click(object sender, EventArgs e)
        {
            MoveHorizontal(5);
        }

        private void btnHorizontalCW1_Click(object sender, EventArgs e)
        {
            MoveHorizontal(1);
        }

        private void btnHorizontalCW01_Click(object sender, EventArgs e)
        {
            MoveHorizontal(0.1);
        }

        private void btnHorizontalCCW5_Click(object sender, EventArgs e)
        {
            MoveHorizontal(-5);
        }

        private void btnHorizontalCCW1_Click(object sender, EventArgs e)
        {
            MoveHorizontal(-1);
        }

        private void btnHorizontalCCW01_Click(object sender, EventArgs e)
        {
            MoveHorizontal(-0.1);
        }

        private void MoveHorizontal(double distance)
        {
            MotorController.SetHorizontalAngle(distance);
        }
        #endregion

        #region zeroing methods
        private void btnZero_Click(object sender, EventArgs e)
        {
            MotorController.ZeroHorizontalMotor();
            MotorController.ZeroVerticalMotor();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SetZeroingMode(false);

            this.Close();
        }

        private void chkZero_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZero.Checked)
                SetZeroingMode(true);
            else
                SetZeroingMode(false);
        }

        private void SetZeroingMode(bool zeroing)
        {
            if (zeroing)
            {
                try
                {
                    MotorController.EnterZeroingMode();
                }
                catch (InvalidOperationException)
                {
                    //omnomnom, communication error
                }

                btnVerticalCW5.Enabled = true;
                btnVerticalCW1.Enabled = true;
                btnVerticalCW01.Enabled = true;
                btnVerticalCCW5.Enabled = true;
                btnVerticalCCW1.Enabled = true;
                btnVerticalCCW01.Enabled = true;

                btnHorizontalCW5.Enabled = true;
                btnHorizontalCW1.Enabled = true;
                btnHorizontalCW01.Enabled = true;
                btnHorizontalCCW5.Enabled = true;
                btnHorizontalCCW1.Enabled = true;
                btnHorizontalCCW01.Enabled = true;

                btnZero.Enabled = true;
            }
            else
            {
                try
                {
                    MotorController.ExitZeroingMode();
                }
                catch (InvalidOperationException)
                {
                    //omnomnom, communications error
                }

                btnVerticalCW5.Enabled = false;
                btnVerticalCW1.Enabled = false;
                btnVerticalCW01.Enabled = false;
                btnVerticalCCW5.Enabled = false;
                btnVerticalCCW1.Enabled = false;
                btnVerticalCCW01.Enabled = false;

                btnHorizontalCW5.Enabled = false;
                btnHorizontalCW1.Enabled = false;
                btnHorizontalCW01.Enabled = false;
                btnHorizontalCCW5.Enabled = false;
                btnHorizontalCCW1.Enabled = false;
                btnHorizontalCCW01.Enabled = false;

                btnZero.Enabled = false;
            }
        }
        #endregion
    }
}
