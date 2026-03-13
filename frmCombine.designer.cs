namespace ffmpeg_mini_gui
{
    partial class frmCombine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCombine));
            this.lst = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUP = new System.Windows.Forms.PictureBox();
            this.btnDN = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDN)).BeginInit();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.AllowDrop = true;
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 15;
            this.lst.Location = new System.Drawing.Point(13, 88);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(425, 274);
            this.lst.TabIndex = 0;
            this.lst.DragDrop += new System.Windows.Forms.DragEventHandler(this.lst_DragDrop);
            this.lst.DragEnter += new System.Windows.Forms.DragEventHandler(this.lst_DragEnter);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(363, 370);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(13, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 76);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnUP
            // 
            this.btnUP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUP.Image = global::ffmpeg_mini_gui.Properties.Resources.up32;
            this.btnUP.Location = new System.Drawing.Point(176, 367);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(37, 37);
            this.btnUP.TabIndex = 4;
            this.btnUP.TabStop = false;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDN
            // 
            this.btnDN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDN.Image = global::ffmpeg_mini_gui.Properties.Resources.down32;
            this.btnDN.Location = new System.Drawing.Point(225, 367);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(37, 37);
            this.btnDN.TabIndex = 5;
            this.btnDN.TabStop = false;
            this.btnDN.Click += new System.EventHandler(this.btnDN_Click);
            // 
            // frmCombine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 405);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.btnUP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(466, 444);
            this.Name = "frmCombine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Combine multiple videos to one file";
            ((System.ComponentModel.ISupportInitialize)(this.btnUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnUP;
        private System.Windows.Forms.PictureBox btnDN;
    }
}