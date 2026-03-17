using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    public class General
    {
        public enum ProcessType
        {
            singleFile,
            multiHardSub,
            combine
        }

        internal static string appStartPath;
        internal static bool showYToptions;
        internal static  string ytdlp_x86;
        internal static  string ytdlp;

        public static Task ExecuteBatchFile(string batchFilePath)
        {
            return Task.Run(() =>
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    //Arguments = "/c start \"\" \"" + batchFilePath + "\"",
                    Arguments = "/c start /wait \"\" \"" + batchFilePath + "\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    WorkingDirectory = Path.GetDirectoryName(batchFilePath)
                };

                using (var process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();
                    process.WaitForExit();
                }
            });
        }

        public static void Scroll2END(TextBox txtSQL)
        {
            txtSQL.SelectionStart = txtSQL.Text.Length;
            txtSQL.ScrollToCaret();
            txtSQL.Refresh();
        }

        public static string GetSubtitleFilePathByVideo(string videoFilePath)
        {
            return string.Format("{0}\\{1}.srt", Path.GetDirectoryName(videoFilePath), Path.GetFileNameWithoutExtension(videoFilePath));
        }

        public static string GetOutputFilenameForHardSubbed(string sourceVideoFilePath)
        {
            return string.Format("{0}\\{1}.hardsubbed.mp4", Path.GetDirectoryName(sourceVideoFilePath), Path.GetFileNameWithoutExtension(sourceVideoFilePath));
        }

        public static string GetOutputFilename(string sourceVideoFilePath)
        {
            return string.Format("{0}\\{1}-output.mp4", Path.GetDirectoryName(sourceVideoFilePath), Path.GetFileNameWithoutExtension(sourceVideoFilePath));
        }

        public static string ConstructFinalFilters(string subs, string scale, string fps)
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

        public static string GetFPSfix(string p)
        {
            if (p.Length == 0)
                return null;

            return string.Format("fps={0}", p);
        }

        public static string GetScaledBounds(string p)
        {
            if (p.Length == 0)
                return null;

            return string.Format("scale={0}:-1", p);
        }

        public static string GetSubtitlePath(string p)
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

        public static void EnableControls(System.Windows.Forms.Control.ControlCollection ctls, bool e)
        {
            foreach (Control control in ctls.OfType<Control>().Where(c => !c.Name.Equals("progressBar")))
            {
                control.Enabled = e;
            }
        }

        public static bool IsFileUtf8(string filePath)
        {
            if (TextEncodingDetect.IsUTF8withBom(filePath))
                return true;
            else if (TextEncodingDetect.IsUTF8(filePath))
                return true;
            else
                return false;
        }

        public static ProcessType FindKindOfAction(string str)
        {
            if (str.IndexOf("*") > -1)
                return General.ProcessType.multiHardSub;
            else if (str.IndexOf("|") > -1)
                return General.ProcessType.combine;
            else
                return General.ProcessType.singleFile;
        }

        public static DialogResult Mes(string descr, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons butt = MessageBoxButtons.OK)
        {
            if (descr.Length > 0)
                return MessageBox.Show(descr, Application.ProductName, butt, icon);
            else
                return DialogResult.OK;

        }

        internal static string TimeCutOutput(bool txtStart, bool txtEnd, string txtStartText, string txtEndText)
        {
            if (!txtStart && txtEnd)
            {
                Mes("You cant define only 'End time'.", MessageBoxIcon.Exclamation);
                return null;
            }

            string output = string.Empty;

            if (txtStart)
            {
                if (!IsValidTime(txtStartText))
                {
                    Mes("'Start time' is not in good shape.", MessageBoxIcon.Exclamation);
                    return null;
                }

                output = "-ss " + txtStartText;

                if (txtEnd)
                {
                    if (!IsValidTime(txtEndText) || !IsFirstTimeSmaller(txtStartText, txtEndText))
                    {
                        Mes("'End time' is not in good shape.", MessageBoxIcon.Exclamation);
                        return null;
                    }

                    output += " -to " + txtEndText;
                }
            }

            return output;
        }

        private static bool IsFirstTimeSmaller(string time1, string time2)
        {
            TimeSpan parsedTime1;
            TimeSpan parsedTime2;

            bool isTime1Valid = TimeSpan.TryParse(time1, out parsedTime1);
            bool isTime2Valid = TimeSpan.TryParse(time2, out parsedTime2);

            if (isTime1Valid && isTime2Valid)
            {
                return parsedTime1 < parsedTime2;
            }

            return false;
        }

        private static bool IsValidTime(string time)
        {
            TimeSpan parsedTime1;
            return TimeSpan.TryParse(time, out parsedTime1);
        }

        public static string GetNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
        }

        #region " CLIPBOARD OPERATIONS"

        public static void Copy2Clipboard(string val)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetDataObject(val, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName);
            }
        }

        public static string GetFromClipboard()
        {
            try
            {
                return Clipboard.GetText().Trim();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName);
                return "";
            }
        }

        #endregion

        public static void PointFile(string filePath)
        {
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
        }
    }


    public static class TextBoxWatermarkExtensionMethod
    {
        // Fields
        public const uint ECM_FIRST = 0x1500;
        public const uint EM_SETCUEBANNER = 0x1501;

        // Methods
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public static void SetWatermark(this TextBox textBox, string watermarkText)
        {
            SendMessage(textBox.Handle, 0x1501, 0, watermarkText);
        }
    }
}
