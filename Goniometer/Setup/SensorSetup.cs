using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer_Controller;
using Goniometer_Controller.Sensors;

namespace Goniometer.Setup
{
    public partial class SensorSetup : UserControl
    {
        private MinoltaBaseSensor _sensor;

        public SensorSetup()
        {
            InitializeComponent();
        }

        private void SensorSetup_Load(object sender, EventArgs e)
        {
            ResetControl();
        }

        #region reset methods
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void ResetControl()
        {
            _sensor = null;

            lblMessage.Text = "Pick a Sensor";

            RefreshPortList();
            RefreshSensorList();
        }

        private void RefreshSensorList()
        {
            cboSensor.SelectedItem = null;
            cboSensor.Items.Clear();
            cboSensor.Items.AddRange(MinoltaSensorProvider.GetSensorNames());
        }

        private void RefreshPortList()
        {
            cboPort.SelectedItem = null;
            cboPort.Items.Clear();
            cboPort.Items.AddRange(SerialPort.GetPortNames());
        } 
        #endregion

        private void cboSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSensor.SelectedItem == null || String.IsNullOrEmpty(cboSensor.SelectedItem.ToString()))
            {
                //warn user
                lblMessage.Text = "Pick a Sensor";
                cboPort.Enabled = false;
            }
            else
            {
                lblMessage.Text = "Pick a Port";
                cboPort.Enabled = true;
            }
        }

        private void cboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check portName
            if (cboPort.SelectedItem == null || String.IsNullOrEmpty(cboPort.SelectedItem.ToString()))
                return;

            Connect();
        }

        private void Connect()
        {
            try
            {
                //clear out current readings
                measurementGridView.DataSource = null;

                //check sensorName
                if (cboSensor.SelectedItem == null || String.IsNullOrEmpty(cboSensor.SelectedItem.ToString()))
                    return;

                //check portName
                if (cboPort.SelectedItem == null || String.IsNullOrEmpty(cboPort.SelectedItem.ToString()))
                    return;
                
                lblMessage.Text = "Connecting";

                //prepare sensor in local variable before assigning to member
                var port = SerialPortProvider.GetPort(cboPort.SelectedItem.ToString());
                var sensor = this._sensor = MinoltaSensorProvider.GetSensorByName(cboSensor.SelectedItem.ToString(), port);
                sensor.Connect();

                //test the read method on the sensor
                var measurements = sensor.CollectMeasurements(0,0);
                measurementGridView.DataSource = measurements;

                this._sensor = sensor;
                lblMessage.Text = "Success";
            }
            catch (Exception ex)
            {
                lblMessage.Text = String.Format("Error. Wrong Type/Port?\n{0}", ex.Message);
            }
        }

        public IEnumerable<MinoltaBaseSensor> GetSensors()
        {
            return new List<MinoltaBaseSensor> { _sensor };
        }
    }
}
