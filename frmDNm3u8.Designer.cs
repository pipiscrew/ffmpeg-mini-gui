namespace ffmpeg_mini_gui
{
    partial class frmDNm3u8
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
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnPasteURL = new System.Windows.Forms.Button();
            this.txtReferer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefererURL = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL : ";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(57, 13);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(465, 23);
            this.txtURL.TabIndex = 1;
            // 
            // btnPasteURL
            // 
            this.btnPasteURL.Location = new System.Drawing.Point(529, 13);
            this.btnPasteURL.Name = "btnPasteURL";
            this.btnPasteURL.Size = new System.Drawing.Size(55, 23);
            this.btnPasteURL.TabIndex = 2;
            this.btnPasteURL.Text = "paste";
            this.btnPasteURL.UseVisualStyleBackColor = true;
            this.btnPasteURL.Click += new System.EventHandler(this.btnPasteURL_Click);
            // 
            // txtReferer
            // 
            this.txtReferer.Location = new System.Drawing.Point(86, 52);
            this.txtReferer.Name = "txtReferer";
            this.txtReferer.ReadOnly = true;
            this.txtReferer.Size = new System.Drawing.Size(436, 23);
            this.txtReferer.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Referer : ";
            // 
            // btnRefererURL
            // 
            this.btnRefererURL.Location = new System.Drawing.Point(528, 52);
            this.btnRefererURL.Name = "btnRefererURL";
            this.btnRefererURL.Size = new System.Drawing.Size(55, 23);
            this.btnRefererURL.TabIndex = 5;
            this.btnRefererURL.Text = "paste";
            this.btnRefererURL.UseVisualStyleBackColor = true;
            this.btnRefererURL.Click += new System.EventHandler(this.btnRefererURL_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(426, 90);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(96, 25);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "^ not required";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(316, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmDNm3u8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(588, 127);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnRefererURL);
            this.Controls.Add(this.txtReferer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPasteURL);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmDNm3u8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download .m3u8 as video";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnPasteURL;
        private System.Windows.Forms.TextBox txtReferer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefererURL;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
    }
}