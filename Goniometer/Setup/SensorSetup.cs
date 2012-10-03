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
        private List<MinoltaBaseSensor> _sensors = new List<MinoltaBaseSensor>();
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
        private void ResetControl()
        {
            if (_sensor != null)
                _sensor.Disconnect();

            _sensor = null;
            _sensors = new List<MinoltaBaseSensor>();

            lblMessage.Text = "Pick a Sensor";

            RefreshPortList();
            RefreshSensorList();
            ResetSensorsList();
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

        private void ResetSensorsList()
        {
            listSensors.Items.Clear();
            listSensors.Items.AddRange(
                _sensors.Select(s => s.GetName()).ToArray()
                );
        }
        #endregion

        #region add methods
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSensor();
        }

        private void AddSensor()
        {
            _sensors.Add(_sensor);
            ResetSensorsList();
        }
        #endregion

        #region remove methods
        private void RemoveSensor()
        {
            _sensors.Remove(_sensor);
            ResetSensorsList();
        }
        #endregion

        private void cboSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;

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
            btnAdd.Enabled = false;

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
                var sensor = MinoltaSensorProvider.GetSensorByName(cboSensor.SelectedItem.ToString(), port);
                sensor.Connect();

                //test the read method on the sensor
                var measurements = sensor.CollectMeasurements(0,0);
                measurementGridView.DataSource = measurements;

                this._sensor = sensor;
                lblMessage.Text = "Success";
                btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = String.Format("Error. Wrong Type/Port?\n{0}", ex.Message);

                if (this._sensor != null)
                    this._sensor.Disconnect();
            }
        }

        public IEnumerable<MinoltaBaseSensor> GetSensors()
        {
            return _sensors;
        }
    }
}
