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
            cboTest.Items.Add("Calibration Test");
            cboTest.Items.Add("Lumen Test");
        }

        public string SelectedTest
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            SelectTest();
        }

        private void cboTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Return)
                SelectTest();
        }

        public event EventHandler OnTestSelected;
        private void SelectTest()
        {
            if (String.IsNullOrEmpty(cboTest.Text))
                return;

            var notify = OnTestSelected;
            if (notify != null)
                notify(this, null);
        }
    }
}
