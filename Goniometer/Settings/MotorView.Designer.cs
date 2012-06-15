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
            this.txtVerticalAngle = new System.Windows.Forms.TextBox();
            this.txtHorizontalAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
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
            this.gaugeVertical.Location = new System.Drawing.Point(12, 100);
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
            this.gaugeHorizontal.Location = new System.Drawing.Point(200, 100);
            this.gaugeHorizontal.MajorDivisions.LabelVisible = false;
            this.gaugeHorizontal.MajorDivisions.TickVisible = false;
            this.gaugeHorizontal.MinorDivisions.TickVisible = false;
            this.gaugeHorizontal.Name = "gaugeHorizontal";
            this.gaugeHorizontal.Range = new NationalInstruments.UI.Range(0D, 360D);
            this.gaugeHorizontal.ScaleArc = new NationalInstruments.UI.Arc(270F, -360F);
            this.gaugeHorizontal.Size = new System.Drawing.Size(145, 145);
            this.gaugeHorizontal.TabIndex = 1;
            // 
            // txtVerticalAngle
            // 
            this.txtVerticalAngle.Location = new System.Drawing.Point(12, 251);
            this.txtVerticalAngle.Name = "txtVerticalAngle";
            this.txtVerticalAngle.Size = new System.Drawing.Size(145, 20);
            this.txtVerticalAngle.TabIndex = 2;
            // 
            // txtHorizontalAngle
            // 
            this.txtHorizontalAngle.Location = new System.Drawing.Point(200, 251);
            this.txtHorizontalAngle.Name = "txtHorizontalAngle";
            this.txtHorizontalAngle.Size = new System.Drawing.Size(145, 20);
            this.txtHorizontalAngle.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vertical Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Horizontal Angle";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(270, 277);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(12, 12);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(145, 20);
            this.txtIPAddress.TabIndex = 8;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(188, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // MotorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 315);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHorizontalAngle);
            this.Controls.Add(this.txtVerticalAngle);
            this.Controls.Add(this.gaugeHorizontal);
            this.Controls.Add(this.gaugeVertical);
            this.Name = "MotorView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MotorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gaugeVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHorizontal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.Gauge gaugeVertical;
        private NationalInstruments.UI.WindowsForms.Gauge gaugeHorizontal;
        private System.Windows.Forms.TextBox txtVerticalAngle;
        private System.Windows.Forms.TextBox txtHorizontalAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Button btnConnect;
    }
}

