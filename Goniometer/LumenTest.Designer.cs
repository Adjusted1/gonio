namespace Goniometer
{
    partial class LumenTest
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
            this.txtVerticalResolution = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.radVerticalFull = new System.Windows.Forms.RadioButton();
            this.radVerticalTop = new System.Windows.Forms.RadioButton();
            this.radVerticalBottom = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.txtHorizontalResolution = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestNumber = new System.Windows.Forms.TextBox();
            this.grpLamp = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtStrayVerticalResolution = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpLamp.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVerticalResolution
            // 
            this.txtVerticalResolution.Location = new System.Drawing.Point(6, 31);
            this.txtVerticalResolution.Name = "txtVerticalResolution";
            this.txtVerticalResolution.Size = new System.Drawing.Size(141, 20);
            this.txtVerticalResolution.TabIndex = 0;
            this.txtVerticalResolution.TextChanged += new System.EventHandler(this.txtVerticalResolution_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vertical Resolution (degrees)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Completion Time Estimate:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(344, 389);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkEmail
            // 
            this.chkEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(15, 389);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(135, 17);
            this.chkEmail.TabIndex = 6;
            this.chkEmail.Text = "Email Upon Completion";
            this.chkEmail.UseVisualStyleBackColor = true;
            this.chkEmail.CheckedChanged += new System.EventHandler(this.chkEmail_CheckedChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(15, 413);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(135, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // radVerticalFull
            // 
            this.radVerticalFull.AutoSize = true;
            this.radVerticalFull.Checked = true;
            this.radVerticalFull.Location = new System.Drawing.Point(6, 157);
            this.radVerticalFull.Name = "radVerticalFull";
            this.radVerticalFull.Size = new System.Drawing.Size(111, 17);
            this.radVerticalFull.TabIndex = 8;
            this.radVerticalFull.TabStop = true;
            this.radVerticalFull.Text = "Both Hemispheres";
            this.radVerticalFull.UseVisualStyleBackColor = true;
            // 
            // radVerticalTop
            // 
            this.radVerticalTop.AutoSize = true;
            this.radVerticalTop.Location = new System.Drawing.Point(6, 180);
            this.radVerticalTop.Name = "radVerticalTop";
            this.radVerticalTop.Size = new System.Drawing.Size(127, 17);
            this.radVerticalTop.TabIndex = 9;
            this.radVerticalTop.Text = "Top Hemisphere Only";
            this.radVerticalTop.UseVisualStyleBackColor = true;
            // 
            // radVerticalBottom
            // 
            this.radVerticalBottom.AutoSize = true;
            this.radVerticalBottom.Location = new System.Drawing.Point(6, 203);
            this.radVerticalBottom.Name = "radVerticalBottom";
            this.radVerticalBottom.Size = new System.Drawing.Size(141, 17);
            this.radVerticalBottom.TabIndex = 10;
            this.radVerticalBottom.Text = "Bottom Hemisphere Only";
            this.radVerticalBottom.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txtStrayVerticalResolution);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.radVerticalFull);
            this.groupBox1.Controls.Add(this.radVerticalBottom);
            this.groupBox1.Controls.Add(this.radVerticalTop);
            this.groupBox1.Controls.Add(this.txtVerticalResolution);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 257);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.txtHorizontalResolution);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(225, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 157);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(27, 72);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Both Hemispheres";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(27, 118);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(141, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.Text = "Bottom Hemisphere Only";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(27, 95);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(127, 17);
            this.radioButton4.TabIndex = 9;
            this.radioButton4.Text = "Top Hemisphere Only";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // txtHorizontalResolution
            // 
            this.txtHorizontalResolution.Location = new System.Drawing.Point(27, 46);
            this.txtHorizontalResolution.Name = "txtHorizontalResolution";
            this.txtHorizontalResolution.Size = new System.Drawing.Size(141, 20);
            this.txtHorizontalResolution.TabIndex = 0;
            this.txtHorizontalResolution.TextChanged += new System.EventHandler(this.txtHorizontalResolution_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Horizontal Resolution (degrees)";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(385, 416);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 13);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "00:00";
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
            // txtTestNumber
            // 
            this.txtTestNumber.Location = new System.Drawing.Point(91, 19);
            this.txtTestNumber.Name = "txtTestNumber";
            this.txtTestNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTestNumber.TabIndex = 15;
            // 
            // grpLamp
            // 
            this.grpLamp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLamp.Controls.Add(this.txtOffset);
            this.grpLamp.Controls.Add(this.label7);
            this.grpLamp.Controls.Add(this.textBox1);
            this.grpLamp.Controls.Add(this.label6);
            this.grpLamp.Controls.Add(this.txtManufacturer);
            this.grpLamp.Controls.Add(this.label5);
            this.grpLamp.Controls.Add(this.txtTestNumber);
            this.grpLamp.Controls.Add(this.label2);
            this.grpLamp.Location = new System.Drawing.Point(15, 12);
            this.grpLamp.Name = "grpLamp";
            this.grpLamp.Size = new System.Drawing.Size(404, 108);
            this.grpLamp.TabIndex = 16;
            this.grpLamp.TabStop = false;
            this.grpLamp.Text = "Lamp Information";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
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
            this.txtManufacturer.TabIndex = 17;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Offset (k)";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(278, 22);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(100, 20);
            this.txtOffset.TabIndex = 21;
            // 
            // txtStrayVerticalResolution
            // 
            this.txtStrayVerticalResolution.Location = new System.Drawing.Point(6, 75);
            this.txtStrayVerticalResolution.Name = "txtStrayVerticalResolution";
            this.txtStrayVerticalResolution.Size = new System.Drawing.Size(141, 20);
            this.txtStrayVerticalResolution.TabIndex = 11;
            this.txtStrayVerticalResolution.TextChanged += new System.EventHandler(this.txtStrayVerticalResolution_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Stray Vertical Resolution (degrees)";
            // 
            // LumenTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 443);
            this.Controls.Add(this.grpLamp);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.chkEmail);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Name = "LumenTest";
            this.Text = "Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpLamp.ResumeLayout(false);
            this.grpLamp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVerticalResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.RadioButton radVerticalFull;
        private System.Windows.Forms.RadioButton radVerticalTop;
        private System.Windows.Forms.RadioButton radVerticalBottom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox txtHorizontalResolution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestNumber;
        private System.Windows.Forms.GroupBox grpLamp;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStrayVerticalResolution;
        private System.Windows.Forms.Label label8;
    }
}