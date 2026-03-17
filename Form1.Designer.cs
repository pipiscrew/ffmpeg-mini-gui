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
            this.components = new System.ComponentModel.Container();
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
            this.btnMulti = new System.Windows.Forms.Button();
            this.ctxTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDNm3u8ByURL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSubToUTF8 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_dlp_DN_video = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_convert_img = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCombine = new System.Windows.Forms.Button();
            this.txtStartTime = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.MaskedTextBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.splitButton1 = new ffmpeg_mini_gui.SplitButton();
            this.progressBar = new ffmpeg_mini_gui.TextProgressBar();
            this.btn_convert_audio = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTools.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.txtVideo.MaxLength = 0;
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
            this.chkTwoPass.Checked = true;
            this.chkTwoPass.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.btn.Location = new System.Drawing.Point(19, 291);
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
            // btnMulti
            // 
            this.btnMulti.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnMulti.Location = new System.Drawing.Point(333, 11);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(160, 20);
            this.btnMulti.TabIndex = 14;
            this.btnMulti.Text = "multi subs hardcoding";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // ctxTools
            // 
            this.ctxTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDNm3u8ByURL,
            this.btnSubToUTF8,
            this.btn_dlp_DN_video,
            this.btn_convert_img,
            this.btn_convert_audio});
            this.ctxTools.Name = "contextMenuStrip1";
            this.ctxTools.Size = new System.Drawing.Size(244, 136);
            // 
            // btnDNm3u8ByURL
            // 
            this.btnDNm3u8ByURL.Name = "btnDNm3u8ByURL";
            this.btnDNm3u8ByURL.Size = new System.Drawing.Size(243, 22);
            this.btnDNm3u8ByURL.Text = "download .m3u8 playlist";
            this.btnDNm3u8ByURL.Click += new System.EventHandler(this.btnDNm3u8ByURL_Click);
            // 
            // btnSubToUTF8
            // 
            this.btnSubToUTF8.Name = "btnSubToUTF8";
            this.btnSubToUTF8.Size = new System.Drawing.Size(243, 22);
            this.btnSubToUTF8.Text = "subtitle to UTF8";
            this.btnSubToUTF8.Click += new System.EventHandler(this.btnSubToUTF8_Click);
            // 
            // btn_dlp_DN_video
            // 
            this.btn_dlp_DN_video.Image = global::ffmpeg_mini_gui.Properties.Resources.yt_dlp16;
            this.btn_dlp_DN_video.Name = "btn_dlp_DN_video";
            this.btn_dlp_DN_video.Size = new System.Drawing.Size(243, 22);
            this.btn_dlp_DN_video.Text = "download video && extract audio";
            this.btn_dlp_DN_video.Click += new System.EventHandler(this.btn_dlp_DN_video_Click);
            // 
            // btn_convert_img
            // 
            this.btn_convert_img.Name = "btn_convert_img";
            this.btn_convert_img.Size = new System.Drawing.Size(243, 22);
            this.btn_convert_img.Text = "convert image";
            this.btn_convert_img.Click += new System.EventHandler(this.btn_convert_img_Click);
            // 
            // btnCombine
            // 
            this.btnCombine.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnCombine.Location = new System.Drawing.Point(167, 11);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(160, 20);
            this.btnCombine.TabIndex = 23;
            this.btnCombine.Text = "combine videos";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(111, 20);
            this.txtStartTime.Mask = "00:00:00";
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(66, 23);
            this.txtStartTime.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtEndTime);
            this.groupBox1.Controls.Add(this.lblEndTime);
            this.groupBox1.Controls.Add(this.txtStartTime);
            this.groupBox1.Controls.Add(this.lblStartTime);
            this.groupBox1.Location = new System.Drawing.Point(19, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 72);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " cut (not required)  : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.Location = new System.Drawing.Point(60, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(367, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "if only \'start time\' defined  goes till the end of the video";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(322, 20);
            this.txtEndTime.Mask = "00:00:00";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(66, 23);
            this.txtEndTime.TabIndex = 26;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(237, 23);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(84, 15);
            this.lblEndTime.TabIndex = 25;
            this.lblEndTime.Text = "end time : ";
            this.lblEndTime.Click += new System.EventHandler(this.ClearCutMaskedBox_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(16, 23);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(98, 15);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "start time : ";
            this.lblStartTime.Click += new System.EventHandler(this.ClearCutMaskedBox_Click);
            // 
            // splitButton1
            // 
            this.splitButton1.Location = new System.Drawing.Point(425, 169);
            this.splitButton1.Menu = this.ctxTools;
            this.splitButton1.Name = "splitButton1";
            this.splitButton1.Size = new System.Drawing.Size(68, 25);
            this.splitButton1.TabIndex = 22;
            this.splitButton1.Text = "tools";
            this.splitButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.splitButton1.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.CustomText = "";
            this.progressBar.Location = new System.Drawing.Point(142, 171);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.LightGreen;
            this.progressBar.Size = new System.Drawing.Size(158, 23);
            this.progressBar.TabIndex = 17;
            this.progressBar.TextColor = System.Drawing.Color.Black;
            this.progressBar.TextFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.progressBar.VisualMode = ffmpeg_mini_gui.ProgressBarDisplayMode.CurrProgress;
            // 
            // btn_convert_audio
            // 
            this.btn_convert_audio.Name = "btn_convert_audio";
            this.btn_convert_audio.Size = new System.Drawing.Size(243, 22);
            this.btn_convert_audio.Text = "convert audio";
            this.btn_convert_audio.Click += new System.EventHandler(this.btn_convert_audio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 338);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCombine);
            this.Controls.Add(this.splitButton1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnMulti);
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
            this.ctxTools.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnMulti;
        private TextProgressBar progressBar;
        private System.Windows.Forms.ContextMenuStrip ctxTools;
        private System.Windows.Forms.ToolStripMenuItem btnDNm3u8ByURL;
        private SplitButton splitButton1;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.MaskedTextBox txtStartTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.ToolStripMenuItem btn_dlp_DN_video;
        private System.Windows.Forms.ToolStripMenuItem btnSubToUTF8;
        private System.Windows.Forms.ToolStripMenuItem btn_convert_img;
        private System.Windows.Forms.ToolStripMenuItem btn_convert_audio;
    }
}

