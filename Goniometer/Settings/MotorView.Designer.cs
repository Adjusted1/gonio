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
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision170 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision171 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision172 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision173 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision174 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision175 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision176 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision177 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision178 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision179 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision180 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision181 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision182 = new NationalInstruments.UI.ScaleCustomDivision();
            this.gaugeVertical = new NationalInstruments.UI.WindowsForms.Gauge();
            this.gaugeHorizontal = new NationalInstruments.UI.WindowsForms.Gauge();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVerticalAngle = new System.Windows.Forms.Label();
            this.lblHorizontalAngle = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.gaugeVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHorizontal)).BeginInit();
            this.SuspendLayout();
            // 
            // gaugeVertical
            // 
            scaleCustomDivision170.Text = "0";
            scaleCustomDivision171.Text = "45";
            scaleCustomDivision171.Value = 45D;
            scaleCustomDivision172.Text = "90";
            scaleCustomDivision172.Value = 90D;
            scaleCustomDivision173.Text = "135";
            scaleCustomDivision173.Value = 135D;
            scaleCustomDivision174.Text = "180";
            scaleCustomDivision174.Value = 180D;
            this.gaugeVertical.CustomDivisions.AddRange(new NationalInstruments.UI.ScaleCustomDivision[] {
            scaleCustomDivision170,
            scaleCustomDivision171,
            scaleCustomDivision172,
            scaleCustomDivision173,
            scaleCustomDivision174});
            this.gaugeVertical.Location = new System.Drawing.Point(128, 75);
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
            scaleCustomDivision175.Text = "0";
            scaleCustomDivision176.Text = "45";
            scaleCustomDivision176.Value = 45D;
            scaleCustomDivision177.Text = "90";
            scaleCustomDivision177.Value = 90D;
            scaleCustomDivision178.Text = "135";
            scaleCustomDivision178.Value = 135D;
            scaleCustomDivision179.Text = "180";
            scaleCustomDivision179.Value = 180D;
            scaleCustomDivision180.Text = "225";
            scaleCustomDivision180.Value = 225D;
            scaleCustomDivision181.Text = "270";
            scaleCustomDivision181.Value = 270D;
            scaleCustomDivision182.Text = "315";
            scaleCustomDivision182.Value = 315D;
            this.gaugeHorizontal.CustomDivisions.AddRange(new NationalInstruments.UI.ScaleCustomDivision[] {
            scaleCustomDivision175,
            scaleCustomDivision176,
            scaleCustomDivision177,
            scaleCustomDivision178,
            scaleCustomDivision179,
            scaleCustomDivision180,
            scaleCustomDivision181,
            scaleCustomDivision182});
            this.gaugeHorizontal.Location = new System.Drawing.Point(128, 279);
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
            this.label1.Location = new System.Drawing.Point(164, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vertical Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 263);
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
            // lblVerticalAngle
            // 
            this.lblVerticalAngle.AutoSize = true;
            this.lblVerticalAngle.Location = new System.Drawing.Point(186, 223);
            this.lblVerticalAngle.Name = "lblVerticalAngle";
            this.lblVerticalAngle.Size = new System.Drawing.Size(34, 13);
            this.lblVerticalAngle.TabIndex = 14;
            this.lblVerticalAngle.Text = "0.000";
            // 
            // lblHorizontalAngle
            // 
            this.lblHorizontalAngle.AutoSize = true;
            this.lblHorizontalAngle.Location = new System.Drawing.Point(186, 428);
            this.lblHorizontalAngle.Name = "lblHorizontalAngle";
            this.lblHorizontalAngle.Size = new System.Drawing.Size(34, 13);
            this.lblHorizontalAngle.TabIndex = 15;
            this.lblHorizontalAngle.Text = "0.000";
            // 
            // btnVerticalCW5
            // 
            this.btnVerticalCW5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerticalCW5.Enabled = false;
            this.btnVerticalCW5.Location = new System.Drawing.Point(286, 59);
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
            this.btnVerticalCW1.Location = new System.Drawing.Point(286, 88);
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
            this.btnVerticalCW01.Location = new System.Drawing.Point(286, 117);
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
            this.btnVerticalCCW5.Location = new System.Drawing.Point(286, 146);
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
            this.btnVerticalCCW1.Location = new System.Drawing.Point(286, 175);
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
            this.btnVerticalCCW01.Location = new System.Drawing.Point(286, 204);
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
            this.btnHorizontalCCW01.Location = new System.Drawing.Point(286, 423);
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
            this.btnHorizontalCCW1.Location = new System.Drawing.Point(286, 395);
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
            this.btnHorizontalCCW5.Location = new System.Drawing.Point(286, 366);
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
            this.btnHorizontalCW01.Location = new System.Drawing.Point(286, 337);
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
            this.btnHorizontalCW1.Location = new System.Drawing.Point(286, 308);
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
            this.btnHorizontalCW5.Location = new System.Drawing.Point(286, 279);
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
            this.btnZero.Location = new System.Drawing.Point(106, 480);
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
            this.btnExit.Location = new System.Drawing.Point(286, 480);
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
            this.chkZero.Location = new System.Drawing.Point(109, 457);
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
            this.btnPanic.Size = new System.Drawing.Size(88, 492);
            this.btnPanic.TabIndex = 31;
            this.btnPanic.TabStop = false;
            this.btnPanic.Text = "STOP";
            this.btnPanic.UseVisualStyleBackColor = false;
            // 
            // MotorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 512);
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
            this.Controls.Add(this.lblHorizontalAngle);
            this.Controls.Add(this.lblVerticalAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gaugeHorizontal);
            this.Controls.Add(this.gaugeVertical);
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
        private System.Windows.Forms.Label lblVerticalAngle;
        private System.Windows.Forms.Label lblHorizontalAngle;
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
    }
}

