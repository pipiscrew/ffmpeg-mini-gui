using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace ffmpeg_mini_gui
{
    public partial class frmMultiSubVTT : Form
    {
        public frmMultiSubVTT()
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
                if (file.ToLower().EndsWith(".vtt"))
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
                IEnumerable<SubtitleItem> items;
                string log = string.Empty;
                int processed = 0;
                foreach (string f in lst.Items)
                {
                    FileInfo source = new FileInfo(f);

                    if (General.IsFileUtf8(f))
                    {
                        items = new VttParser().ParseStream(source.OpenRead(), Encoding.UTF8);
                    }
                    else //Read as ANSI
                        items = new VttParser().ParseStream(source.OpenRead(), Encoding.Default);

                    if (items == null || items.Count() < 1)
                    {
                        log += Path.GetFileName(f) + "\n";
                        continue;
                    }

                    // srt filepath
                    string destinationFilepath = Path.Combine(Path.GetDirectoryName(f), Path.GetFileNameWithoutExtension(f) + ".srt");

                    if (File.Exists(destinationFilepath))
                        destinationFilepath = Path.Combine(Path.GetDirectoryName(f), Path.GetFileNameWithoutExtension(f) + DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".srt");

                    FileInfo destination = new FileInfo(destinationFilepath);

                    try
                    {
                        new SrtWriter().WriteStream(destination.OpenWrite(), items, true);
                    }
                    catch
                    {
                        log += Path.GetFileName(f) + "\n";
                        continue;
                    }

                    processed++;
                }

                label1.ForeColor = Color.Green;
                label1.Text = processed + " converted!";

                string noConvertsionMade = string.Empty;
                if (log != string.Empty)
                    noConvertsionMade = "\r\n\r\nthe following found as not valid subtitles :\n\n" + log;

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
