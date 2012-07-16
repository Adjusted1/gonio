﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer_Controller.Sensors;
using System.IO.Ports;

namespace Goniometer.Setup
{
    public partial class SensorSetup : UserControl
    {
        public MinoltaBaseSensor Sensor;

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
            Sensor = null;
            lblMessage.Text = "Pick a Sensor";
            gridData.Visible = false;

            RefreshPortList();
            RefreshSensorList();
        }

        private void RefreshSensorList()
        {
            cboSensor.SelectedItem = null;
            cboSensor.Items.Clear();
            cboSensor.Items.Add("");
            cboSensor.Items.AddRange(MinoltaSensorProvider.GetSensorNames());
        }

        private void RefreshPortList()
        {
            cboPort.SelectedItem = null;
            cboPort.Items.Clear();
            cboPort.Items.Add("");
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
                //check sensorName
                if (cboSensor.SelectedItem == null || String.IsNullOrEmpty(cboSensor.SelectedItem.ToString()))
                    return;

                //check portName
                if (cboPort.SelectedItem == null || String.IsNullOrEmpty(cboPort.SelectedItem.ToString()))
                    return;
                
                //prepare sensor before assigning to member var
                MinoltaSensorProvider.ConfigureControllers(cboPort.SelectedItem.ToString());
                var sensor = this.Sensor = MinoltaSensorProvider.GetSensorByName(cboSensor.SelectedItem.ToString());
                sensor.Connect();

                this.Sensor = sensor;
            }
            catch (Exception)
            {
                lblMessage.Text = "Error";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "Communicating";

                if (Sensor != null)
                {
                    var source = new BindingSource();
                    source.DataSource = Sensor.CollectMeasurements(0,0);
                    gridData.DataSource = source;
                    gridData.Visible = true;
                }
                else
                {
                    gridData.Visible = false;
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Error";
                gridData.Visible = false;
            }
        }
    }
}
