namespace Goniometer.Workflows.IESNA
{
    partial class LumenTestControl
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
            this.wizard = new WizardPages();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.setupControl = new Goniometer.LumenTestSetupControl();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabProgress = new System.Windows.Forms.TabPage();
            this.progressControl = new Goniometer.LumenTestProgressControl();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabCompletion = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.wizard.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabProgress.SuspendLayout();
            this.tabCompletion.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wizard.Controls.Add(this.tabSetup);
            this.wizard.Controls.Add(this.tabProgress);
            this.wizard.Controls.Add(this.tabCompletion);
            this.wizard.Location = new System.Drawing.Point(3, 3);
            this.wizard.Name = "wizard";
            this.wizard.SelectedIndex = 0;
            this.wizard.Size = new System.Drawing.Size(957, 679);
            this.wizard.TabIndex = 0;
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.setupControl);
            this.tabSetup.Controls.Add(this.btnBack);
            this.tabSetup.Controls.Add(this.btnStart);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(949, 653);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // setupControl
            // 
            this.setupControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.setupControl.Email = "";
            this.setupControl.EmailNotifications = false;
            this.setupControl.Location = new System.Drawing.Point(6, 6);
            this.setupControl.MinimumSize = new System.Drawing.Size(411, 430);
            this.setupControl.Name = "setupControl";
            this.setupControl.Size = new System.Drawing.Size(937, 612);
            this.setupControl.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Location = new System.Drawing.Point(6, 624);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(868, 624);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabProgress
            // 
            this.tabProgress.Controls.Add(this.progressControl);
            this.tabProgress.Controls.Add(this.btnPause);
            this.tabProgress.Controls.Add(this.btnCancel);
            this.tabProgress.Location = new System.Drawing.Point(4, 22);
            this.tabProgress.Name = "tabProgress";
            this.tabProgress.Padding = new System.Windows.Forms.Padding(3);
            this.tabProgress.Size = new System.Drawing.Size(949, 653);
            this.tabProgress.TabIndex = 1;
            this.tabProgress.Text = "Progress";
            this.tabProgress.UseVisualStyleBackColor = true;
            // 
            // progressControl
            // 
            this.progressControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressControl.DataFolder = "C:\\";
            this.progressControl.Email = "";
            this.progressControl.EmailNotifications = false;
            this.progressControl.Location = new System.Drawing.Point(6, 6);
            this.progressControl.MinimumSize = new System.Drawing.Size(270, 327);
            this.progressControl.Name = "progressControl";
            this.progressControl.Size = new System.Drawing.Size(937, 612);
            this.progressControl.TabIndex = 4;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Location = new System.Drawing.Point(868, 624);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(6, 624);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabCompletion
            // 
            this.tabCompletion.Controls.Add(this.btnClose);
            this.tabCompletion.Location = new System.Drawing.Point(4, 22);
            this.tabCompletion.Name = "tabCompletion";
            this.tabCompletion.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompletion.Size = new System.Drawing.Size(949, 653);
            this.tabCompletion.TabIndex = 2;
            this.tabCompletion.Text = "Completion";
            this.tabCompletion.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(868, 624);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LumenTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wizard);
            this.Name = "LumenTestControl";
            this.Size = new System.Drawing.Size(963, 685);
            this.Load += new System.EventHandler(this.LumenTestControl_Load);
            this.wizard.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabProgress.ResumeLayout(false);
            this.tabCompletion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPages wizard;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabProgress;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabCompletion;
        private System.Windows.Forms.Button btnClose;
        private LumenTestSetupControl setupControl;
        private LumenTestProgressControl progressControl;
    }
}
