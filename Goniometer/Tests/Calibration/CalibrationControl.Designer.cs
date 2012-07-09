namespace Goniometer.Tests.Calibration
{
    partial class CalibrationControl
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
            this.wizardPages1 = new WizardPages();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.tabProgress = new System.Windows.Forms.TabPage();
            this.tabCompletion = new System.Windows.Forms.TabPage();
            this.lumenTestProgressControl1 = new Goniometer.LumenTestProgressControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.wizardPages1.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardPages1
            // 
            this.wizardPages1.Controls.Add(this.tabSetup);
            this.wizardPages1.Controls.Add(this.tabProgress);
            this.wizardPages1.Controls.Add(this.tabCompletion);
            this.wizardPages1.Location = new System.Drawing.Point(4, 4);
            this.wizardPages1.Name = "wizardPages1";
            this.wizardPages1.SelectedIndex = 0;
            this.wizardPages1.Size = new System.Drawing.Size(721, 561);
            this.wizardPages1.TabIndex = 0;
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.button4);
            this.tabSetup.Controls.Add(this.button3);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(713, 535);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // tabProgress
            // 
            this.tabProgress.Controls.Add(this.button2);
            this.tabProgress.Controls.Add(this.button1);
            this.tabProgress.Controls.Add(this.lumenTestProgressControl1);
            this.tabProgress.Location = new System.Drawing.Point(4, 22);
            this.tabProgress.Name = "tabProgress";
            this.tabProgress.Padding = new System.Windows.Forms.Padding(3);
            this.tabProgress.Size = new System.Drawing.Size(713, 535);
            this.tabProgress.TabIndex = 1;
            this.tabProgress.Text = "Progress";
            this.tabProgress.UseVisualStyleBackColor = true;
            // 
            // tabCompletion
            // 
            this.tabCompletion.Location = new System.Drawing.Point(4, 22);
            this.tabCompletion.Name = "tabCompletion";
            this.tabCompletion.Size = new System.Drawing.Size(713, 535);
            this.tabCompletion.TabIndex = 2;
            this.tabCompletion.Text = "Completion";
            this.tabCompletion.UseVisualStyleBackColor = true;
            // 
            // lumenTestProgressControl1
            // 
            this.lumenTestProgressControl1.Location = new System.Drawing.Point(7, 7);
            this.lumenTestProgressControl1.MinimumSize = new System.Drawing.Size(270, 327);
            this.lumenTestProgressControl1.Name = "lumenTestProgressControl1";
            this.lumenTestProgressControl1.Size = new System.Drawing.Size(700, 468);
            this.lumenTestProgressControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 505);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(632, 506);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 505);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // CalibrationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wizardPages1);
            this.Name = "CalibrationControl";
            this.Size = new System.Drawing.Size(728, 568);
            this.wizardPages1.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPages wizardPages1;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabProgress;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private LumenTestProgressControl lumenTestProgressControl1;
        private System.Windows.Forms.TabPage tabCompletion;
    }
}
