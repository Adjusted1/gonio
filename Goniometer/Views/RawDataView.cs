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
            BindDataSource(new BindingList<MeasurementBase>(datasource.ToList()));
        }

        public void BindDataSource(BindingList<MeasurementBase> datasource)
        {
            AssertDatasourceIsValid(datasource);

            measurementGridView.DataSource = datasource;

            UpdateLumenCount();
        }

        public IEnumerable<MeasurementBase> GetDataSource()
        {
            return measurementGridView.DataSource as IEnumerable<MeasurementBase>;
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

        private void AssertDatasourceIsValid(IEnumerable<MeasurementBase> datasource)
        {
            if (datasource == null)
                throw new ArgumentNullException("datasource cannot be null");
        }

        #region buttons
        public event EventHandler OnCloseClicked;

        private void btnClose_Click(object sender, EventArgs e)
        {
            var notify = OnCloseClicked;
            if (notify != null)
                OnCloseClicked(sender, e);    
        }

        public event EventHandler OnExportClicked;

        private void btnExport_Click(object sender, EventArgs e)
        {
            var notify = OnExportClicked;
            if (notify != null)
                OnExportClicked(sender, e);
        }
        #endregion
    }
}
