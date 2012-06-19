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
        private MinoltaTTenController controller;

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
            string portName = cboPortNames.SelectedItem.ToString();
            if (String.IsNullOrEmpty(portName))
            {
                MessageBox.Show("You must select a portName to continue");
                return;
            }

            MinoltaTTenControllerFactory.ConfigureMotorController(portName);

            controller = MinoltaTTenControllerFactory.GetSensorController();
            controller.PropertyChanged += controller_PropertyChanged;
        }

        private void controller_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "reading")
            {
                txtReading.Invoke(() => 
                    txtReading.Text = controller.reading.ToString("0.###"));
            }
        }
    }
}
