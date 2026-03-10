using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " v" + Application.ProductVersion;

            cmbPreset.SelectedIndex = 2;
            progressBar.Maximum = 0;
            TextBoxWatermarkExtensionMethod.SetWatermark(txtScale, "854");
            TextBoxWatermarkExtensionMethod.SetWatermark(txtFPS, "4");
        }

        #region " TextBox DragDrop "

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] filelist = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (filelist[0].ToLower().EndsWith(".mp4") || filelist[0].ToLower().EndsWith(".mkv"))
            {
                txtVideo.Text = filelist[0];
                General.Scroll2END(txtVideo);
            }
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (!txtVideo.Text.Contains("*"))
            {
                string[] filelist = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (filelist[0].ToLower().EndsWith(".srt"))
                {
                    txtSubtitle.Text = filelist[0];
                    General.Scroll2END(txtSubtitle);
                }
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void textBoxClear_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (sender as TextBox).Text = string.Empty;
        }

        #endregion

        private async void btn_Click(object sender, EventArgs e)
        {

            if (!File.Exists(Application.StartupPath + "\\ffmpeg.exe"))
            {
                General.Mes("ffmpeg.exe must be near this application. download at :\r\n\r\nhttps://www.ffmpeg.org/download.html");
                return;
            }

            // * = multi video harsub   | = combine videos
            string[] multiFiles = txtVideo.Text.Split(new char[] { '*' });

            string combineVideoFolder = string.Empty;

            //get what process type to follow
            General.ProcessType actionType = General.FindKindOfAction(txtVideo.Text);

            if (actionType == General.ProcessType.combine)
            {
                combineVideoFolder = btnCombine.Tag.ToString();

                if (!General.CheckFilesForCombine(combineVideoFolder, txtVideo.Text))
                    return;
                else
                    multiFiles[0] = "concat:" + multiFiles[0];
            }
            else
            {
                if (multiFiles.Count() == 1 && !File.Exists(txtVideo.Text))
                {
                    General.Mes("Video file doesnt exist.");
                    return;
                }
                else if (multiFiles.Count() == 1 && File.Exists(txtSubtitle.Text))
                {
                    if (!General.IsFileUtf8(General.GetSubtitleFilePathByVideo(txtSubtitle.Text)))
                    {
                        General.Mes("Subtitle file is not UTF8 (required by ffmpeg).", MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (multiFiles.Count() > 1 && actionType == General.ProcessType.multiHardSub && !General.ValidateMultiFiles(multiFiles))
                {
                    return;
                }
            }

            txtBitrate.Text = txtBitrate.Text.Trim();
            if (txtBitrate.Text.Length == 0)
            {
                General.Mes("bitrate required!");
                return;
            }

            //ffmpeg config
            string timeCut = General.TimeCutOutput(txtStartTime.MaskFull, txtEndTime.MaskFull, txtStartTime.Text, txtEndTime.Text);
            if (timeCut == null)
                return;
            //ffmpeg config 

            progressBar.Maximum = multiFiles.Count();
            progressBar.Value = 0;
            //progressBar.Text = "0 / " + multiFiles.Count();
            General.EnableControls(this.Controls, false);
            for (int i = 0; i < multiFiles.Count(); i++)
            {
                string subtitleFix = General.GetSubtitlePath(multiFiles.Count() == 1 ? txtSubtitle.Text : General.GetSubtitleFilePathByVideo(multiFiles[i]));
                string scaleFix = General.GetScaledBounds(txtScale.Text);
                string fpsFix = General.GetFPSfix(txtFPS.Text);
                string filters = General.ConstructFinalFilters(subtitleFix, scaleFix, fpsFix);

                string template = string.Empty;

                if (chkTwoPass.Checked)
                    template = ffmpeg_mini_gui.Properties.Resources.twopassCMD;
                else
                    template = ffmpeg_mini_gui.Properties.Resources.onepassCMD;

                //output filepath
                string outputFilename = string.Empty;
                if ((actionType != General.ProcessType.combine) && (multiFiles.Count() == 1 && File.Exists(txtSubtitle.Text)) || multiFiles.Count() > 1)
                    outputFilename = General.GetOutputFilenameForHardSubbed(multiFiles[i]);
                else if (actionType == General.ProcessType.combine)
                {
                    outputFilename = General.GetOutputFilenameForCombine(combineVideoFolder, multiFiles[i]);
                    multiFiles[i] =  multiFiles[i].Replace("\\","/");
                }
                else  // when is one VIDEO without subs
                    outputFilename = General.GetOutputFilename(multiFiles[i]);

                template = template.Replace("*video*", multiFiles[i]).Replace("*bitrate*", txtBitrate.Text).Replace("*preset*", cmbPreset.Text)
                            .Replace("*output*", outputFilename).Replace("*curr*", Application.StartupPath).Replace("*filters*", filters)
                            .Replace("%timecut%", timeCut);


                string tmp = Path.GetTempFileName() + ".bat";

                if (actionType == General.ProcessType.combine)
                    tmp = string.Format("{0}action{1}.bat", combineVideoFolder, General.GetNow());

                File.WriteAllText(tmp, template);

                await General.ExecuteBatchFile(tmp);

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // DIRECT EXECUTION OF ffmpeg.exe AND GRAB THE OUTPUT [working but abandoned due difficult usability by end user]
                //string args1 = string.Empty;
                //string args2 = string.Empty;

                //if (chkTwoPass.Checked)
                //{
                //    args1 = ffmpeg_mini_gui.Properties.Resources.directEXE_twopassARGSpass1;
                //    args2 = ffmpeg_mini_gui.Properties.Resources.directEXE_twopassARGSpass2;
                //}
                //else
                //    args1 = ffmpeg_mini_gui.Properties.Resources.directEXE_onepassARGS;

                //args1 = args1.Replace("%input%", multiFiles[i]).Replace("%bitrate%", txtBitrate.Text).Replace("%preset%", cmbPreset.Text).Replace("%output%", outputFilename).Replace("%curr%", Application.StartupPath).Replace("%filters%", filters);
                //args2 = args2.Replace("%input%", multiFiles[i]).Replace("%bitrate%", txtBitrate.Text).Replace("%preset%", cmbPreset.Text).Replace("%output%", outputFilename).Replace("%curr%", Application.StartupPath).Replace("%filters%", filters);

                //if (chkTwoPass.Checked)
                //{
                //    await General.ExecuteTestExecutable(args1);
                //    await General.ExecuteTestExecutable(args2);
                //}
                //else
                //    await General.ExecuteTestExecutable(args1);

                progressBar.Value++;
                // windows progressbar - progressBar.Value = ((i + 1) * 100) / multiFiles.Count();
                // TextProgressBar (versus  .Value above) - progressBar.Text = (i + 1).ToString() + " / " + multiFiles.Count().ToString();
            }
            General.EnableControls(this.Controls, true);
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            string val = null;

            frmMultiHardSub x = new frmMultiHardSub();
            if (x.ShowDialog(out val) == System.Windows.Forms.DialogResult.OK)
            {
                txtVideo.Text = val;
                txtSubtitle.Text = string.Empty;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMultiSub x = new frmMultiSub();
            x.ShowDialog();
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            string val = null;
            string videosWorkingFolder = null;

            frmCombine x = new frmCombine();
            if (x.ShowDialog(out val, out videosWorkingFolder) == System.Windows.Forms.DialogResult.OK)
            {
                txtVideo.Text = val;
                txtSubtitle.Text = string.Empty;
                btnCombine.Tag = videosWorkingFolder + Path.DirectorySeparatorChar;
            }

        }

        private void lblStartTime_Click(object sender, EventArgs e)
        {
            txtStartTime.Text = "";
        }

        private void lblEndTime_Click(object sender, EventArgs e)
        {
            txtEndTime.Text = "";
        }
    }


}
