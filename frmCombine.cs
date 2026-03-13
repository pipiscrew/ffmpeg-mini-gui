using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    public partial class frmCombine : Form
    {
        public frmCombine()
        {
            InitializeComponent();
        }

        #region Listbox DragDrop

        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            string[] filelist = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Array.Sort(filelist);

            foreach (string file in filelist)
            {
                if (!Path.GetFileName(file).Contains(" ") && ( file.ToLower().EndsWith(".ts") || file.ToLower().EndsWith(".mp4") || file.ToLower().EndsWith(".mkv")))
                    lst.Items.Add(file);
            }

            this.Text = "Videos added " + lst.Items.Count.ToString();
        }

        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        #endregion


        public DialogResult ShowDialog(out string result, out string videosWorkingFolder)
        {
            DialogResult dialogResult = base.ShowDialog();

            result = string.Join("|", lst.Items.Cast<string>().Select(item => Path.GetFileName( item.ToString())));

            if (lst.Items.Count > 1)
                videosWorkingFolder = Path.GetDirectoryName(lst.Items[0].ToString());
            else
                videosWorkingFolder = string.Empty;

            return dialogResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lst.Items.Count > 1)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (this.lst.SelectedItem == null)
            {
                General.Mes("Please select an item!", MessageBoxIcon.Asterisk, MessageBoxButtons.OK);
                return;
            }
            if (this.lst.SelectedIndex == 0)
            {
                General.Mes("You cant move up the 1st item!", MessageBoxIcon.Asterisk, MessageBoxButtons.OK);
                return;
            }
            string item = this.lst.SelectedItem.ToString();
            int num = this.lst.SelectedIndex - 1;
            this.lst.Items.RemoveAt(this.lst.SelectedIndex);
            this.lst.Items.Insert(num, item);
            this.lst.SelectedIndex = num;
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (this.lst.SelectedItem == null)
            {
                General.Mes("Please select an item!", MessageBoxIcon.Asterisk, MessageBoxButtons.OK);
                return;
            }
            if (this.lst.SelectedIndex == this.lst.Items.Count - 1)
            {
                General.Mes("You cant move down the last item!", MessageBoxIcon.Asterisk, MessageBoxButtons.OK);
                return;
            }
            string item = this.lst.SelectedItem.ToString();
            int num = this.lst.SelectedIndex + 1;
            this.lst.Items.RemoveAt(this.lst.SelectedIndex);
            this.lst.Items.Insert(num, item);
            this.lst.SelectedIndex = num;
        }

    }
}
