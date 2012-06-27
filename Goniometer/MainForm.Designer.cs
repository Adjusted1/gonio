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
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision14 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision15 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision16 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision17 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision18 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision19 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision20 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision21 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision22 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision23 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision24 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision25 = new NationalInstruments.UI.ScaleCustomDivision();
            NationalInstruments.UI.ScaleCustomDivision scaleCustomDivision26 = new NationalInstruments.UI.ScaleCustomDivision();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPanic = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gaugeHorizontal = new NationalInstruments.UI.WindowsForms.Gauge();
            this.gaugeVertical = new NationalInstruments.UI.WindowsForms.Gauge();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVerticalAngle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeVertical)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(935, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(250, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
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
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
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
            this.btnPanic.Size = new System.Drawing.Size(88, 492);
            this.btnPanic.TabIndex = 0;
            this.btnPanic.TabStop = false;
            this.btnPanic.Text = "STOP";
            this.btnPanic.UseVisualStyleBackColor = false;
            this.btnPanic.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelStatus.Controls.Add(this.btnExecute);
            this.panelStatus.Controls.Add(this.label3);
            this.panelStatus.Controls.Add(this.textBox1);
            this.panelStatus.Controls.Add(this.label4);
            this.panelStatus.Controls.Add(this.txtVerticalAngle);
            this.panelStatus.Controls.Add(this.btnSettings);
            this.panelStatus.Controls.Add(this.label2);
            this.panelStatus.Controls.Add(this.label1);
            this.panelStatus.Controls.Add(this.gaugeHorizontal);
            this.panelStatus.Controls.Add(this.gaugeVertical);
            this.panelStatus.Location = new System.Drawing.Point(784, 24);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(151, 496);
            this.panelStatus.TabIndex = 2;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(4, 466);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(140, 23);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
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
            scaleCustomDivision14.Text = "0";
            scaleCustomDivision15.Text = "45";
            scaleCustomDivision15.Value = 45D;
            scaleCustomDivision16.Text = "90";
            scaleCustomDivision16.Value = 90D;
            scaleCustomDivision17.Text = "135";
            scaleCustomDivision17.Value = 135D;
            scaleCustomDivision18.Text = "180";
            scaleCustomDivision18.Value = 180D;
            scaleCustomDivision19.Text = "225";
            scaleCustomDivision19.Value = 225D;
            scaleCustomDivision20.Text = "270";
            scaleCustomDivision20.Value = 270D;
            scaleCustomDivision21.Text = "315";
            scaleCustomDivision21.Value = 315D;
            this.gaugeHorizontal.CustomDivisions.AddRange(new NationalInstruments.UI.ScaleCustomDivision[] {
            scaleCustomDivision14,
            scaleCustomDivision15,
            scaleCustomDivision16,
            scaleCustomDivision17,
            scaleCustomDivision18,
            scaleCustomDivision19,
            scaleCustomDivision20,
            scaleCustomDivision21});
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
            scaleCustomDivision22.Text = "0";
            scaleCustomDivision23.Text = "45";
            scaleCustomDivision23.Value = 45D;
            scaleCustomDivision24.Text = "90";
            scaleCustomDivision24.Value = 90D;
            scaleCustomDivision25.Text = "135";
            scaleCustomDivision25.Value = 135D;
            scaleCustomDivision26.Text = "180";
            scaleCustomDivision26.Value = 180D;
            this.gaugeVertical.CustomDivisions.AddRange(new NationalInstruments.UI.ScaleCustomDivision[] {
            scaleCustomDivision22,
            scaleCustomDivision23,
            scaleCustomDivision24,
            scaleCustomDivision25,
            scaleCustomDivision26});
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
            this.panelMain.Controls.Add(this.btnTest);
            this.panelMain.Location = new System.Drawing.Point(106, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(677, 491);
            this.panelMain.TabIndex = 3;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(310, 236);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "0.000";
            // 
            // txtVerticalAngle
            // 
            this.txtVerticalAngle.Location = new System.Drawing.Point(42, 185);
            this.txtVerticalAngle.Name = "txtVerticalAngle";
            this.txtVerticalAngle.Size = new System.Drawing.Size(69, 20);
            this.txtVerticalAngle.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "0.000";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 401);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 20);
            this.textBox1.TabIndex = 17;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(4, 427);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(140, 23);
            this.btnExecute.TabIndex = 19;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 545);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.btnPanic);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(951, 583);
            this.Name = "MainForm";
            this.Text = "Goniometer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeVertical)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sensorToolStripMenuItem;
        private System.Windows.Forms.Button btnPanic;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private NationalInstruments.UI.WindowsForms.Gauge gaugeHorizontal;
        private NationalInstruments.UI.WindowsForms.Gauge gaugeVertical;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVerticalAngle;
        private System.Windows.Forms.Button btnExecute;
    }
}