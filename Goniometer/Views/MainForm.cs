using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

using Goniometer.Reports;
using Goniometer.Sensors;
using Goniometer.Tests;
using Goniometer.Tests.IESNA;

using Goniometer_Controller;
using Goniometer_Controller.Models;
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
                //connect to motor
                string address = ConfigurationManager.AppSettings["motor.ip"];
                MotorController.Connect(IPAddress.Parse(address));

                //connect to sensors
                SensorProvider.LoadSensorConfiguration();
            }
            catch (Exception)
            {
                //controller failed to connect
            }
        }

        #region menu items
        private void openRawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(openFileDialog.FileName);
                    if (!fi.Exists)
                        return;

                    LoadDataControl(fi.FullName);
                }
            }
            catch (Exception)
            { 
            }
        }

        private void motorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (var view = new MotorView())
            //{
            //    view.ShowDialog();
            //}
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

        #region DataControl
        private void LoadDataControl(string filePath)
        {
            //initialize and attach view
            panelMain.Controls.Clear();

            var dataControl = new RawDataView();
            dataControl.Size = panelMain.Size;
            dataControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataControl.OnCloseClicked += dataControl_OnCloseClicked;
            dataControl.OnExportClicked += dataControl_OnExportClicked;

            panelMain.Controls.Add(dataControl);

            //fetch data and bind it
            using (StreamReader sr = new StreamReader(filePath))
            {
                string raw = sr.ReadToEnd();
                var measurements = MeasurementCollection.FromCSV(raw);
                dataControl.SetDataSource(measurements);
            }
        }

        private void dataControl_OnCloseClicked(object sender, EventArgs e)
        {
            LoadTestListControl();
        }

        private void dataControl_OnExportClicked(object sender, EventArgs e)
        {
            LoadTestListControl();
        }
        #endregion

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
            {
                LoadLumenTestControl();
            }
            //else if (testName == "Calibration Test")
            //{
            //    LoadCalibrationTestControl();
            //}
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
                    double[] hRange = control.CalculateHorizontalRange();
                    if (hRange.Length == 0)
                        return;

                    motorControlHorizontal.GaugeRangeStartValue = Convert.ToSingle(hRange.First());
                    motorControlHorizontal.GaugeRangeEndValue   = Convert.ToSingle(hRange.Last());
                }
                else if (e.PropertyName == "VerticalResolution"
                       | e.PropertyName == "VerticalSymmetry"
                       | e.PropertyName == "VerticalStartRange"
                       | e.PropertyName == "VerticalStopRange")
                {
                    double[] vRange = control.CalculateVerticalRange();
                    if (vRange.Length == 0)
                        return;

                    motorControlVertical.GaugeRangeStartValue = Convert.ToSingle(vRange.First());
                    motorControlVertical.GaugeRangeEndValue   = Convert.ToSingle(vRange.Last());
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

        private void timerMotor_Tick(object sender, EventArgs e)
        {
            try
            {
                motorControlHorizontal.GaugeAngle = Convert.ToSingle(MotorController.GetHorizontalEncoderPosition());
                motorControlVertical.GaugeAngle   = Convert.ToSingle(MotorController.GetVerticalEncoderPosition());
            }
            catch (Exception)
            {
            }
        }

        private void btnPanic_Click(object sender, EventArgs e)
        {
            MotorController.EmergencyStop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MotorController.EmergencyStop();
        }

        private void motorControlVertical_OnButtonGoClicked(object sender, double? e)
        {
            if (e.HasValue)
                MotorController.SetVerticalAngleAndWait(e.Value);
        }

        private void motorControlHorizontal_OnButtonGoClicked(object sender, double? e)
        {
            if (e.HasValue)
                MotorController.SetHorizontalAngleAndWait(e.Value);
        } 
    }
}
