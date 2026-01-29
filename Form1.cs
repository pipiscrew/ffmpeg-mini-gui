using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
            TextBoxWatermarkExtensionMethod.SetWatermark(txtScale, "854");
            TextBoxWatermarkExtensionMethod.SetWatermark(txtFPS, "4");
        }

        #region TextBox DragDrop
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (FileList[0].ToLower().EndsWith(".mp4") || FileList[0].ToLower().EndsWith(".mkv"))
            {
                txtVideo.Text = FileList[0];
                Scroll2END(txtVideo);
            }
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (FileList[0].ToLower().EndsWith(".srt"))
            {
                txtSubtitle.Text = FileList[0];
                Scroll2END(txtSubtitle);
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

        private void btn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\ffmpeg.exe"))
            {
                Mes("ffmpeg.exe must be near this application. download at :\r\n\r\nhttps://www.ffmpeg.org/download.html");
                return;
            }

            if (!File.Exists(txtVideo.Text))
            {
                Mes("Video file doesnt exist");
                return;
            }

            txtBitrate.Text = txtBitrate.Text.Trim();
            if (txtBitrate.Text.Length == 0)
            {
                Mes("bitrate required!");
                return;
            }
            
            //if (!File.Exists(txtSubtitle.Text))
            //{
            //    Mes("Subtitle file doesnt exist");
            //    return;
            //}

            string subtitleFix = GetSubtitlePath(txtSubtitle.Text);
            string scaleFix = GetScaledBounds(txtScale.Text);
            string fpsFix = GetFPSfix(txtFPS.Text);

            string filters = ConstructFinalFilters(subtitleFix, scaleFix, fpsFix);

            string template = string.Empty;

            if (chkTwoPass.Checked)
                template = ffmpeg_mini_gui.Properties.Resources.twopassCMD;
            else
                template = ffmpeg_mini_gui.Properties.Resources.onepassCMD;

            template = template.Replace("*video*", txtVideo.Text).Replace("*sub*", subtitleFix).Replace("*bitrate*", txtBitrate.Text).Replace("*preset*", cmbPreset.Text).Replace("*output*", txtVideo.Text + "-output.mp4").Replace("*curr*", Application.StartupPath).Replace("*filters*", filters);

            string tmp = Path.GetTempFileName() + ".bat";

            File.WriteAllText(tmp, template);

            ExecuteBatchFile(tmp);
        }

 

        private static string ConstructFinalFilters(string subs, string scale, string fps)
        {
            string final = string.Empty;

            if (subs != null)
                final = subs;

            if (scale != null)
            {
                if (final.Length > 0)
                    final += ",";

                final += scale;
            }

            if (fps != null)
            {
                if (final.Length > 0)
                    final += ",";

                final += fps;
            }

            if (final == string.Empty)
                return " ";
            else 
                return string.Format(" -vf \"{0}\" ", final);
        }

        private string GetFPSfix(string p)
        {
            if (p.Length == 0)
                return null;

            return string.Format("fps={0}", p);
        }

        private string GetScaledBounds(string p)
        {
            if (p.Length == 0)
                return null;

            return string.Format("scale={0}:-1", p);
        }

        private static string GetSubtitlePath(string p)
        {
            if (string.IsNullOrEmpty(p))
                return null;

            string formattedPath = p.Replace("\\", "\\\\");

            if (formattedPath.Length > 1 && formattedPath[1] == ':')
            {
                formattedPath = formattedPath[0] + "\\:" + formattedPath.Substring(2);
            }

            return string.Format("subtitles='{0}':force_style='FontName=Arial,FontSize=24'", formattedPath);
        }


        private static void ExecuteBatchFile(string batchFilePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c start \"\" \"" + batchFilePath + "\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false
            };

            Process process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();
        }


        public static DialogResult Mes(string descr, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons butt = MessageBoxButtons.OK)
        {
            if (descr.Length > 0)
                return MessageBox.Show(descr, Application.ProductName, butt, icon);
            else
                return DialogResult.OK;

        }

        private void Scroll2END(TextBox txtSQL)
        {
            txtSQL.SelectionStart = txtSQL.Text.Length;
            txtSQL.ScrollToCaret();
            txtSQL.Refresh();
        }




    }


    public static class TextBoxWatermarkExtensionMethod
    {
        // Fields
        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = 0x1501;

        // Methods
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public static void SetWatermark(this TextBox textBox, string watermarkText)
        {
            SendMessage(textBox.Handle, 0x1501, 0, watermarkText);
        }
    }
}
