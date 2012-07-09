namespace Goniometer
{
    partial class SensorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboPortNames = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpSensorType = new System.Windows.Forms.GroupBox();
            this.radSensorTypeCL200 = new System.Windows.Forms.RadioButton();
            this.radSensorTypeT10 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.gridReadings = new System.Windows.Forms.DataGridView();
            this.timerSensor = new System.Windows.Forms.Timer(this.components);
            this.grpSensorType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReadings)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPortNames
            // 
            this.cboPortNames.FormattingEnabled = true;
            this.cboPortNames.Location = new System.Drawing.Point(12, 125);
            this.cboPortNames.Name = "cboPortNames";
            this.cboPortNames.Size = new System.Drawing.Size(75, 21);
            this.cboPortNames.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 152);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpSensorType
            // 
            this.grpSensorType.Controls.Add(this.radSensorTypeCL200);
            this.grpSensorType.Controls.Add(this.radSensorTypeT10);
            this.grpSensorType.Location = new System.Drawing.Point(12, 12);
            this.grpSensorType.Name = "grpSensorType";
            this.grpSensorType.Size = new System.Drawing.Size(133, 94);
            this.grpSensorType.TabIndex = 4;
            this.grpSensorType.TabStop = false;
            this.grpSensorType.Text = "Sensor Type";
            // 
            // radSensorTypeCL200
            // 
            this.radSensorTypeCL200.AutoSize = true;
            this.radSensorTypeCL200.Location = new System.Drawing.Point(17, 54);
            this.radSensorTypeCL200.Name = "radSensorTypeCL200";
            this.radSensorTypeCL200.Size = new System.Drawing.Size(93, 17);
            this.radSensorTypeCL200.TabIndex = 1;
            this.radSensorTypeCL200.TabStop = true;
            this.radSensorTypeCL200.Text = "Minolta CL200";
            this.radSensorTypeCL200.UseVisualStyleBackColor = true;
            // 
            // radSensorTypeT10
            // 
            this.radSensorTypeT10.AutoSize = true;
            this.radSensorTypeT10.Location = new System.Drawing.Point(18, 31);
            this.radSensorTypeT10.Name = "radSensorTypeT10";
            this.radSensorTypeT10.Size = new System.Drawing.Size(81, 17);
            this.radSensorTypeT10.TabIndex = 0;
            this.radSensorTypeT10.TabStop = true;
            this.radSensorTypeT10.Text = "Minolta T10";
            this.radSensorTypeT10.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 181);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Select";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // gridReadings
            // 
            this.gridReadings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReadings.Location = new System.Drawing.Point(151, 12);
            this.gridReadings.Name = "gridReadings";
            this.gridReadings.Size = new System.Drawing.Size(326, 192);
            this.gridReadings.TabIndex = 2;
            // 
            // timerSensor
            // 
            this.timerSensor.Enabled = true;
            this.timerSensor.Tick += new System.EventHandler(this.timerSensor_Tick);
            // 
            // SensorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 212);
            this.Controls.Add(this.gridReadings);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpSensorType);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboPortNames);
            this.Name = "SensorView";
            this.Text = "Sensor Settings";
            this.Load += new System.EventHandler(this.SensorView_Load);
            this.grpSensorType.ResumeLayout(false);
            this.grpSensorType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReadings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPortNames;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpSensorType;
        private System.Windows.Forms.RadioButton radSensorTypeCL200;
        private System.Windows.Forms.RadioButton radSensorTypeT10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView gridReadings;
        private System.Windows.Forms.Timer timerSensor;
    }
}