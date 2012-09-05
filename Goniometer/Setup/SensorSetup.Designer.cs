namespace Goniometer.Setup
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
            this.btnReset = new System.Windows.Forms.Button();
            this.measurementGridView = new Goniometer.Views.MeasurementGridView();
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
            this.cboSensor.Size = new System.Drawing.Size(162, 21);
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
            this.cboPort.Size = new System.Drawing.Size(162, 21);
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
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(90, 57);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // measurementGridView
            // 
            this.measurementGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.measurementGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.measurementGridView.Location = new System.Drawing.Point(3, 86);
            this.measurementGridView.Name = "measurementGridView";
            this.measurementGridView.Size = new System.Drawing.Size(162, 113);
            this.measurementGridView.TabIndex = 5;
            // 
            // SensorSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.measurementGridView);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cboPort);
            this.Controls.Add(this.cboSensor);
            this.Name = "SensorSetup";
            this.Size = new System.Drawing.Size(168, 202);
            this.Load += new System.EventHandler(this.SensorSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.measurementGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSensor;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnReset;
        private Views.MeasurementGridView measurementGridView;
    }
}
