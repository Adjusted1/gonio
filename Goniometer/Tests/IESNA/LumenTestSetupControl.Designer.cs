namespace Goniometer
{
    partial class LumenTestSetupControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpLamp = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTestNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVerticalResolution = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.radHorizontalFull = new System.Windows.Forms.RadioButton();
            this.groupHorizontal = new System.Windows.Forms.GroupBox();
            this.radHorizontalSingle = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.radHorizontalQuarter = new System.Windows.Forms.RadioButton();
            this.radHorizontalHalf = new System.Windows.Forms.RadioButton();
            this.txtHorizontalResolution = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupVertical = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radVerticalFull = new System.Windows.Forms.RadioButton();
            this.radVerticalBottom = new System.Windows.Forms.RadioButton();
            this.radVerticalTop = new System.Windows.Forms.RadioButton();
            this.groupSensor = new System.Windows.Forms.GroupBox();
            this.controlSensorSetup = new Goniometer.Setup.SensorSetup();
            this.groupCalibration = new System.Windows.Forms.GroupBox();
            this.grpLamp.SuspendLayout();
            this.groupHorizontal.SuspendLayout();
            this.groupVertical.SuspendLayout();
            this.groupSensor.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLamp
            // 
            this.grpLamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLamp.Controls.Add(this.textBox1);
            this.grpLamp.Controls.Add(this.label6);
            this.grpLamp.Controls.Add(this.txtManufacturer);
            this.grpLamp.Controls.Add(this.label5);
            this.grpLamp.Controls.Add(this.txtTestNumber);
            this.grpLamp.Controls.Add(this.label2);
            this.grpLamp.Location = new System.Drawing.Point(3, 3);
            this.grpLamp.Name = "grpLamp";
            this.grpLamp.Size = new System.Drawing.Size(394, 108);
            this.grpLamp.TabIndex = 24;
            this.grpLamp.TabStop = false;
            this.grpLamp.Text = "Lamp Information";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "# of Lamps";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(91, 45);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(100, 20);
            this.txtManufacturer.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Manufacturer";
            // 
            // txtTestNumber
            // 
            this.txtTestNumber.Location = new System.Drawing.Point(91, 19);
            this.txtTestNumber.Name = "txtTestNumber";
            this.txtTestNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTestNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Test Number";
            // 
            // txtVerticalResolution
            // 
            this.txtVerticalResolution.Location = new System.Drawing.Point(6, 19);
            this.txtVerticalResolution.Name = "txtVerticalResolution";
            this.txtVerticalResolution.Size = new System.Drawing.Size(150, 20);
            this.txtVerticalResolution.TabIndex = 4;
            this.txtVerticalResolution.TextChanged += new System.EventHandler(this.txtVerticalResolution_TextChanged);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(545, 353);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(49, 13);
            this.lblTime.TabIndex = 23;
            this.lblTime.Text = "00:00:00";
            // 
            // radHorizontalFull
            // 
            this.radHorizontalFull.AutoSize = true;
            this.radHorizontalFull.Checked = true;
            this.radHorizontalFull.Location = new System.Drawing.Point(9, 65);
            this.radHorizontalFull.Name = "radHorizontalFull";
            this.radHorizontalFull.Size = new System.Drawing.Size(51, 17);
            this.radHorizontalFull.TabIndex = 9;
            this.radHorizontalFull.TabStop = true;
            this.radHorizontalFull.Text = "None";
            this.radHorizontalFull.UseVisualStyleBackColor = true;
            this.radHorizontalFull.CheckedChanged += new System.EventHandler(this.radHorizontalFull_CheckedChanged);
            // 
            // groupHorizontal
            // 
            this.groupHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupHorizontal.Controls.Add(this.radHorizontalSingle);
            this.groupHorizontal.Controls.Add(this.label10);
            this.groupHorizontal.Controls.Add(this.radHorizontalFull);
            this.groupHorizontal.Controls.Add(this.radHorizontalQuarter);
            this.groupHorizontal.Controls.Add(this.radHorizontalHalf);
            this.groupHorizontal.Controls.Add(this.txtHorizontalResolution);
            this.groupHorizontal.Location = new System.Drawing.Point(203, 117);
            this.groupHorizontal.Name = "groupHorizontal";
            this.groupHorizontal.Size = new System.Drawing.Size(194, 200);
            this.groupHorizontal.TabIndex = 22;
            this.groupHorizontal.TabStop = false;
            this.groupHorizontal.Text = "Horizontal Resolution";
            // 
            // radHorizontalSingle
            // 
            this.radHorizontalSingle.AutoSize = true;
            this.radHorizontalSingle.Location = new System.Drawing.Point(9, 134);
            this.radHorizontalSingle.Name = "radHorizontalSingle";
            this.radHorizontalSingle.Size = new System.Drawing.Size(146, 17);
            this.radHorizontalSingle.TabIndex = 12;
            this.radHorizontalSingle.Text = "Full (Single Measurement)";
            this.radHorizontalSingle.UseVisualStyleBackColor = true;
            this.radHorizontalSingle.CheckedChanged += new System.EventHandler(this.radHorizontalSingle_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Horizontal Symmetry";
            // 
            // radHorizontalQuarter
            // 
            this.radHorizontalQuarter.AutoSize = true;
            this.radHorizontalQuarter.Location = new System.Drawing.Point(9, 111);
            this.radHorizontalQuarter.Name = "radHorizontalQuarter";
            this.radHorizontalQuarter.Size = new System.Drawing.Size(84, 17);
            this.radHorizontalQuarter.TabIndex = 11;
            this.radHorizontalQuarter.Text = "Quadrilateral";
            this.radHorizontalQuarter.UseVisualStyleBackColor = true;
            this.radHorizontalQuarter.CheckedChanged += new System.EventHandler(this.radHorizontalQuarter_CheckedChanged);
            // 
            // radHorizontalHalf
            // 
            this.radHorizontalHalf.AutoSize = true;
            this.radHorizontalHalf.Location = new System.Drawing.Point(9, 88);
            this.radHorizontalHalf.Name = "radHorizontalHalf";
            this.radHorizontalHalf.Size = new System.Drawing.Size(62, 17);
            this.radHorizontalHalf.TabIndex = 10;
            this.radHorizontalHalf.Text = "Bilateral";
            this.radHorizontalHalf.UseVisualStyleBackColor = true;
            this.radHorizontalHalf.CheckedChanged += new System.EventHandler(this.radHorizontalHalf_CheckedChanged);
            // 
            // txtHorizontalResolution
            // 
            this.txtHorizontalResolution.Location = new System.Drawing.Point(6, 19);
            this.txtHorizontalResolution.Name = "txtHorizontalResolution";
            this.txtHorizontalResolution.Size = new System.Drawing.Size(141, 20);
            this.txtHorizontalResolution.TabIndex = 8;
            this.txtHorizontalResolution.TextChanged += new System.EventHandler(this.txtHorizontalResolution_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(3, 350);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(135, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // chkEmail
            // 
            this.chkEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(3, 326);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(135, 17);
            this.chkEmail.TabIndex = 14;
            this.chkEmail.Text = "Email Upon Completion";
            this.chkEmail.UseVisualStyleBackColor = true;
            this.chkEmail.CheckedChanged += new System.EventHandler(this.chkEmail_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Time Estimate:";
            // 
            // groupVertical
            // 
            this.groupVertical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupVertical.Controls.Add(this.label9);
            this.groupVertical.Controls.Add(this.radVerticalFull);
            this.groupVertical.Controls.Add(this.radVerticalBottom);
            this.groupVertical.Controls.Add(this.radVerticalTop);
            this.groupVertical.Controls.Add(this.txtVerticalResolution);
            this.groupVertical.Location = new System.Drawing.Point(3, 117);
            this.groupVertical.Name = "groupVertical";
            this.groupVertical.Size = new System.Drawing.Size(194, 200);
            this.groupVertical.TabIndex = 21;
            this.groupVertical.TabStop = false;
            this.groupVertical.Text = "Vertical Resolution";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Vertical Symmetry";
            // 
            // radVerticalFull
            // 
            this.radVerticalFull.AutoSize = true;
            this.radVerticalFull.Checked = true;
            this.radVerticalFull.Location = new System.Drawing.Point(6, 65);
            this.radVerticalFull.Name = "radVerticalFull";
            this.radVerticalFull.Size = new System.Drawing.Size(111, 17);
            this.radVerticalFull.TabIndex = 5;
            this.radVerticalFull.TabStop = true;
            this.radVerticalFull.Text = "Both Hemispheres";
            this.radVerticalFull.UseVisualStyleBackColor = true;
            this.radVerticalFull.CheckedChanged += new System.EventHandler(this.radVerticalFull_CheckedChanged);
            // 
            // radVerticalBottom
            // 
            this.radVerticalBottom.AutoSize = true;
            this.radVerticalBottom.Location = new System.Drawing.Point(6, 111);
            this.radVerticalBottom.Name = "radVerticalBottom";
            this.radVerticalBottom.Size = new System.Drawing.Size(141, 17);
            this.radVerticalBottom.TabIndex = 7;
            this.radVerticalBottom.Text = "Bottom Hemisphere Only";
            this.radVerticalBottom.UseVisualStyleBackColor = true;
            this.radVerticalBottom.CheckedChanged += new System.EventHandler(this.radVerticalBottom_CheckedChanged);
            // 
            // radVerticalTop
            // 
            this.radVerticalTop.AutoSize = true;
            this.radVerticalTop.Location = new System.Drawing.Point(6, 88);
            this.radVerticalTop.Name = "radVerticalTop";
            this.radVerticalTop.Size = new System.Drawing.Size(127, 17);
            this.radVerticalTop.TabIndex = 6;
            this.radVerticalTop.Text = "Top Hemisphere Only";
            this.radVerticalTop.UseVisualStyleBackColor = true;
            this.radVerticalTop.CheckedChanged += new System.EventHandler(this.radVerticalTop_CheckedChanged);
            // 
            // groupSensor
            // 
            this.groupSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSensor.Controls.Add(this.controlSensorSetup);
            this.groupSensor.Location = new System.Drawing.Point(404, 118);
            this.groupSensor.Name = "groupSensor";
            this.groupSensor.Size = new System.Drawing.Size(190, 199);
            this.groupSensor.TabIndex = 25;
            this.groupSensor.TabStop = false;
            this.groupSensor.Text = "Sensor";
            // 
            // controlSensorSetup
            // 
            this.controlSensorSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlSensorSetup.Location = new System.Drawing.Point(7, 18);
            this.controlSensorSetup.Name = "controlSensorSetup";
            this.controlSensorSetup.Size = new System.Drawing.Size(177, 175);
            this.controlSensorSetup.TabIndex = 13;
            // 
            // groupCalibration
            // 
            this.groupCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCalibration.Location = new System.Drawing.Point(404, 3);
            this.groupCalibration.Name = "groupCalibration";
            this.groupCalibration.Size = new System.Drawing.Size(190, 108);
            this.groupCalibration.TabIndex = 26;
            this.groupCalibration.TabStop = false;
            this.groupCalibration.Text = "Calibration";
            // 
            // LumenTestSetupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupCalibration);
            this.Controls.Add(this.groupSensor);
            this.Controls.Add(this.grpLamp);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.groupHorizontal);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupVertical);
            this.MinimumSize = new System.Drawing.Size(411, 376);
            this.Name = "LumenTestSetupControl";
            this.Size = new System.Drawing.Size(608, 376);
            this.grpLamp.ResumeLayout(false);
            this.grpLamp.PerformLayout();
            this.groupHorizontal.ResumeLayout(false);
            this.groupHorizontal.PerformLayout();
            this.groupVertical.ResumeLayout(false);
            this.groupVertical.PerformLayout();
            this.groupSensor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLamp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTestNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVerticalResolution;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.RadioButton radHorizontalFull;
        private System.Windows.Forms.GroupBox groupHorizontal;
        private System.Windows.Forms.RadioButton radHorizontalQuarter;
        private System.Windows.Forms.RadioButton radHorizontalHalf;
        private System.Windows.Forms.TextBox txtHorizontalResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupVertical;
        private System.Windows.Forms.RadioButton radVerticalFull;
        private System.Windows.Forms.RadioButton radVerticalBottom;
        private System.Windows.Forms.RadioButton radVerticalTop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radHorizontalSingle;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.GroupBox groupSensor;
        private Setup.SensorSetup controlSensorSetup;
        private System.Windows.Forms.GroupBox groupCalibration;
    }
}
