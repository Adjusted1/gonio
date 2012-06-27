using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer_Controller;
using Goniometer_Controller.Motors;
using Goniometer_Controller.Sensors;

namespace Goniometer
{
    public partial class MainForm : Form
    {
        MotorController _motor;
        MinoltaTTenController _sensor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _motor = MotorControllerFactory.getMotorController();
            _motor.PropertyChanged += new PropertyChangedEventHandler(_motor_PropertyChanged);

            _sensor = MinoltaTTenControllerFactory.GetSensorController();
            _sensor.PropertyChanged += new PropertyChangedEventHandler(_sensor_PropertyChanged);
        }

        private void _motor_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "horizontalAngle")
                gaugeHorizontal.Value = _motor.horizontalAngle;

            else if (e.PropertyName == "verticalAngle")
                gaugeVertical.Value = _motor.verticalAngle;
        }

        private void _sensor_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }

        #region menu items
        private void motorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var view = new MotorView())
            {
                view.ShowDialog();
            }

            _motor = MotorControllerFactory.getMotorController();
        }

        private void sensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var view = new SensorView())
            {
                view.ShowDialog();
            }

            _sensor = MinoltaTTenControllerFactory.GetSensorController();
        }
        #endregion

        #region main panel context switching
        private void btnTest_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            var control = new LumenTestSetupControl();
            control.Size = panelMain.Size;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.PropertyChanged += new PropertyChangedEventHandler(LumenTestSetupControl_PropertyChanged);
            control.StartClicked += new EventHandler(LumenTestSetupControl_StartClicked);

            panelMain.Controls.Add(control);
        }

        private void LumenTestSetupControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                LumenTestSetupControl control = sender as LumenTestSetupControl;
                if (control == null)
                    return;

                if (e.PropertyName == "horizontalResolution" | e.PropertyName == "horizontalSymmetry")
                {
                    gaugeHorizontal.RangeFills.Clear();

                    double[] hRange = control.CalculateHorizontalRange();
                    if (hRange.Length == 0 || hRange.First() == hRange.Last())
                        return;

                    NationalInstruments.UI.Range range = new NationalInstruments.UI.Range(hRange.First(), hRange.Last());
                    NationalInstruments.UI.ScaleRangeFill fill = new NationalInstruments.UI.ScaleRangeFill(range);
                    gaugeHorizontal.RangeFills.Add(fill);
                }
                else if (e.PropertyName == "verticalResolution" | e.PropertyName == "verticalSymmetry")
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

        private void LumenTestSetupControl_StartClicked(object sender, EventArgs e)
        {
            try
            {
                LumenTestSetupControl setup = sender as LumenTestSetupControl;
                if (setup == null)
                    return;

                double[] hRange = setup.CalculateHorizontalRange();
                double[] vRange = setup.CalculateVerticalRange();
                double[] hStrayRange = setup.CalculateStrayHorizontalRange();
                double[] vStrayRange = setup.CalculateStrayVerticalRange();
                double k = (setup.offset.HasValue ? setup.offset.Value : 1);

                panelMain.Controls.Clear();

                var control = new LumenTestProgressControl(this._motor, this._sensor, hRange, vRange, hStrayRange, vStrayRange, k);
                control.Size = panelMain.Size;
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                control.LightTestFinished += new EventHandler(LumentTestProgressControl_LightTestFinished);

                panelMain.Controls.Add(control);
            }
            catch
            {
                //omnomnom
            }
        }

        private void LumentTestProgressControl_LightTestFinished(object sender, EventArgs e)
        {
            //nothing! //we're done!
        }
        #endregion
    }
}
