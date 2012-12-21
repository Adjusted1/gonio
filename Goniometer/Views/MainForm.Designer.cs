namespace Goniometer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPanic = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.picVerticalAngleValid = new System.Windows.Forms.PictureBox();
            this.picHorizontalAngleValid = new System.Windows.Forms.PictureBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblVerticalAngle = new System.Windows.Forms.Label();
            this.txtHorizontalAngle = new System.Windows.Forms.TextBox();
            this.lblHorizontalAngle = new System.Windows.Forms.Label();
            this.txtVerticalAngle = new System.Windows.Forms.TextBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gaugeHorizontal = new NationalInstruments.UI.WindowsForms.Gauge();
            this.gaugeVertical = new NationalInstruments.UI.WindowsForms.Gauge();
            this.panelMain = new System.Windows.Forms.Panel();
            this.timerMotor = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVerticalAngleValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHorizontalAngleValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeVertical)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(935, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRawToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openRawToolStripMenuItem
            // 
            this.openRawToolStripMenuItem.Name = "openRawToolStripMenuItem";
            this.openRawToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openRawToolStripMenuItem.Text = "Open Raw";
            this.openRawToolStripMenuItem.Click += new System.EventHandler(this.openRawToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.motorToolStripMenuItem,
            this.sensorToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // motorToolStripMenuItem
            // 
            this.motorToolStripMenuItem.Name = "motorToolStripMenuItem";
            this.motorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.motorToolStripMenuItem.Text = "Motor";
            this.motorToolStripMenuItem.Click += new System.EventHandler(this.motorToolStripMenuItem_Click);
            // 
            // sensorToolStripMenuItem
            // 
            this.sensorToolStripMenuItem.Name = "sensorToolStripMenuItem";
            this.sensorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sensorToolStripMenuItem.Text = "Sensor";
            this.sensorToolStripMenuItem.Click += new System.EventHandler(this.sensorToolStripMenuItem_Click);
            // 
            // btnPanic
            // 
            this.btnPanic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPanic.BackColor = System.Drawing.Color.Red;
            this.btnPanic.Location = new System.Drawing.Point(12, 28);
            this.btnPanic.Name = "btnPanic";
            this.btnPanic.Size = new System.Drawing.Size(88, 505);
            this.btnPanic.TabIndex = 1;
            this.btnPanic.TabStop = false;
            this.btnPanic.Text = "STOP";
            this.btnPanic.UseVisualStyleBackColor = false;
            this.btnPanic.Click += new System.EventHandler(this.btnPanic_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelStatus.Controls.Add(this.picVerticalAngleValid);
            this.panelStatus.Controls.Add(this.picHorizontalAngleValid);
            this.panelStatus.Controls.Add(this.btnExecute);
            this.panelStatus.Controls.Add(this.lblVerticalAngle);
            this.panelStatus.Controls.Add(this.txtHorizontalAngle);
            this.panelStatus.Controls.Add(this.lblHorizontalAngle);
            this.panelStatus.Controls.Add(this.txtVerticalAngle);
            this.panelStatus.Controls.Add(this.btnSettings);
            this.panelStatus.Controls.Add(this.label2);
            this.panelStatus.Controls.Add(this.label1);
            this.panelStatus.Controls.Add(this.gaugeHorizontal);
            this.panelStatus.Controls.Add(this.gaugeVertical);
            this.panelStatus.Location = new System.Drawing.Point(784, 24);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(151, 509);
            this.panelStatus.TabIndex = 2;
            // 
            // picVerticalAngleValid
            // 
            this.picVerticalAngleValid.Image = ((System.Drawing.Image)(resources.GetObject("picVerticalAngleValid.Image")));
            this.picVerticalAngleValid.Location = new System.Drawing.Point(117, 401);
            this.picVerticalAngleValid.Name = "picVerticalAngleValid";
            this.picVerticalAngleValid.Size = new System.Drawing.Size(16, 16);
            this.picVerticalAngleValid.TabIndex = 20;
            this.picVerticalAngleValid.TabStop = false;
            this.picVerticalAngleValid.Visible = false;
            // 
            // picHorizontalAngleValid
            // 
            this.picHorizontalAngleValid.Image = ((System.Drawing.Image)(resources.GetObject("picHorizontalAngleValid.Image")));
            this.picHorizontalAngleValid.Location = new System.Drawing.Point(117, 185);
            this.picHorizontalAngleValid.Name = "picHorizontalAngleValid";
            this.picHorizontalAngleValid.Size = new System.Drawing.Size(16, 16);
            this.picHorizontalAngleValid.TabIndex = 0;
            this.picHorizontalAngleValid.TabStop = false;
            this.picHorizontalAngleValid.Visible = false;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(4, 450);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(140, 23);
            this.btnExecute.TabIndex = 5;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblVerticalAngle
            // 
            this.lblVerticalAngle.AutoSize = true;
            this.lblVerticalAngle.Location = new System.Drawing.Point(61, 384);
            this.lblVerticalAngle.Name = "lblVerticalAngle";
            this.lblVerticalAngle.Size = new System.Drawing.Size(13, 13);
            this.lblVerticalAngle.TabIndex = 18;
            this.lblVerticalAngle.Text = "?";
            // 
            // txtHorizontalAngle
            // 
            this.txtHorizontalAngle.Location = new System.Drawing.Point(42, 184);
            this.txtHorizontalAngle.Name = "txtHorizontalAngle";
            this.txtHorizontalAngle.Size = new System.Drawing.Size(69, 20);
            this.txtHorizontalAngle.TabIndex = 3;
            this.txtHorizontalAngle.Text = "0";
            this.txtHorizontalAngle.TextChanged += new System.EventHandler(this.txtHorizontalAngle_TextChanged);
            // 
            // lblHorizontalAngle
            // 
            this.lblHorizontalAngle.AutoSize = true;
            this.lblHorizontalAngle.Location = new System.Drawing.Point(61, 168);
            this.lblHorizontalAngle.Name = "lblHorizontalAngle";
            this.lblHorizontalAngle.Size = new System.Drawing.Size(13, 13);
            this.lblHorizontalAngle.TabIndex = 16;
            this.lblHorizontalAngle.Text = "?";
            // 
            // txtVerticalAngle
            // 
            this.txtVerticalAngle.Location = new System.Drawing.Point(42, 400);
            this.txtVerticalAngle.Name = "txtVerticalAngle";
            this.txtVerticalAngle.Size = new System.Drawing.Size(69, 20);
            this.txtVerticalAngle.TabIndex = 4;
            this.txtVerticalAngle.Text = "0";
            this.txtVerticalAngle.TextChanged += new System.EventHandler(this.txtVerticalAngle_TextChanged);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(4, 479);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(140, 23);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Horizontal Angle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Vertical Angle";
            // 
            // gaugeHorizontal
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
            scaleCustomDivision6.Text = "225";
            scaleCustomDivision6.Value = 225D;
            scaleCustomDivision7.Text = "270";
            scaleCustomDivision7.Value = 270D;
            scaleCustomDivision8.Text = "315";
            scaleCustomDivision8.Value = 315D;
            this.gaugeHorizontal.CustomDivisions.AddRange(new NationalInstruments.UI.ScaleCustomDivision[] {
            scaleCustomDivision1,
            scaleCustomDivision2,
            scaleCustomDivision3,
            scaleCustomDivision4,
            scaleCustomDivision5,
            scaleCustomDivision6,
            scaleCustomDivision7,
            scaleCustomDivision8});
            this.gaugeHorizontal.Location = new System.Drawing.Point(3, 19);
            this.gaugeHorizontal.MajorDivisions.LabelVisible = false;
            this.gaugeHorizontal.MajorDivisions.TickVisible = false;
            this.gaugeHorizontal.MinorDivisions.TickVisible = false;
            this.gaugeHorizontal.Name = "gaugeHorizontal";
            this.gaugeHorizontal.Range = new NationalInstruments.UI.Range(0D, 360D);
            this.gaugeHorizontal.ScaleArc = new NationalInstruments.UI.Arc(270F, -360F);
            this.gaugeHorizontal.Size = new System.Drawing.Size(145, 145);
            this.gaugeHorizontal.TabIndex = 7;
            // 
            // gaugeVertical
            // 
            scaleCustomDivision9.Text = "0";
            scaleCustomDivision10.Text = "45";
            scaleCustomDivision10.Value = 45D;
            scaleCustomDivision11.Text = "90";
            scaleCustomDivision11.Value = 90D;
            scaleCustomDivision12.Text = "135";
            scaleCustomDivision12.Value = 135D;
            scaleCustomDivision13.Text = "180";
            scaleCustomDivision13.Value = 180D;
            this.gaugeVertical.CustomDivisions.AddRange(new NationalInstruments.UI.ScaleCustomDivision[] {
            scaleCustomDivision9,
            scaleCustomDivision10,
            scaleCustomDivision11,
            scaleCustomDivision12,
            scaleCustomDivision13});
            this.gaugeVertical.Location = new System.Drawing.Point(3, 233);
            this.gaugeVertical.MajorDivisions.LabelVisible = false;
            this.gaugeVertical.MajorDivisions.TickVisible = false;
            this.gaugeVertical.MinorDivisions.TickVisible = false;
            this.gaugeVertical.Name = "gaugeVertical";
            this.gaugeVertical.Range = new NationalInstruments.UI.Range(0D, 180D);
            this.gaugeVertical.ScaleArc = new NationalInstruments.UI.Arc(270F, -180F);
            this.gaugeVertical.Size = new System.Drawing.Size(145, 145);
            this.gaugeVertical.TabIndex = 6;
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Location = new System.Drawing.Point(106, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(677, 508);
            this.panelMain.TabIndex = 2;
            // 
            // timerMotor
            // 
            this.timerMotor.Enabled = true;
            this.timerMotor.Tick += new System.EventHandler(this.timerMotor_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "csv";
            this.openFileDialog.FileName = "raw.csv";
            this.openFileDialog.Filter = "All files|*.*|CSV Files|*.csv";
            this.openFileDialog.FilterIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 545);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.btnPanic);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(951, 583);
            this.Name = "MainForm";
            this.Text = "Goniometer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVerticalAngleValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHorizontalAngleValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeVertical)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sensorToolStripMenuItem;
        private System.Windows.Forms.Button btnPanic;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private NationalInstruments.UI.WindowsForms.Gauge gaugeHorizontal;
        private NationalInstruments.UI.WindowsForms.Gauge gaugeVertical;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblVerticalAngle;
        private System.Windows.Forms.TextBox txtHorizontalAngle;
        private System.Windows.Forms.Label lblHorizontalAngle;
        private System.Windows.Forms.TextBox txtVerticalAngle;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.PictureBox picVerticalAngleValid;
        private System.Windows.Forms.PictureBox picHorizontalAngleValid;
        private System.Windows.Forms.Timer timerMotor;
        private System.Windows.Forms.ToolStripMenuItem openRawToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}