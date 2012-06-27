using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private MotorController controller;

        public MotorView()
        {
            InitializeComponent();
        }

        protected void MotorView_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress address = IPAddress.Parse(txtIPAddress.Text);
                MotorControllerFactory.ConfigureMotorController(address);

                controller = MotorControllerFactory.getMotorController();
                controller.PropertyChanged += controller_PropertyChanged;
            }
            catch (Exception ex)
            {

            }
        }

        protected void controller_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "horizontalAngle")
            {
                gaugeHorizontal.Value = controller.horizontalAngle;
                txtHorizontalAngle.Text = controller.horizontalAngle.ToString("0.##");
            }
            else if (e.PropertyName == "verticalAngle")
            {
                gaugeVertical.Value = controller.verticalAngle;
                txtVerticalAngle.Text = controller.verticalAngle.ToString("0.##");
            }
        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {
            IPAddress address;
            if (IPAddress.TryParse(txtIPAddress.Text, out address))
                btnConnect.Enabled = true;
            else
                btnConnect.Enabled = false;
        }
    }
}
