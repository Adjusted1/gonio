using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Goniometer.Tests
{
    public partial class TestListControl : UserControl
    {
        public TestListControl()
        {
            InitializeComponent();
        }

        private void TestListControl_Load(object sender, EventArgs e)
        {
            cboTest.Items.Add("Lumen Test");
        }

        public string TestName
        {
            get
            {
                return cboTest.Text;
            }
        }

        private void cboTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTest.Text == "Lumen Test")
            {

            }
        }

        public event EventHandler btnTest_Clicked;
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboTest.Text))
                return;

            var notify = btnTest_Clicked;
            if (notify != null)
                notify(this, e);
        }
    }
}
