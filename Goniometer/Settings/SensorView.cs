using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

using Goniometer_Controller.Sensors;

namespace Goniometer
{
    public partial class SensorView : Form
    {
        public SensorView()
        {
            InitializeComponent();
        }

        private void SensorView_Load(object sender, EventArgs e)
        {
            cboPortNames.Items.AddRange(SerialPort.GetPortNames());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Connect();
            }
            catch (Exception ex)
            {
                //failure to connect?
            }
        }

        private Action controllerUpdate;
        private void timerSensor_Tick(object sender, EventArgs e)
        {
            if (controllerUpdate != null)
                controllerUpdate();
        }

        private bool ValidateSettings()
        {
            if (cboPortNames.SelectedItem == null || String.IsNullOrEmpty(cboPortNames.SelectedItem.ToString()))
                return false;

            if (!radSensorTypeT10.Checked & !radSensorTypeCL200.Checked)
                return false;

            return true;
        }

        private void Connect()
        {
            //check portName
            string portName = cboPortNames.SelectedItem.ToString();
            if (String.IsNullOrEmpty(portName))
            {
                MessageBox.Show("You must select a portName to continue");
                return;
            }

            MinoltaSensorProvider.ConfigureControllers(portName);

            //setup sensor and timer
            controllerUpdate = null;
            if (radSensorTypeT10.Checked)
            {
                controllerUpdate = ReadT10values;
            }
            else if (radSensorTypeCL200.Checked)
            {

                controllerUpdate = ReadCL200Values;
            }
            else
            {
                MessageBox.Show("You must select a sensor type to continue");
                return;
            }
        }

        #region t10
        private MinoltaT10Controller _t10;
        private void ReadT10values()
        {

        }
        #endregion

        #region cl200
        private void ReadCL200Values()
        {
            
        }
        #endregion

        private void cboPortNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidateSettings())
                Connect();
        }

        private void radSensorTypeT10_CheckedChanged(object sender, EventArgs e)
        {
            if (ValidateSettings())
                Connect();
        }

        private void radSensorTypeCL200_CheckedChanged(object sender, EventArgs e)
        {
            if (ValidateSettings())
                Connect();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
