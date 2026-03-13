using System;
using System.Linq;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    public partial class frmMultiHardSub : Form
    {
        public frmMultiHardSub()
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
                if (file.ToLower().EndsWith(".mp4"))
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

        public DialogResult ShowDialog(out string result)
        {
            DialogResult dialogResult = base.ShowDialog();

            result = string.Join("*", lst.Items.Cast<string>().Select(item => item.ToString()));
            return dialogResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lst.Items.Count > 1) 
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
