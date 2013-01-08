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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPanic = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.timerMotor = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.motorControlHorizontal = new Goniometer.Controls.MotorControl();
            this.motorControlVertical = new Goniometer.Controls.MotorControl();
            this.menuStrip.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1103, 24);
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
            this.openRawToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
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
            this.motorToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.motorToolStripMenuItem.Text = "Motor";
            this.motorToolStripMenuItem.Click += new System.EventHandler(this.motorToolStripMenuItem_Click);
            // 
            // sensorToolStripMenuItem
            // 
            this.sensorToolStripMenuItem.Name = "sensorToolStripMenuItem";
            this.sensorToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
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
            this.btnPanic.Size = new System.Drawing.Size(88, 675);
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
            this.panelStatus.Controls.Add(this.motorControlHorizontal);
            this.panelStatus.Controls.Add(this.motorControlVertical);
            this.panelStatus.Location = new System.Drawing.Point(881, 24);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(222, 679);
            this.panelStatus.TabIndex = 2;
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Location = new System.Drawing.Point(106, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(771, 678);
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
            // motorControlHorizontal
            // 
            this.motorControlHorizontal.GaugeAngle = 0F;
            this.motorControlHorizontal.Location = new System.Drawing.Point(0, 262);
            this.motorControlHorizontal.MaxGaugeAngle = 360;
            this.motorControlHorizontal.Name = "motorControlHorizontal";
            this.motorControlHorizontal.Size = new System.Drawing.Size(220, 258);
            this.motorControlHorizontal.TabIndex = 11;
            this.motorControlHorizontal.TextBoxValue = 0D;
            this.motorControlHorizontal.OnButtonGoClicked += new System.EventHandler<double?>(this.motorControlHorizontal_OnButtonGoClicked);
            // 
            // motorControlVertical
            // 
            this.motorControlVertical.GaugeAngle = 0F;
            this.motorControlVertical.Location = new System.Drawing.Point(0, 0);
            this.motorControlVertical.MaxGaugeAngle = 180;
            this.motorControlVertical.Name = "motorControlVertical";
            this.motorControlVertical.Size = new System.Drawing.Size(220, 258);
            this.motorControlVertical.TabIndex = 10;
            this.motorControlVertical.TextBoxValue = 0D;
            this.motorControlVertical.OnButtonGoClicked += new System.EventHandler<double?>(this.motorControlVertical_OnButtonGoClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 715);
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
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Timer timerMotor;
        private System.Windows.Forms.ToolStripMenuItem openRawToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Controls.MotorControl motorControlHorizontal;
        private Controls.MotorControl motorControlVertical;
    }
}