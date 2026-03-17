using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ffmpeg_mini_gui
{
    public partial class frmConvertAudio : Form
    {
        /*
         * https://ffmpeg.org/ffmpeg-formats.html#Format-Options
         * https://stackoverflow.com/a/20587693
         * https://www.ffmpeg.org/general.html#Video-Codecs
         * https://www.ffmpeg.org/general.html#Audio-Codecs
         */

        List<string> validExtensions = new List<string>
        {
            ".mp3",".wav",".aac",".flac",".ogg",".wma",".m4a",".aiff",".aif",".ac3",".opus"
        };

        public frmConvertAudio()
        {
            InitializeComponent();
            cmbOutputFormat.SelectedIndex = 0;
        }

        #region Listbox DragDrop

        private void lst_DragDrop(object sender, DragEventArgs e)
        {
            string[] filelist = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Array.Sort(filelist);

            foreach (string file in filelist)
            {
                if (validExtensions.Any(ext => ext.Equals(Path.GetExtension(file).ToLower())))
                    lst.Items.Add(file);
            }

            this.Text = "File(s) added " + lst.Items.Count.ToString();
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
            if (lst.Items.Count > 0)
            {
                label2.Visible = false;
                progressBar.Visible = true;
                progressBar.Maximum = lst.Items.Count;
                progressBar.Value = 0;
                if (await DoConversion(lst.Items.Cast<string>().ToArray(), cmbOutputFormat.Text))
                    this.DialogResult = DialogResult.OK;
            }
            else
                this.Close();
        }

        internal async Task<bool> DoConversion(string[] files, string cmbOutputFormat)
        {
            return await Task.Run(() =>
            {
                string outputDirectory = General.appStartPath + "\\output" + General.GetNow() + "\\";
                string[] sourceItems = files;

                //create #destination# (output) folder
                Directory.CreateDirectory(outputDirectory);

                string pointFirstSuccess = outputDirectory;
                string errorTXT = string.Empty;
                int processed = 0;

                this.BeginInvoke(new Action(() => General.EnableControls(this.Controls, false)));
                foreach (string file in sourceItems)
                {
                    string outputFileName = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + cmbOutputFormat);

                    if (File.Exists(outputFileName))
                        outputFileName = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + General.GetNow() + cmbOutputFormat);

                    ProcessStartInfo processStartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = "-y -i \"" + file + "\" \"" + outputFileName + "\"",  // -y overwrite || -b:a 192k 
                        RedirectStandardOutput = false,
                        RedirectStandardError = false,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    try
                    {
                        using (Process process = Process.Start(processStartInfo))
                        {
                            Console.WriteLine(processStartInfo.Arguments);
                            process.WaitForExit();

                            if (process.ExitCode != 0)
                            {
                                errorTXT += file + "\r\n";
                            }
                            else
                            {
                                processed++;

                                if (pointFirstSuccess == outputDirectory)
                                    pointFirstSuccess = outputFileName;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        General.Mes(ex.Message, MessageBoxIcon.Error);
                        return false;
                    }

                    progressBar.BeginInvoke(new Action(() => progressBar.Value++));
                }

                this.BeginInvoke(new Action(() => General.EnableControls(this.Controls, true)));

                if (errorTXT.Length > 0)
                    General.Mes(string.Format("Success : {0} \r\n\r\nFailed :\r\n\r\n{1}", processed, errorTXT), MessageBoxIcon.Exclamation);

                General.PointFile(pointFirstSuccess);

                return true;
            });
        }
    }
}
