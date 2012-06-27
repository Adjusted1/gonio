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
            this.label1 = new System.Windows.Forms.Label();
            this.txtReading = new System.Windows.Forms.TextBox();
            this.cboPortNames = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpSensorType = new System.Windows.Forms.GroupBox();
            this.radSensorTypeT10 = new System.Windows.Forms.RadioButton();
            this.radSensorTypeCL200 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.grpSensorType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reading";
            // 
            // txtReading
            // 
            this.txtReading.Location = new System.Drawing.Point(37, 306);
            this.txtReading.Name = "txtReading";
            this.txtReading.Size = new System.Drawing.Size(100, 20);
            this.txtReading.TabIndex = 1;
            this.txtReading.Text = "0.000";
            // 
            // cboPortNames
            // 
            this.cboPortNames.FormattingEnabled = true;
            this.cboPortNames.Location = new System.Drawing.Point(37, 173);
            this.cboPortNames.Name = "cboPortNames";
            this.cboPortNames.Size = new System.Drawing.Size(133, 21);
            this.cboPortNames.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(37, 210);
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
            this.grpSensorType.Location = new System.Drawing.Point(37, 29);
            this.grpSensorType.Name = "grpSensorType";
            this.grpSensorType.Size = new System.Drawing.Size(133, 94);
            this.grpSensorType.TabIndex = 4;
            this.grpSensorType.TabStop = false;
            this.grpSensorType.Text = "Sensor Type";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Communications Port";
            // 
            // SensorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 380);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpSensorType);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboPortNames);
            this.Controls.Add(this.txtReading);
            this.Controls.Add(this.label1);
            this.Name = "SensorView";
            this.Text = "SensorView";
            this.Load += new System.EventHandler(this.SensorView_Load);
            this.grpSensorType.ResumeLayout(false);
            this.grpSensorType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReading;
        private System.Windows.Forms.ComboBox cboPortNames;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpSensorType;
        private System.Windows.Forms.RadioButton radSensorTypeCL200;
        private System.Windows.Forms.RadioButton radSensorTypeT10;
        private System.Windows.Forms.Label label2;
    }
}