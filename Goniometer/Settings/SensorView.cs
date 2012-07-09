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

                //check portName
                string portName = cboPortNames.SelectedItem.ToString();
                if (String.IsNullOrEmpty(portName))
                {
                    MessageBox.Show("You must select a portName to continue");
                    return;
                }

                //setup sensor and timer
                controllerUpdate = null;
                if (radSensorTypeT10.Checked)
                {
                    MinoltaTTenControllerFactory.SetPortName(portName);
                    controllerUpdate = ReadT10values;
                }
                else if (radSensorTypeCL200.Checked)
                {
                    MinoltaCL200Provider.SetPortName(portName);
                    _cl200 = MinoltaCL200Provider.GetController();
                    _cl200.Connect();

                    controllerUpdate = ReadCL200Values;
                }
                else
                {
                    MessageBox.Show("You must select a sensor type to continue");
                    return;
                }
                
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

        #region t10
        private MinoltaTTenController _t10;
        private void ReadT10values()
        {

        }
        #endregion

        #region cl200
        private MinoltaCL200Controller _cl200;
        private void ReadCL200Values()
        {
            if (_cl200 == null)
                return;

            double Ev, x, y;

            _cl200.TakeMeasurement();
            _cl200.ReadEvXY(0, false, MinoltaCL200Controller.CalibrationModeEnum.NORM, out Ev, out x, out y);

            DataTable table = new DataTable();
            
            table.Columns.Add("Reading");
            table.Columns.Add("value");

            table.Rows.Add("Ev", Ev);
            table.Rows.Add("x", x);
            table.Rows.Add("y", y);

            gridReadings.DataSource = table;
        }
        #endregion
    }
}
