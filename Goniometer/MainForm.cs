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

using Goniometer.Tests;
using Goniometer.Tests.Calibration;
using Goniometer.Tests.IESNA;

using Goniometer_Controller;
using Goniometer_Controller.Motors;
using Goniometer_Controller.Sensors;

namespace Goniometer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //load main content
                LoadTestListControl();
            }
            catch (Exception)
            {
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                string address = ConfigurationManager.AppSettings["motor.ip"];
                MotorController.Connect(IPAddress.Parse(address));
            }
            catch (Exception)
            {
                //controller failed to connect
            }
        }

        #region menu items
        private void motorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var view = new MotorView())
            {
                view.ShowDialog();
            }
        }

        private void sensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (var view = new SensorView())
            //{
            //    view.ShowDialog();
            //}
        }
        #endregion

        #region main panel context switching

        #region TestListControl
        private void LoadTestListControl()
        {
            panelMain.Controls.Clear();

            var testListControl = new TestListControl();
            testListControl.Size = panelMain.Size;
            testListControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            testListControl.OnTestSelected += new EventHandler(testListControl_btnTest_Clicked);

            panelMain.Controls.Add(testListControl);
        }

        private void testListControl_btnTest_Clicked(object sender, EventArgs e)
        {
            var testListControl = sender as TestListControl;
            if (testListControl == null)
                return;

            string testName = testListControl.SelectedTest;
            if (testName == "Lumen Test")
                LoadLumenTestControl();
            else if (testName == "Calibration Test")
                LoadCalibrationTestControl();
        }
        #endregion

        #region CalibrationTestControl
        private void LoadCalibrationTestControl()
        {
            panelMain.Controls.Clear();

            var calibrationTestControl = new CalibrationControl();
            calibrationTestControl.Size = panelMain.Size;
            calibrationTestControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panelMain.Controls.Add(calibrationTestControl);
        }
        #endregion

        #region LumenTestControl
        private void LoadLumenTestControl()
        {
            panelMain.Controls.Clear();

            var lumenTestControl = new LumenTestControl();
            lumenTestControl.Size = panelMain.Size;
            lumenTestControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lumenTestControl.PropertyChanged += new PropertyChangedEventHandler(lumenTestControl_PropertyChanged);
            lumenTestControl.OnExit += new EventHandler(lumenTestControl_OnExit);

            panelMain.Controls.Add(lumenTestControl);
        }

        private void lumenTestControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                LumenTestSetupControl control = sender as LumenTestSetupControl;
                if (control == null)
                    return;

                if (e.PropertyName == "HorizontalResolution" | e.PropertyName == "HorizontalSymmetry")
                {
                    gaugeHorizontal.RangeFills.Clear();

                    double[] hRange = control.CalculateHorizontalRange();
                    if (hRange.Length == 0 || hRange.First() == hRange.Last())
                        return;

                    NationalInstruments.UI.Range range = new NationalInstruments.UI.Range(hRange.First(), hRange.Last());
                    NationalInstruments.UI.ScaleRangeFill fill = new NationalInstruments.UI.ScaleRangeFill(range);
                    gaugeHorizontal.RangeFills.Add(fill);
                }
                else if (e.PropertyName == "VerticalResolution" | e.PropertyName == "VerticalSymmetry")
                {
                    gaugeVertical.RangeFills.Clear();

                    double[] vRange = control.CalculateVerticalRange();
                    if (vRange.Length == 0 || vRange.First() == vRange.Last())
                        return;

                    NationalInstruments.UI.Range range = new NationalInstruments.UI.Range(vRange.First(), vRange.Last());
                    NationalInstruments.UI.ScaleRangeFill fill = new NationalInstruments.UI.ScaleRangeFill(range);
                    gaugeVertical.RangeFills.Add(fill);
                }
            }
            catch
            {
                //omnomnom
            }
        }

        private void lumenTestControl_OnExit(object sender, EventArgs e)
        {
            LoadTestListControl();
        }
        #endregion

        #endregion

        #region status panel
        private void timerMotor_Tick(object sender, EventArgs e)
        {
            try
            {
                double hAngle = MotorController.GetHorizontalMotorPosition();
                lblHorizontalAngle.Text = hAngle.ToString("0.##");
                if (hAngle < gaugeHorizontal.Range.Minimum)
                    gaugeHorizontal.Value = gaugeHorizontal.Range.Minimum;
                else if (hAngle > gaugeHorizontal.Range.Maximum)
                    gaugeHorizontal.Value = gaugeHorizontal.Range.Maximum;
                else
                    gaugeHorizontal.Value = hAngle;
                
                double vAngle = MotorController.GetVerticalMotorPosition();
                lblVerticalAngle.Text = vAngle.ToString("0.##");
                if (vAngle < gaugeVertical.Range.Minimum)
                    gaugeVertical.Value = gaugeVertical.Range.Minimum;
                else if (vAngle > gaugeVertical.Range.Maximum)
                    gaugeVertical.Value = gaugeVertical.Range.Maximum;
                else
                    gaugeVertical.Value = vAngle;
            }
            catch (InvalidOperationException)
            {
                //omnomnom, (connectivity problems)
            }
            catch (Exception)
            {
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            ExecuteMotor();
        }

        private void ExecuteMotor()
        {
            try
            {
                double h;
                if (Double.TryParse(txtHorizontalAngle.Text, out h))
                    MotorController.SetHorizontalAngle(h);

                double v;
                if (Double.TryParse(txtVerticalAngle.Text, out v))
                    MotorController.SetVerticalAngle(v);
            }
            catch (InvalidOperationException)
            {
                //omnomnom, (connectivity problems)
            }
        }

        private void txtHorizontalAngle_TextChanged(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(txtHorizontalAngle.Text, out d))
                picHorizontalAngleValid.Visible = true;

            if (d < 0 | d > 360)
                picHorizontalAngleValid.Visible = true;

            picHorizontalAngleValid.Visible = false;
        }

        private void txtVerticalAngle_TextChanged(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(txtVerticalAngle.Text, out d))
                picVerticalAngleValid.Visible = true;

            if (d < 0 | d > 180)
                picVerticalAngleValid.Visible = true;

            picVerticalAngleValid.Visible = false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (var view = new MotorView())
            {
                view.ShowDialog();
            }
        }
        #endregion

        private void btnPanic_Click(object sender, EventArgs e)
        {
            MotorController.EmergencyStop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MotorController.EmergencyStop();
        }


    }
}
