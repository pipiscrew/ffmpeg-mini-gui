namespace ffmpeg_mini_gui
{
    partial class frmDLP
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
            this.lst = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.chkVideo = new System.Windows.Forms.RadioButton();
            this.chkAudio = new System.Windows.Forms.RadioButton();
            this.grpVideo = new System.Windows.Forms.GroupBox();
            this.chkBestAudio = new System.Windows.Forms.CheckBox();
            this.chkDNSubs = new System.Windows.Forms.CheckBox();
            this.chk720 = new System.Windows.Forms.RadioButton();
            this.chk480 = new System.Windows.Forms.RadioButton();
            this.chkPassthrough = new System.Windows.Forms.RadioButton();
            this.chkList = new System.Windows.Forms.RadioButton();
            this.grpVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.AllowDrop = true;
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 15;
            this.lst.Location = new System.Drawing.Point(13, 43);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(425, 154);
            this.lst.TabIndex = 0;
            this.lst.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.lst.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(363, 365);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "execute";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(13, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Location = new System.Drawing.Point(363, 8);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(75, 29);
            this.btnPaste.TabIndex = 3;
            this.btnPaste.Text = "paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // chkVideo
            // 
            this.chkVideo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkVideo.AutoSize = true;
            this.chkVideo.Location = new System.Drawing.Point(148, 210);
            this.chkVideo.Name = "chkVideo";
            this.chkVideo.Size = new System.Drawing.Size(52, 25);
            this.chkVideo.TabIndex = 4;
            this.chkVideo.TabStop = true;
            this.chkVideo.Text = "video";
            this.chkVideo.UseVisualStyleBackColor = true;
            this.chkVideo.CheckedChanged += new System.EventHandler(this.chkVideo_CheckedChanged);
            // 
            // chkAudio
            // 
            this.chkAudio.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAudio.AutoSize = true;
            this.chkAudio.Location = new System.Drawing.Point(206, 210);
            this.chkAudio.Name = "chkAudio";
            this.chkAudio.Size = new System.Drawing.Size(52, 25);
            this.chkAudio.TabIndex = 5;
            this.chkAudio.TabStop = true;
            this.chkAudio.Text = "audio";
            this.chkAudio.UseVisualStyleBackColor = true;
            // 
            // grpVideo
            // 
            this.grpVideo.Controls.Add(this.chkBestAudio);
            this.grpVideo.Controls.Add(this.chkDNSubs);
            this.grpVideo.Controls.Add(this.chk720);
            this.grpVideo.Controls.Add(this.chk480);
            this.grpVideo.Controls.Add(this.chkPassthrough);
            this.grpVideo.Location = new System.Drawing.Point(13, 247);
            this.grpVideo.Name = "grpVideo";
            this.grpVideo.Size = new System.Drawing.Size(425, 99);
            this.grpVideo.TabIndex = 6;
            this.grpVideo.TabStop = false;
            this.grpVideo.Visible = false;
            // 
            // chkBestAudio
            // 
            this.chkBestAudio.AutoSize = true;
            this.chkBestAudio.Enabled = false;
            this.chkBestAudio.Location = new System.Drawing.Point(75, 62);
            this.chkBestAudio.Name = "chkBestAudio";
            this.chkBestAudio.Size = new System.Drawing.Size(131, 19);
            this.chkBestAudio.TabIndex = 4;
            this.chkBestAudio.Text = "with best audio";
            this.chkBestAudio.UseVisualStyleBackColor = true;
            // 
            // chkDNSubs
            // 
            this.chkDNSubs.AutoSize = true;
            this.chkDNSubs.Location = new System.Drawing.Point(272, 23);
            this.chkDNSubs.Name = "chkDNSubs";
            this.chkDNSubs.Size = new System.Drawing.Size(145, 19);
            this.chkDNSubs.TabIndex = 3;
            this.chkDNSubs.Text = "download subtitle";
            this.chkDNSubs.UseVisualStyleBackColor = true;
            // 
            // chk720
            // 
            this.chk720.AutoSize = true;
            this.chk720.Location = new System.Drawing.Point(16, 73);
            this.chk720.Name = "chk720";
            this.chk720.Size = new System.Drawing.Size(53, 19);
            this.chk720.TabIndex = 2;
            this.chk720.Text = "720p";
            this.chk720.UseVisualStyleBackColor = true;
            this.chk720.CheckedChanged += new System.EventHandler(this.chk480720_CheckedChanged);
            // 
            // chk480
            // 
            this.chk480.AutoSize = true;
            this.chk480.Location = new System.Drawing.Point(16, 48);
            this.chk480.Name = "chk480";
            this.chk480.Size = new System.Drawing.Size(53, 19);
            this.chk480.TabIndex = 1;
            this.chk480.Text = "480p";
            this.chk480.UseVisualStyleBackColor = true;
            this.chk480.CheckedChanged += new System.EventHandler(this.chk480720_CheckedChanged);
            // 
            // chkPassthrough
            // 
            this.chkPassthrough.AutoSize = true;
            this.chkPassthrough.Checked = true;
            this.chkPassthrough.Location = new System.Drawing.Point(16, 23);
            this.chkPassthrough.Name = "chkPassthrough";
            this.chkPassthrough.Size = new System.Drawing.Size(102, 19);
            this.chkPassthrough.TabIndex = 0;
            this.chkPassthrough.TabStop = true;
            this.chkPassthrough.Text = "passthrough";
            this.chkPassthrough.UseVisualStyleBackColor = true;
            this.chkPassthrough.CheckedChanged += new System.EventHandler(this.chkPassthrough_CheckedChanged);
            // 
            // chkList
            // 
            this.chkList.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkList.AutoSize = true;
            this.chkList.Location = new System.Drawing.Point(264, 210);
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(171, 25);
            this.chkList.TabIndex = 8;
            this.chkList.TabStop = true;
            this.chkList.Text = "list available formats";
            this.chkList.UseVisualStyleBackColor = true;
            // 
            // frmDLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 409);
            this.Controls.Add(this.chkList);
            this.Controls.Add(this.grpVideo);
            this.Controls.Add(this.chkAudio);
            this.Controls.Add(this.chkVideo);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lst);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(466, 444);
            this.Name = "frmDLP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download media with yt-dlp";
            this.grpVideo.ResumeLayout(false);
            this.grpVideo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.RadioButton chkVideo;
        private System.Windows.Forms.RadioButton chkAudio;
        private System.Windows.Forms.GroupBox grpVideo;
        private System.Windows.Forms.CheckBox chkDNSubs;
        private System.Windows.Forms.RadioButton chk720;
        private System.Windows.Forms.RadioButton chk480;
        private System.Windows.Forms.RadioButton chkPassthrough;
        private System.Windows.Forms.CheckBox chkBestAudio;
        private System.Windows.Forms.RadioButton chkList;
    }
}