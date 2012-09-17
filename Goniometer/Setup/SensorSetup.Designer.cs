﻿namespace Goniometer.Setup
{
    partial class SensorSetup
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param sensorname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboSensor = new System.Windows.Forms.ComboBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.measurementGridView = new Goniometer.Views.MeasurementGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listSensors = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.measurementGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSensor
            // 
            this.cboSensor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSensor.FormattingEnabled = true;
            this.cboSensor.Location = new System.Drawing.Point(3, 3);
            this.cboSensor.Name = "cboSensor";
            this.cboSensor.Size = new System.Drawing.Size(517, 21);
            this.cboSensor.TabIndex = 1;
            this.cboSensor.SelectedIndexChanged += new System.EventHandler(this.cboSensor_SelectedIndexChanged);
            // 
            // cboPort
            // 
            this.cboPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPort.Enabled = false;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(3, 30);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(517, 21);
            this.cboPort.TabIndex = 2;
            this.cboPort.SelectedIndexChanged += new System.EventHandler(this.cboPort_SelectedIndexChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(3, 62);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(29, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Error";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(445, 57);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // measurementGridView
            // 
            this.measurementGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.measurementGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.measurementGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.measurementGridView.Location = new System.Drawing.Point(3, 86);
            this.measurementGridView.Name = "measurementGridView";
            this.measurementGridView.Size = new System.Drawing.Size(517, 200);
            this.measurementGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SensorName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Sensor Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PortName";
            this.dataGridViewTextBoxColumn6.HeaderText = "Port";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Key";
            this.dataGridViewTextBoxColumn7.HeaderText = "Key";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn8.HeaderText = "Value";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SensorName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Sensor Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PortName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Port";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Key";
            this.dataGridViewTextBoxColumn3.HeaderText = "Key";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // listSensors
            // 
            this.listSensors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listSensors.FormattingEnabled = true;
            this.listSensors.Location = new System.Drawing.Point(3, 292);
            this.listSensors.Name = "listSensors";
            this.listSensors.Size = new System.Drawing.Size(517, 82);
            this.listSensors.TabIndex = 6;
            // 
            // SensorSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listSensors);
            this.Controls.Add(this.measurementGridView);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cboPort);
            this.Controls.Add(this.cboSensor);
            this.Name = "SensorSetup";
            this.Size = new System.Drawing.Size(523, 377);
            this.Load += new System.EventHandler(this.SensorSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.measurementGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSensor;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnAdd;
        private Views.MeasurementGridView measurementGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ListBox listSensors;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}
