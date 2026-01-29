namespace ffmpeg_mini_gui
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtVideo = new System.Windows.Forms.TextBox();
            this.txtSubtitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBitrate = new System.Windows.Forms.TextBox();
            this.chkTwoPass = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPreset = new System.Windows.Forms.ComboBox();
            this.btn = new System.Windows.Forms.Button();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFPS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "video file :";
            // 
            // txtVideo
            // 
            this.txtVideo.AllowDrop = true;
            this.txtVideo.Location = new System.Drawing.Point(16, 32);
            this.txtVideo.Name = "txtVideo";
            this.txtVideo.ReadOnly = true;
            this.txtVideo.Size = new System.Drawing.Size(476, 23);
            this.txtVideo.TabIndex = 1;
            this.txtVideo.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.txtVideo.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            this.txtVideo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxClear_MouseDoubleClick);
            // 
            // txtSubtitle
            // 
            this.txtSubtitle.AllowDrop = true;
            this.txtSubtitle.Location = new System.Drawing.Point(16, 92);
            this.txtSubtitle.Name = "txtSubtitle";
            this.txtSubtitle.ReadOnly = true;
            this.txtSubtitle.Size = new System.Drawing.Size(476, 23);
            this.txtSubtitle.TabIndex = 3;
            this.txtSubtitle.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox2_DragDrop);
            this.txtSubtitle.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            this.txtSubtitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxClear_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "srt file (not required) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "bitrate :";
            // 
            // txtBitrate
            // 
            this.txtBitrate.Location = new System.Drawing.Point(92, 130);
            this.txtBitrate.Name = "txtBitrate";
            this.txtBitrate.Size = new System.Drawing.Size(42, 23);
            this.txtBitrate.TabIndex = 5;
            this.txtBitrate.Text = "600k";
            // 
            // chkTwoPass
            // 
            this.chkTwoPass.AutoSize = true;
            this.chkTwoPass.Location = new System.Drawing.Point(19, 171);
            this.chkTwoPass.Name = "chkTwoPass";
            this.chkTwoPass.Size = new System.Drawing.Size(82, 19);
            this.chkTwoPass.TabIndex = 6;
            this.chkTwoPass.Text = "two pass";
            this.chkTwoPass.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "preset :";
            // 
            // cmbPreset
            // 
            this.cmbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreset.FormattingEnabled = true;
            this.cmbPreset.Items.AddRange(new object[] {
            "ultrafast",
            "superfast",
            "veryfast",
            "faster",
            "fast",
            "medium",
            "slow",
            "slower",
            "veryslow"});
            this.cmbPreset.Location = new System.Drawing.Point(212, 130);
            this.cmbPreset.Name = "cmbPreset";
            this.cmbPreset.Size = new System.Drawing.Size(88, 23);
            this.cmbPreset.TabIndex = 8;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(19, 210);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(473, 35);
            this.btn.TabIndex = 9;
            this.btn.Text = "proceed";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(371, 130);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(36, 23);
            this.txtScale.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "scale :";
            // 
            // txtFPS
            // 
            this.txtFPS.Location = new System.Drawing.Point(371, 169);
            this.txtFPS.Name = "txtFPS";
            this.txtFPS.Size = new System.Drawing.Size(36, 23);
            this.txtFPS.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "fps :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 257);
            this.Controls.Add(this.txtFPS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.cmbPreset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkTwoPass);
            this.Controls.Add(this.txtBitrate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubtitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVideo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVideo;
        private System.Windows.Forms.TextBox txtSubtitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBitrate;
        private System.Windows.Forms.CheckBox chkTwoPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPreset;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFPS;
        private System.Windows.Forms.Label label6;
    }
}

