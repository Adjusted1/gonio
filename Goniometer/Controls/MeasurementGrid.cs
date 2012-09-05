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

            var nameCell = new DataGridViewTextBoxCell();
            var nameCol = new DataGridViewTextBoxColumn
            {
                CellTemplate = nameCell,
                Name = "SensorName",
                HeaderText = "Sensor Name",
                DataPropertyName = "SensorName",
                ReadOnly = true
            };
            this.Columns.Add(nameCol);

            var portCell = new DataGridViewTextBoxCell();
            var portCol = new DataGridViewTextBoxColumn
            {
                CellTemplate = portCell,
                Name = "PortName",
                HeaderText = "Port",
                DataPropertyName = "PortName",
                ReadOnly = true
            };
            this.Columns.Add(portCol);

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
