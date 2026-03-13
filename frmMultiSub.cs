using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    public partial class frmMultiSub : Form
    {
        public frmMultiSub()
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
                if (file.ToLower().EndsWith(".srt"))
                    lst.Items.Add(file);
            }

            this.Text = "Subtitles added " + lst.Items.Count.ToString();
        }

        private void lst_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lst.Items.Count > 0)
                doConversion();
            else
                this.Close();
        }

        private void doConversion()
        {
            try
            {
                string log = string.Empty;
                int processed = 0;
                foreach (string f in lst.Items)
                {
                    if (General.IsFileUtf8(f))
                    {
                        log += Path.GetFileName(f) + "\n";
                        continue;
                    }

                    //Read as ANSI
                    String subTXT = File.ReadAllText(f, Encoding.Default);

                    //backup
                    if (File.Exists(this.Text + ".bak"))
                        System.IO.File.Move(f, f + DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".bak");
                    else
                        System.IO.File.Move(f, f + ".bak");

                    //Write as UTF8
                    File.WriteAllText(Path.GetDirectoryName(f) + "\\" + Path.GetFileNameWithoutExtension(f) + ".srt", subTXT, Encoding.UTF8);

                    processed++;
                }

                label1.ForeColor = Color.Green;
                label1.Text = processed + " converted!";

                string noConvertsionMade = string.Empty;
                if (log != string.Empty)
                    noConvertsionMade = "\r\n\r\nthe following found as UTF8, no reencoding made :\n\n" + log;

                General.Mes(processed + " converted!" + noConvertsionMade);

                this.Close();
            }
            catch (Exception ex)
            {
                General.Mes(ex.Message, MessageBoxIcon.Error);
            }

        }

    }
}
