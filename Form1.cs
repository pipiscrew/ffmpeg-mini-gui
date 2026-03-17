using ffmpeg_mini_gui.Repository;
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
            General.appStartPath = Application.StartupPath;
            General.ytdlp_x86 = General.appStartPath + "\\yt-dlp_x86.exe";
            General.ytdlp = General.appStartPath + "\\yt-dlp_x86.exe";

            //show hide yt-dlp options
            General.showYToptions = (File.Exists(General.ytdlp_x86) || File.Exists(General.ytdlp_x86));
            ctxTools.Items.OfType<ToolStripItem>().Where(c => c.Name.StartsWith("btn_dlp")).ToList().ForEach(c => c.Visible = General.showYToptions);
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

            ConversionProperties props = new ConversionProperties();

            //UI props
            props.bitrate = txtBitrate.Text.Trim();
            props.timeCut = General.TimeCutOutput(txtStartTime.MaskFull, txtEndTime.MaskFull, txtStartTime.Text, txtEndTime.Text);
            props.scaleFix = General.GetScaledBounds(txtScale.Text);
            props.fpsFix = General.GetFPSfix(txtFPS.Text);
            props.preset = cmbPreset.Text;
            props.twoPass = chkTwoPass.Checked;

            //UI source files
            props.videoTXT = txtVideo.Text;
            props.subTXT = txtSubtitle.Text;

            if (btnCombine.Tag!=null)
                props.videoFolder = btnCombine.Tag.ToString();

            //common validations
            if (props.bitrate.Length == 0)
            {
                General.Mes("bitrate required!");
                return;
            }

            if (props.timeCut == null)
                return;
            //common validations

            //get what process type to follow
            General.ProcessType actionType = General.FindKindOfAction(txtVideo.Text);

            IAction action;

            switch (actionType)
            {
                case General.ProcessType.combine:
                    action = new ActionCombine();
                    break;
                case General.ProcessType.multiHardSub:
                    action = new ActionMultiHardSub();
                    break;
                case General.ProcessType.singleFile:
                    action = new ActionSingle();
                    break;
                default:
                    throw new InvalidOperationException("Unknown action type");
            }

            //validate
            action.Validate(props);

            if (props.files.Count == 0)
                return;

            progressBar.Maximum = props.files.Count;
            progressBar.Value = 0;
            
            General.EnableControls(this.Controls, false);

            foreach (FileProperties f in props.files)
            {
                File.WriteAllText(f.batchFilepath, f.template);

                await General.ExecuteBatchFile(f.batchFilepath);

                progressBar.Value++;
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

        private void ClearCutMaskedBox_Click(object sender, EventArgs e)
        {
            txtStartTime.Text = txtEndTime.Text = "";
        }

   

# region Context Menu

        private void btnSubToUTF8_Click(object sender, EventArgs e)
        {
            frmMultiSub x = new frmMultiSub();
            x.ShowDialog();
        }

#endregion 

        private void btnDNm3u8ByURL_Click(object sender, EventArgs e)
        {
            frmDNm3u8 x = new frmDNm3u8();
            x.ShowDialog();
        }

        private void btn_dlp_DN_video_Click(object sender, EventArgs e)
        {
            frmDLP x = new frmDLP();
            x.ShowDialog();
        }

        private void btn_convert_img_Click(object sender, EventArgs e)
        {
            frmConvertImage x = new frmConvertImage();
            x.ShowDialog();
        }

        private void btn_convert_audio_Click(object sender, EventArgs e)
        {
            frmConvertAudio x = new frmConvertAudio();
            x.ShowDialog();
        }


    }


}
