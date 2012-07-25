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
            this.txtNumberOfLamps = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTestNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVerticalResolution = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.radHorizontalFull = new System.Windows.Forms.RadioButton();
            this.groupVerticalSymetry = new System.Windows.Forms.GroupBox();
            this.radHorizontalSingle = new System.Windows.Forms.RadioButton();
            this.radHorizontalQuarter = new System.Windows.Forms.RadioButton();
            this.radHorizontalHalf = new System.Windows.Forms.RadioButton();
            this.txtHorizontalResolution = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupResolution = new System.Windows.Forms.GroupBox();
            this.radVerticalFull = new System.Windows.Forms.RadioButton();
            this.radVerticalBottom = new System.Windows.Forms.RadioButton();
            this.radVerticalTop = new System.Windows.Forms.RadioButton();
            this.groupSensor = new System.Windows.Forms.GroupBox();
            this.groupCalibration = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDataFolder = new System.Windows.Forms.TextBox();
            this.btnDataFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.controlSensorSetup = new Goniometer.Setup.SensorSetup();
            this.cboStrayResolution = new System.Windows.Forms.ComboBox();
            this.txtHorizontalStrayResolution = new System.Windows.Forms.TextBox();
            this.txtVerticalStrayResolution = new System.Windows.Forms.TextBox();
            this.groupHorizontalSymetry = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grpLamp.SuspendLayout();
            this.groupVerticalSymetry.SuspendLayout();
            this.groupResolution.SuspendLayout();
            this.groupSensor.SuspendLayout();
            this.groupHorizontalSymetry.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLamp
            // 
            this.grpLamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLamp.Controls.Add(this.txtNumberOfLamps);
            this.grpLamp.Controls.Add(this.label6);
            this.grpLamp.Controls.Add(this.txtManufacturer);
            this.grpLamp.Controls.Add(this.label5);
            this.grpLamp.Controls.Add(this.txtTestNumber);
            this.grpLamp.Controls.Add(this.label2);
            this.grpLamp.Location = new System.Drawing.Point(3, 31);
            this.grpLamp.Name = "grpLamp";
            this.grpLamp.Size = new System.Drawing.Size(394, 108);
            this.grpLamp.TabIndex = 24;
            this.grpLamp.TabStop = false;
            this.grpLamp.Text = "Lamp Information";
            // 
            // txtNumberOfLamps
            // 
            this.txtNumberOfLamps.Location = new System.Drawing.Point(91, 71);
            this.txtNumberOfLamps.Name = "txtNumberOfLamps";
            this.txtNumberOfLamps.Size = new System.Drawing.Size(100, 20);
            this.txtNumberOfLamps.TabIndex = 3;
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
            this.txtVerticalResolution.Location = new System.Drawing.Point(63, 19);
            this.txtVerticalResolution.Name = "txtVerticalResolution";
            this.txtVerticalResolution.Size = new System.Drawing.Size(125, 20);
            this.txtVerticalResolution.TabIndex = 4;
            this.txtVerticalResolution.TextChanged += new System.EventHandler(this.txtVerticalResolution_TextChanged);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(545, 448);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(49, 13);
            this.lblTime.TabIndex = 23;
            this.lblTime.Text = "00:00:00";
            // 
            // radHorizontalFull
            // 
            this.radHorizontalFull.AutoSize = true;
            this.radHorizontalFull.Checked = true;
            this.radHorizontalFull.Location = new System.Drawing.Point(6, 19);
            this.radHorizontalFull.Name = "radHorizontalFull";
            this.radHorizontalFull.Size = new System.Drawing.Size(51, 17);
            this.radHorizontalFull.TabIndex = 9;
            this.radHorizontalFull.TabStop = true;
            this.radHorizontalFull.Text = "None";
            this.radHorizontalFull.UseVisualStyleBackColor = true;
            this.radHorizontalFull.CheckedChanged += new System.EventHandler(this.radHorizontalFull_CheckedChanged);
            // 
            // groupVerticalSymetry
            // 
            this.groupVerticalSymetry.Controls.Add(this.radVerticalFull);
            this.groupVerticalSymetry.Controls.Add(this.radVerticalBottom);
            this.groupVerticalSymetry.Controls.Add(this.radVerticalTop);
            this.groupVerticalSymetry.Location = new System.Drawing.Point(203, 145);
            this.groupVerticalSymetry.Name = "groupVerticalSymetry";
            this.groupVerticalSymetry.Size = new System.Drawing.Size(194, 93);
            this.groupVerticalSymetry.TabIndex = 22;
            this.groupVerticalSymetry.TabStop = false;
            this.groupVerticalSymetry.Text = "Vertical Symetry";
            // 
            // radHorizontalSingle
            // 
            this.radHorizontalSingle.AutoSize = true;
            this.radHorizontalSingle.Location = new System.Drawing.Point(6, 88);
            this.radHorizontalSingle.Name = "radHorizontalSingle";
            this.radHorizontalSingle.Size = new System.Drawing.Size(146, 17);
            this.radHorizontalSingle.TabIndex = 12;
            this.radHorizontalSingle.Text = "Full (Single Measurement)";
            this.radHorizontalSingle.UseVisualStyleBackColor = true;
            this.radHorizontalSingle.CheckedChanged += new System.EventHandler(this.radHorizontalSingle_CheckedChanged);
            // 
            // radHorizontalQuarter
            // 
            this.radHorizontalQuarter.AutoSize = true;
            this.radHorizontalQuarter.Location = new System.Drawing.Point(6, 65);
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
            this.radHorizontalHalf.Location = new System.Drawing.Point(6, 42);
            this.radHorizontalHalf.Name = "radHorizontalHalf";
            this.radHorizontalHalf.Size = new System.Drawing.Size(62, 17);
            this.radHorizontalHalf.TabIndex = 10;
            this.radHorizontalHalf.Text = "Bilateral";
            this.radHorizontalHalf.UseVisualStyleBackColor = true;
            this.radHorizontalHalf.CheckedChanged += new System.EventHandler(this.radHorizontalHalf_CheckedChanged);
            // 
            // txtHorizontalResolution
            // 
            this.txtHorizontalResolution.Location = new System.Drawing.Point(63, 45);
            this.txtHorizontalResolution.Name = "txtHorizontalResolution";
            this.txtHorizontalResolution.Size = new System.Drawing.Size(125, 20);
            this.txtHorizontalResolution.TabIndex = 8;
            this.txtHorizontalResolution.TextChanged += new System.EventHandler(this.txtHorizontalResolution_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(3, 445);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(135, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // chkEmail
            // 
            this.chkEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(3, 421);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(112, 17);
            this.chkEmail.TabIndex = 14;
            this.chkEmail.Text = "Email Notifications";
            this.chkEmail.UseVisualStyleBackColor = true;
            this.chkEmail.CheckedChanged += new System.EventHandler(this.chkEmail_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Time Estimate:";
            // 
            // groupResolution
            // 
            this.groupResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupResolution.Controls.Add(this.label11);
            this.groupResolution.Controls.Add(this.label10);
            this.groupResolution.Controls.Add(this.label9);
            this.groupResolution.Controls.Add(this.label8);
            this.groupResolution.Controls.Add(this.label7);
            this.groupResolution.Controls.Add(this.label4);
            this.groupResolution.Controls.Add(this.txtHorizontalStrayResolution);
            this.groupResolution.Controls.Add(this.txtVerticalStrayResolution);
            this.groupResolution.Controls.Add(this.cboStrayResolution);
            this.groupResolution.Controls.Add(this.txtVerticalResolution);
            this.groupResolution.Controls.Add(this.txtHorizontalResolution);
            this.groupResolution.Location = new System.Drawing.Point(3, 145);
            this.groupResolution.Name = "groupResolution";
            this.groupResolution.Size = new System.Drawing.Size(194, 261);
            this.groupResolution.TabIndex = 21;
            this.groupResolution.TabStop = false;
            this.groupResolution.Text = "Resolution";
            // 
            // radVerticalFull
            // 
            this.radVerticalFull.AutoSize = true;
            this.radVerticalFull.Location = new System.Drawing.Point(6, 20);
            this.radVerticalFull.Name = "radVerticalFull";
            this.radVerticalFull.Size = new System.Drawing.Size(111, 17);
            this.radVerticalFull.TabIndex = 5;
            this.radVerticalFull.Text = "Both Hemispheres";
            this.radVerticalFull.UseVisualStyleBackColor = true;
            this.radVerticalFull.CheckedChanged += new System.EventHandler(this.radVerticalFull_CheckedChanged);
            // 
            // radVerticalBottom
            // 
            this.radVerticalBottom.AutoSize = true;
            this.radVerticalBottom.Location = new System.Drawing.Point(6, 66);
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
            this.radVerticalTop.Location = new System.Drawing.Point(6, 43);
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
            this.groupSensor.Location = new System.Drawing.Point(404, 145);
            this.groupSensor.Name = "groupSensor";
            this.groupSensor.Size = new System.Drawing.Size(190, 267);
            this.groupSensor.TabIndex = 25;
            this.groupSensor.TabStop = false;
            this.groupSensor.Text = "Sensor";
            // 
            // groupCalibration
            // 
            this.groupCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCalibration.Location = new System.Drawing.Point(404, 31);
            this.groupCalibration.Name = "groupCalibration";
            this.groupCalibration.Size = new System.Drawing.Size(190, 108);
            this.groupCalibration.TabIndex = 26;
            this.groupCalibration.TabStop = false;
            this.groupCalibration.Text = "Calibration";
            // 
            // txtDataFolder
            // 
            this.txtDataFolder.Location = new System.Drawing.Point(77, 5);
            this.txtDataFolder.Name = "txtDataFolder";
            this.txtDataFolder.Size = new System.Drawing.Size(381, 20);
            this.txtDataFolder.TabIndex = 28;
            // 
            // btnDataFolder
            // 
            this.btnDataFolder.Location = new System.Drawing.Point(464, 3);
            this.btnDataFolder.Name = "btnDataFolder";
            this.btnDataFolder.Size = new System.Drawing.Size(141, 23);
            this.btnDataFolder.TabIndex = 29;
            this.btnDataFolder.Text = "Select Folder";
            this.btnDataFolder.UseVisualStyleBackColor = true;
            this.btnDataFolder.Click += new System.EventHandler(this.btnDataFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Data Folder:";
            // 
            // controlSensorSetup
            // 
            this.controlSensorSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlSensorSetup.Location = new System.Drawing.Point(7, 18);
            this.controlSensorSetup.Name = "controlSensorSetup";
            this.controlSensorSetup.Size = new System.Drawing.Size(177, 243);
            this.controlSensorSetup.TabIndex = 13;
            // 
            // cboStrayResolution
            // 
            this.cboStrayResolution.FormattingEnabled = true;
            this.cboStrayResolution.Location = new System.Drawing.Point(63, 109);
            this.cboStrayResolution.Name = "cboStrayResolution";
            this.cboStrayResolution.Size = new System.Drawing.Size(125, 21);
            this.cboStrayResolution.TabIndex = 13;
            this.cboStrayResolution.SelectedIndexChanged += new System.EventHandler(this.cboStrayResolution_SelectedIndexChanged);
            // 
            // txtHorizontalStrayResolution
            // 
            this.txtHorizontalStrayResolution.Location = new System.Drawing.Point(63, 162);
            this.txtHorizontalStrayResolution.Name = "txtHorizontalStrayResolution";
            this.txtHorizontalStrayResolution.Size = new System.Drawing.Size(125, 20);
            this.txtHorizontalStrayResolution.TabIndex = 14;
            this.txtHorizontalStrayResolution.TextChanged += new System.EventHandler(this.txtHorizontalStrayResolution_TextChanged);
            // 
            // txtVerticalStrayResolution
            // 
            this.txtVerticalStrayResolution.Location = new System.Drawing.Point(63, 136);
            this.txtVerticalStrayResolution.Name = "txtVerticalStrayResolution";
            this.txtVerticalStrayResolution.Size = new System.Drawing.Size(125, 20);
            this.txtVerticalStrayResolution.TabIndex = 14;
            this.txtVerticalStrayResolution.TextChanged += new System.EventHandler(this.txtVerticalStrayResolution_TextChanged);
            // 
            // groupHorizontalSymetry
            // 
            this.groupHorizontalSymetry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupHorizontalSymetry.Controls.Add(this.radHorizontalSingle);
            this.groupHorizontalSymetry.Controls.Add(this.radHorizontalQuarter);
            this.groupHorizontalSymetry.Controls.Add(this.radHorizontalFull);
            this.groupHorizontalSymetry.Controls.Add(this.radHorizontalHalf);
            this.groupHorizontalSymetry.Location = new System.Drawing.Point(204, 245);
            this.groupHorizontalSymetry.Name = "groupHorizontalSymetry";
            this.groupHorizontalSymetry.Size = new System.Drawing.Size(194, 161);
            this.groupHorizontalSymetry.TabIndex = 30;
            this.groupHorizontalSymetry.TabStop = false;
            this.groupHorizontalSymetry.Text = "Horizontal Symetry";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Vertical";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Horizontal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Presets";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Vertical";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Horizontal";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Stray Resolutions";
            // 
            // LumenTestSetupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupHorizontalSymetry);
            this.Controls.Add(this.btnDataFolder);
            this.Controls.Add(this.txtDataFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupCalibration);
            this.Controls.Add(this.groupSensor);
            this.Controls.Add(this.grpLamp);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.groupVerticalSymetry);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupResolution);
            this.MinimumSize = new System.Drawing.Size(411, 376);
            this.Name = "LumenTestSetupControl";
            this.Size = new System.Drawing.Size(608, 471);
            this.grpLamp.ResumeLayout(false);
            this.grpLamp.PerformLayout();
            this.groupVerticalSymetry.ResumeLayout(false);
            this.groupVerticalSymetry.PerformLayout();
            this.groupResolution.ResumeLayout(false);
            this.groupResolution.PerformLayout();
            this.groupSensor.ResumeLayout(false);
            this.groupHorizontalSymetry.ResumeLayout(false);
            this.groupHorizontalSymetry.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLamp;
        private System.Windows.Forms.TextBox txtNumberOfLamps;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTestNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVerticalResolution;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.RadioButton radHorizontalFull;
        private System.Windows.Forms.GroupBox groupVerticalSymetry;
        private System.Windows.Forms.RadioButton radHorizontalQuarter;
        private System.Windows.Forms.RadioButton radHorizontalHalf;
        private System.Windows.Forms.TextBox txtHorizontalResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupResolution;
        private System.Windows.Forms.RadioButton radVerticalFull;
        private System.Windows.Forms.RadioButton radVerticalBottom;
        private System.Windows.Forms.RadioButton radVerticalTop;
        private System.Windows.Forms.RadioButton radHorizontalSingle;
        private System.Windows.Forms.GroupBox groupSensor;
        private Setup.SensorSetup controlSensorSetup;
        private System.Windows.Forms.GroupBox groupCalibration;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtDataFolder;
        private System.Windows.Forms.Button btnDataFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.TextBox txtHorizontalStrayResolution;
        private System.Windows.Forms.ComboBox cboStrayResolution;
        private System.Windows.Forms.TextBox txtVerticalStrayResolution;
        private System.Windows.Forms.GroupBox groupHorizontalSymetry;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
    }
}
