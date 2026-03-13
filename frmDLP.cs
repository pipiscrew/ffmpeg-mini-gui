using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    public partial class frmDLP : Form
    {
        public frmDLP()
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

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (lst.Items.Count == 0)
                return;

            if (!chkVideo.Checked && !chkAudio.Checked && !chkList.Checked)
            {
                General.Mes("Choose an operation");
                return;
            }

            string now = General.GetNow();

            //batch list filepath
            string listFilename = string.Format("!thelist{0}.txt",  now);
            string listFilepath = string.Format("{0}\\{1}", General.appStartPath, listFilename);
            //exe filepath
            string exe = Path.GetFileName(IdentifyYTdlp());
            string batchFilename = string.Format("!thelist{0}.bat",  now);
            string batchFilepath = string.Format("{0}\\{1}", General.appStartPath, batchFilename);

            //list of urls
            string[] items = lst.Items.Cast<string>().ToArray();
            File.WriteAllLines(listFilepath, items);

            //config
            string cmdArgs = string.Empty;

            if (chkVideo.Checked)
                cmdArgs = GetVideoConfig(listFilename);
            else if (chkAudio.Checked)
                cmdArgs = GetAudioConfig(listFilename);
            else if (chkList.Checked)
                cmdArgs = GetListConfig(listFilename);

            //write batch file
            string template = ffmpeg_mini_gui.Properties.Resources.cmd_universal;
            template = template.Replace("{command}", exe + cmdArgs);
            File.WriteAllText(batchFilepath, template);

            await General.ExecuteBatchFile(batchFilepath);
        }

        private string GetListConfig(string listFilename)
        {
            return string.Format(" --list-formats --batch-file {0}", listFilename);
        }

        private string GetAudioConfig(string listFilename)
        {	//https://github.com/yt-dlp/yt-dlp#post-processing-options
            return string.Format(" --batch-file {0} --extract-audio --audio-format mp3 --add-metadata --embed-thumbnail", listFilename);
        }

        private string GetVideoConfig(string listFilename)
        {
            string output = string.Empty;
            string audio = string.Empty;
            string subs = string.Empty;

            if (chkBestAudio.Checked)
                audio = "+bestaudio[ext=m4a]";
            if (chkDNSubs.Checked)
                subs = " --write-auto-sub ";

            //if (chkPassthrough.Checked)
            //    output = string.Format("--batch-file {0}", listFilename);
            if (chk480.Checked)
            {
                output = subs + " -f \"bestvideo[ext=mp4][height<720]" + audio + "\"";
            }
            else if (chk720.Checked)
            {
                output = subs + " -f \"bestvideo[ext=mp4][height<1080]" + audio + "\"";
            }

            output += string.Format(" --batch-file {0}", listFilename);

            return output;
        }

        private static string IdentifyYTdlp()
        {
            if (File.Exists(General.ytdlp_x86))
                return General.ytdlp_x86;
            else if (File.Exists(General.ytdlp))
                return General.ytdlp;
            else
                throw new Exception("Download yt-dlp!");

        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string links = General.GetFromClipboard();

            string[] lines = links.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            lst.Items.AddRange(lines);
        }

        private void chkVideo_CheckedChanged(object sender, EventArgs e)
        {
            grpVideo.Visible = chkVideo.Checked;
        }

        private void chk480720_CheckedChanged(object sender, EventArgs e)
        {
            chkBestAudio.Enabled = (sender as RadioButton).Checked;
        }

        private void chkPassthrough_CheckedChanged(object sender, EventArgs e)
        {
            chkBestAudio.Checked = false;
        }

       

    }
}
