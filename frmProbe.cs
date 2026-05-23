using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    public partial class frmProbe : Form
    {
        public frmProbe()
        {
            InitializeComponent();
        }

        #region Listbox DragDrop

        private async void dg_DragDrop(object sender, DragEventArgs e)
        {
            string[] filelist = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Array.Sort(filelist);

            string template = "-v error -select_streams v:0 -show_entries stream=bit_rate -of default=noprint_wrappers=1:nokey=1 \"{0}\"";
            foreach (string file in filelist)
            {
                if (file.ToLower().EndsWith(".mp4") || file.ToLower().EndsWith(".mkv"))
                {
                    string res=string.Empty ;

                    var result = await General.ExecuteAndCaptureOutputAsync(General.ffprobe, string.Format(template,file));

                    if (result.ExitCode == 0) // Success
                        res = result.StandardOutput;
                    else
                    {
                        res = result.StandardError;
                        dg.Rows[dg.Rows.Count - 1].DefaultCellStyle.BackColor = Color.OrangeRed;
                    }

                    dg.Rows.Add(new string[] {Path.GetFileName(file),res });
                }
            }

            this.Text = "Videos processed " + dg.RowCount.ToString();
        }

        private void dg_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        #endregion
    }
}
