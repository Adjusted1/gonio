namespace Goniometer
{
    partial class MotorView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision1 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision2 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision3 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision4 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision5 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision6 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision7 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision8 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision9 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision10 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision11 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision12 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision13 = new NationalInstruments.UI.ScaleCustomDivision();
            this.gaugeVertical = new NationalInstruments.UI.WindowsForms.Gauge();
            this.gaugeHorizontal = new NationalInstruments.UI.WindowsForms.Gauge();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVerticalMotorAngle = new System.Windows.Forms.Label();
            this.lblHorizontalMotorAngle = new System.Windows.Forms.Label();
            this.btnVerticalCW5 = new System.Windows.Forms.Button();
            this.btnVerticalCW1 = new System.Windows.Forms.Button();
            this.btnVerticalCW01 = new System.Windows.Forms.Button();
            this.btnVerticalCCW5 = new System.Windows.Forms.Button();
            this.btnVerticalCCW1 = new System.Windows.Forms.Button();
            this.btnVerticalCCW01 = new System.Windows.Forms.Button();
            this.btnHorizontalCCW01 = new System.Windows.Forms.Button();
            this.btnHorizontalCCW1 = new System.Windows.Forms.Button();
            this.btnHorizontalCCW5 = new System.Windows.Forms.Button();
            this.btnHorizontalCW01 = new System.Windows.Forms.Button();
            this.btnHorizontalCW1 = new System.Windows.Forms.Button();
            this.btnHorizontalCW5 = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.chkZero = new System.Windows.Forms.CheckBox();
            this.timerMotor = new System.Windows.Forms.Timer(this.components);
            this.btnPanic = new System.Windows.Forms.Button();
            this.lblHorizontalLoadAngle = new System.Windows.Forms.Label();
            this.lblVerticalLoadAngle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHorizontal)).BeginInit();
            this.SuspendLayout();
            // 
            // gaugeVertical
            // 
            scaleCustomDivision1.Text = "0";
            scaleCustomDivision2.Text = "45";
            scaleCustomDivision2.Value = 45D;
            scaleCustomDivision3.Text = "90";
            scaleCustomDivision3.Value = 90D;
            scaleCustomDivision4.Text = "135";
            scaleCustomDivision4.Value = 135D;
            scaleCustomDivision5.Text = "180";
            scaleCustomDivision5.Value = 180D;
            this.gaugeVertical.CustomDivisions.AddRange(new NationalInstruments.UI.ScaleCustomDivision[] {
            scaleCustomDivision1,
            scaleCustomDivision2,
            scaleCustomDivision3,
            scaleCustomDivision4,
            scaleCustomDivision5});
            this.gaugeVertical.Location = new System.Drawing.Point(128, 279);
            this.gaugeVertical.MajorDivisions.LabelVisible = false;
            this.gaugeVertical.MajorDivisions.TickVisible = false;
            this.gaugeVertical.MinorDivisions.TickVisible = false;
            this.gaugeVertical.Name = "gaugeVertical";
            this.gaugeVertical.Range = new NationalInstruments.UI.Range(0D, 180D);
            this.gaugeVertical.ScaleArc = new NationalInstruments.UI.Arc(270F, -180F);
            this.gaugeVertical.Size = new System.Drawing.Size(145, 145);
            this.gaugeVertical.TabIndex = 0;
            // 
            // gaugeHorizontal
            // 
            scaleCustomDivision6.Text = "0";
            scaleCustomDivision7.Text = "45";
            scaleCustomDivision7.Value = 45D;
            scaleCustomDivision8.Text = "90";
            scaleCustomDivision8.Value = 90D;
            scaleCustomDivision9.Text = "135";
            scaleCustomDivision9.Value = 135D;
            scaleCustomDivision10.Text = "180";
            scaleCustomDivision10.Value = 180D;
            scaleCustomDivision11.Text = "225";
            scaleCustomDivision11.Value = 225D;
            scaleCustomDivision12.Text = "270";
            scaleCustomDivision12.Value = 270D;
            scaleCustomDivision13.Text = "315";
            scaleCustomDivision13.Value = 315D;
            this.gaugeHorizontal.CustomDivisions.AddRange(new NationalInstruments.UI.ScaleCustomDivision[] {
            scaleCustomDivision6,
            scaleCustomDivision7,
            scaleCustomDivision8,
            scaleCustomDivision9,
            scaleCustomDivision10,
            scaleCustomDivision11,
            scaleCustomDivision12,
            scaleCustomDivision13});
            this.gaugeHorizontal.Location = new System.Drawing.Point(128, 61);
            this.gaugeHorizontal.MajorDivisions.LabelVisible = false;
            this.gaugeHorizontal.MajorDivisions.TickVisible = false;
            this.gaugeHorizontal.MinorDivisions.TickVisible = false;
            this.gaugeHorizontal.Name = "gaugeHorizontal";
            this.gaugeHorizontal.Range = new NationalInstruments.UI.Range(0D, 360D);
            this.gaugeHorizontal.ScaleArc = new NationalInstruments.UI.Arc(270F, -360F);
            this.gaugeHorizontal.Size = new System.Drawing.Size(145, 145);
            this.gaugeHorizontal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vertical Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Horizontal Angle";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(167, 13);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(108, 20);
            this.txtIPAddress.TabIndex = 8;
            this.txtIPAddress.TextChanged += new System.EventHandler(this.txtIPAddress_TextChanged);
            this.txtIPAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIPAddress_KeyDown);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(286, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "IPAddress";
            // 
            // lblVerticalMotorAngle
            // 
            this.lblVerticalMotorAngle.AutoSize = true;
            this.lblVerticalMotorAngle.Location = new System.Drawing.Point(186, 427);
            this.lblVerticalMotorAngle.Name = "lblVerticalMotorAngle";
            this.lblVerticalMotorAngle.Size = new System.Drawing.Size(34, 13);
            this.lblVerticalMotorAngle.TabIndex = 14;
            this.lblVerticalMotorAngle.Text = "0.000";
            // 
            // lblHorizontalMotorAngle
            // 
            this.lblHorizontalMotorAngle.AutoSize = true;
            this.lblHorizontalMotorAngle.Location = new System.Drawing.Point(186, 210);
            this.lblHorizontalMotorAngle.Name = "lblHorizontalMotorAngle";
            this.lblHorizontalMotorAngle.Size = new System.Drawing.Size(34, 13);
            this.lblHorizontalMotorAngle.TabIndex = 15;
            this.lblHorizontalMotorAngle.Text = "0.000";
            // 
            // btnVerticalCW5
            // 
            this.btnVerticalCW5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerticalCW5.Enabled = false;
            this.btnVerticalCW5.Location = new System.Drawing.Point(286, 268);
            this.btnVerticalCW5.Name = "btnVerticalCW5";
            this.btnVerticalCW5.Size = new System.Drawing.Size(75, 23);
            this.btnVerticalCW5.TabIndex = 16;
            this.btnVerticalCW5.Text = "CW 5";
            this.btnVerticalCW5.UseVisualStyleBackColor = true;
            this.btnVerticalCW5.Click += new System.EventHandler(this.btnVerticalCW5_Click);
            // 
            // btnVerticalCW1
            // 
            this.btnVerticalCW1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerticalCW1.Enabled = false;
            this.btnVerticalCW1.Location = new System.Drawing.Point(286, 297);
            this.btnVerticalCW1.Name = "btnVerticalCW1";
            this.btnVerticalCW1.Size = new System.Drawing.Size(75, 23);
            this.btnVerticalCW1.TabIndex = 17;
            this.btnVerticalCW1.Text = "CW 1";
            this.btnVerticalCW1.UseVisualStyleBackColor = true;
            this.btnVerticalCW1.Click += new System.EventHandler(this.btnVerticalCW1_Click);
            // 
            // btnVerticalCW01
            // 
            this.btnVerticalCW01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerticalCW01.Enabled = false;
            this.btnVerticalCW01.Location = new System.Drawing.Point(286, 326);
            this.btnVerticalCW01.Name = "btnVerticalCW01";
            this.btnVerticalCW01.Size = new System.Drawing.Size(75, 23);
            this.btnVerticalCW01.TabIndex = 18;
            this.btnVerticalCW01.Text = "CW 0.1";
            this.btnVerticalCW01.UseVisualStyleBackColor = true;
            this.btnVerticalCW01.Click += new System.EventHandler(this.btnVerticalCW01_Click);
            // 
            // btnVerticalCCW5
            // 
            this.btnVerticalCCW5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerticalCCW5.Enabled = false;
            this.btnVerticalCCW5.Location = new System.Drawing.Point(286, 355);
            this.btnVerticalCCW5.Name = "btnVerticalCCW5";
            this.btnVerticalCCW5.Size = new System.Drawing.Size(75, 23);
            this.btnVerticalCCW5.TabIndex = 19;
            this.btnVerticalCCW5.Text = "CCW 5";
            this.btnVerticalCCW5.UseVisualStyleBackColor = true;
            this.btnVerticalCCW5.Click += new System.EventHandler(this.btnVerticalCCW5_Click);
            // 
            // btnVerticalCCW1
            // 
            this.btnVerticalCCW1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerticalCCW1.Enabled = false;
            this.btnVerticalCCW1.Location = new System.Drawing.Point(286, 384);
            this.btnVerticalCCW1.Name = "btnVerticalCCW1";
            this.btnVerticalCCW1.Size = new System.Drawing.Size(75, 23);
            this.btnVerticalCCW1.TabIndex = 20;
            this.btnVerticalCCW1.Text = "CCW1";
            this.btnVerticalCCW1.UseVisualStyleBackColor = true;
            this.btnVerticalCCW1.Click += new System.EventHandler(this.btnVerticalCCW1_Click);
            // 
            // btnVerticalCCW01
            // 
            this.btnVerticalCCW01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerticalCCW01.Enabled = false;
            this.btnVerticalCCW01.Location = new System.Drawing.Point(286, 413);
            this.btnVerticalCCW01.Name = "btnVerticalCCW01";
            this.btnVerticalCCW01.Size = new System.Drawing.Size(75, 23);
            this.btnVerticalCCW01.TabIndex = 21;
            this.btnVerticalCCW01.Text = "CCW 0.1";
            this.btnVerticalCCW01.UseVisualStyleBackColor = true;
            this.btnVerticalCCW01.Click += new System.EventHandler(this.btnVerticalCCW01_Click);
            // 
            // btnHorizontalCCW01
            // 
            this.btnHorizontalCCW01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorizontalCCW01.Enabled = false;
            this.btnHorizontalCCW01.Location = new System.Drawing.Point(286, 194);
            this.btnHorizontalCCW01.Name = "btnHorizontalCCW01";
            this.btnHorizontalCCW01.Size = new System.Drawing.Size(75, 23);
            this.btnHorizontalCCW01.TabIndex = 27;
            this.btnHorizontalCCW01.Text = "CCW 0.1";
            this.btnHorizontalCCW01.UseVisualStyleBackColor = true;
            this.btnHorizontalCCW01.Click += new System.EventHandler(this.btnHorizontalCCW01_Click);
            // 
            // btnHorizontalCCW1
            // 
            this.btnHorizontalCCW1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorizontalCCW1.Enabled = false;
            this.btnHorizontalCCW1.Location = new System.Drawing.Point(286, 166);
            this.btnHorizontalCCW1.Name = "btnHorizontalCCW1";
            this.btnHorizontalCCW1.Size = new System.Drawing.Size(75, 23);
            this.btnHorizontalCCW1.TabIndex = 26;
            this.btnHorizontalCCW1.Text = "CCW 1";
            this.btnHorizontalCCW1.UseVisualStyleBackColor = true;
            this.btnHorizontalCCW1.Click += new System.EventHandler(this.btnHorizontalCCW1_Click);
            // 
            // btnHorizontalCCW5
            // 
            this.btnHorizontalCCW5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorizontalCCW5.Enabled = false;
            this.btnHorizontalCCW5.Location = new System.Drawing.Point(286, 137);
            this.btnHorizontalCCW5.Name = "btnHorizontalCCW5";
            this.btnHorizontalCCW5.Size = new System.Drawing.Size(75, 23);
            this.btnHorizontalCCW5.TabIndex = 25;
            this.btnHorizontalCCW5.Text = "CCW 5";
            this.btnHorizontalCCW5.UseVisualStyleBackColor = true;
            this.btnHorizontalCCW5.Click += new System.EventHandler(this.btnHorizontalCCW5_Click);
            // 
            // btnHorizontalCW01
            // 
            this.btnHorizontalCW01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorizontalCW01.Enabled = false;
            this.btnHorizontalCW01.Location = new System.Drawing.Point(286, 108);
            this.btnHorizontalCW01.Name = "btnHorizontalCW01";
            this.btnHorizontalCW01.Size = new System.Drawing.Size(75, 23);
            this.btnHorizontalCW01.TabIndex = 24;
            this.btnHorizontalCW01.Text = "CW 0.1";
            this.btnHorizontalCW01.UseVisualStyleBackColor = true;
            this.btnHorizontalCW01.Click += new System.EventHandler(this.btnHorizontalCW01_Click);
            // 
            // btnHorizontalCW1
            // 
            this.btnHorizontalCW1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorizontalCW1.Enabled = false;
            this.btnHorizontalCW1.Location = new System.Drawing.Point(286, 79);
            this.btnHorizontalCW1.Name = "btnHorizontalCW1";
            this.btnHorizontalCW1.Size = new System.Drawing.Size(75, 23);
            this.btnHorizontalCW1.TabIndex = 23;
            this.btnHorizontalCW1.Text = "CW 1";
            this.btnHorizontalCW1.UseVisualStyleBackColor = true;
            this.btnHorizontalCW1.Click += new System.EventHandler(this.btnHorizontalCW1_Click);
            // 
            // btnHorizontalCW5
            // 
            this.btnHorizontalCW5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorizontalCW5.Enabled = false;
            this.btnHorizontalCW5.Location = new System.Drawing.Point(286, 50);
            this.btnHorizontalCW5.Name = "btnHorizontalCW5";
            this.btnHorizontalCW5.Size = new System.Drawing.Size(75, 23);
            this.btnHorizontalCW5.TabIndex = 22;
            this.btnHorizontalCW5.Text = "CW 5";
            this.btnHorizontalCW5.UseVisualStyleBackColor = true;
            this.btnHorizontalCW5.Click += new System.EventHandler(this.btnHorizontalCW5_Click);
            // 
            // btnZero
            // 
            this.btnZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZero.Enabled = false;
            this.btnZero.Location = new System.Drawing.Point(106, 502);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(75, 23);
            this.btnZero.TabIndex = 28;
            this.btnZero.Text = "Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(286, 502);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkZero
            // 
            this.chkZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkZero.AutoSize = true;
            this.chkZero.Location = new System.Drawing.Point(109, 479);
            this.chkZero.Name = "chkZero";
            this.chkZero.Size = new System.Drawing.Size(78, 17);
            this.chkZero.TabIndex = 30;
            this.chkZero.Text = "Zero Mode";
            this.chkZero.UseVisualStyleBackColor = true;
            this.chkZero.CheckedChanged += new System.EventHandler(this.chkZero_CheckedChanged);
            // 
            // timerMotor
            // 
            this.timerMotor.Enabled = true;
            this.timerMotor.Tick += new System.EventHandler(this.timerMotor_Tick);
            // 
            // btnPanic
            // 
            this.btnPanic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPanic.BackColor = System.Drawing.Color.Red;
            this.btnPanic.Location = new System.Drawing.Point(12, 11);
            this.btnPanic.Name = "btnPanic";
            this.btnPanic.Size = new System.Drawing.Size(88, 514);
            this.btnPanic.TabIndex = 31;
            this.btnPanic.TabStop = false;
            this.btnPanic.Text = "STOP";
            this.btnPanic.UseVisualStyleBackColor = false;
            // 
            // lblHorizontalLoadAngle
            // 
            this.lblHorizontalLoadAngle.AutoSize = true;
            this.lblHorizontalLoadAngle.Location = new System.Drawing.Point(186, 226);
            this.lblHorizontalLoadAngle.Name = "lblHorizontalLoadAngle";
            this.lblHorizontalLoadAngle.Size = new System.Drawing.Size(34, 13);
            this.lblHorizontalLoadAngle.TabIndex = 32;
            this.lblHorizontalLoadAngle.Text = "0.000";
            // 
            // lblVerticalLoadAngle
            // 
            this.lblVerticalLoadAngle.AutoSize = true;
            this.lblVerticalLoadAngle.Location = new System.Drawing.Point(186, 443);
            this.lblVerticalLoadAngle.Name = "lblVerticalLoadAngle";
            this.lblVerticalLoadAngle.Size = new System.Drawing.Size(34, 13);
            this.lblVerticalLoadAngle.TabIndex = 33;
            this.lblVerticalLoadAngle.Text = "0.000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Motor Pos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Load Pos:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Load Pos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Motor Pos:";
            // 
            // MotorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 534);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblVerticalLoadAngle);
            this.Controls.Add(this.lblHorizontalLoadAngle);
            this.Controls.Add(this.btnPanic);
            this.Controls.Add(this.chkZero);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnHorizontalCCW01);
            this.Controls.Add(this.btnHorizontalCCW1);
            this.Controls.Add(this.btnHorizontalCCW5);
            this.Controls.Add(this.btnHorizontalCW01);
            this.Controls.Add(this.btnHorizontalCW1);
            this.Controls.Add(this.btnHorizontalCW5);
            this.Controls.Add(this.btnVerticalCCW01);
            this.Controls.Add(this.btnVerticalCCW1);
            this.Controls.Add(this.btnVerticalCCW5);
            this.Controls.Add(this.btnVerticalCW01);
            this.Controls.Add(this.btnVerticalCW1);
            this.Controls.Add(this.btnVerticalCW5);
            this.Controls.Add(this.lblHorizontalMotorAngle);
            this.Controls.Add(this.lblVerticalMotorAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gaugeHorizontal);
            this.Controls.Add(this.gaugeVertical);
            this.MinimumSize = new System.Drawing.Size(393, 533);
            this.Name = "MotorView";
            this.Text = "Motor Settings";
            this.Load += new System.EventHandler(this.MotorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gaugeVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHorizontal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.Gauge gaugeVertical;
        private NationalInstruments.UI.WindowsForms.Gauge gaugeHorizontal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVerticalMotorAngle;
        private System.Windows.Forms.Label lblHorizontalMotorAngle;
        private System.Windows.Forms.Button btnVerticalCW5;
        private System.Windows.Forms.Button btnVerticalCW1;
        private System.Windows.Forms.Button btnVerticalCW01;
        private System.Windows.Forms.Button btnVerticalCCW5;
        private System.Windows.Forms.Button btnVerticalCCW1;
        private System.Windows.Forms.Button btnVerticalCCW01;
        private System.Windows.Forms.Button btnHorizontalCCW01;
        private System.Windows.Forms.Button btnHorizontalCCW1;
        private System.Windows.Forms.Button btnHorizontalCCW5;
        private System.Windows.Forms.Button btnHorizontalCW01;
        private System.Windows.Forms.Button btnHorizontalCW1;
        private System.Windows.Forms.Button btnHorizontalCW5;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkZero;
        private System.Windows.Forms.Timer timerMotor;
        private System.Windows.Forms.Button btnPanic;
        private System.Windows.Forms.Label lblHorizontalLoadAngle;
        private System.Windows.Forms.Label lblVerticalLoadAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

