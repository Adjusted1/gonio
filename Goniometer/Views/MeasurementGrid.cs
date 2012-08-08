using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer_Controller;
using Goniometer_Controller.Models;

namespace Goniometer.Views
{
    public class MeasurementGridView : DataGridView
    {
        public MeasurementGridView()
        {
            this.AutoGenerateColumns = false;

            var keyCell = new DataGridViewTextBoxCell();
            var keyCol = new DataGridViewTextBoxColumn
            {
                CellTemplate = keyCell,
                Name = "Key",
                HeaderText = "Key",
                DataPropertyName = "Key",
                ReadOnly = true
            };
            this.Columns.Add(keyCol);

            var valueCell = new DataGridViewTextBoxCell();
            var valueCol = new DataGridViewTextBoxColumn
            {
                CellTemplate = valueCell,
                Name = "Value",
                HeaderText = "Value",
                DataPropertyName = "Value",
                ReadOnly = true
            };
            this.Columns.Add(valueCol);
        }
    }
}
