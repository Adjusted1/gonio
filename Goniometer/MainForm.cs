using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Goniometer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void motorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var view = new MotorView())
            {
                view.ShowDialog();
            }
        }

        private void sensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var view = new SensorView())
            {
                view.ShowDialog();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            using (var view = new Test())
            {
                view.ShowDialog();
            }
        }
    }
}
