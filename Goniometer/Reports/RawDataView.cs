using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer_Controller.Functions;
using Goniometer_Controller.Models;

namespace Goniometer.Reports
{
    public partial class RawDataView : UserControl
    {
        public RawDataView()
        {
            InitializeComponent();
        }

        public void SetDataSource(IEnumerable<MeasurementBase> datasource)
        {
            measurementGridView.DataSource = datasource;

            UpdateLumenCount();
        }

        private void UpdateLumenCount()
        {
            lblLumens.Text = "";

            if (measurementGridView.DataSource == null)
                return;

            var measurements = measurementGridView.DataSource as IEnumerable<MeasurementBase>;
            if (measurements == null)
                return;

            lblLumens.Text = String.Format("{0:0.##}", LightMath.CalculateLumens(measurements));
        }
    }
}
