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
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // DIRECT EXECUTION OF ffmpeg.exe AND GRAB THE OUTPUT [working but abandoned due difficult usability by end user]
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //internal static Process process;

        //public static Task ExecuteTestExecutable(string args)
        //{
        //    return Task.Run(() =>
        //      {
        //          process = new Process
        //          {
        //              StartInfo =
        //              {
        //                  FileName = "ffmpeg.exe",
        //                  Arguments = args,
        //                  RedirectStandardOutput = true,
        //                  RedirectStandardError = true,
        //                  UseShellExecute = false,
        //                  CreateNoWindow = true,  
        //              }
        //          };

        //          process.Exited += Process_Exited;
        //          process.OutputDataReceived += Process_OutputDataReceived;
        //          process.ErrorDataReceived += Process_OutputDataReceived; //ffmpeg outputs here

        //          process.Start();

        //          process.BeginOutputReadLine();
        //          process.BeginErrorReadLine();

        //          process.WaitForExit();

        //          return string.Empty;
        //      });
        //}

        //private static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        //{
        //    Console.WriteLine(e.Data);
        //}

        //private static void Process_Exited(object sender, EventArgs e)
        //{
        //    if (process != null && process.ExitCode == 2)
        //    {
        //        Console.WriteLine("Exit Code 2 Detected");
        //    }

        //    Console.WriteLine("process exited!");
        //}

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

        public static string GetOutputFilenameForCombine(string videoFolder, string sourceVideoFilePath)
        {
            sourceVideoFilePath = sourceVideoFilePath.Split(new char[] { '|' })[0].Replace("concat:", "");
            return string.Format("{0}{1}_{2}-output.mp4", videoFolder, Path.GetFileNameWithoutExtension(sourceVideoFilePath), General.GetNow());
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


        public static bool ValidateMultiFiles(string[] multiFiles)
        {
            string invalid = string.Empty;
            string invalidSubs = string.Empty;
            foreach (string file in multiFiles)
            {
                if (!File.Exists(file) || !File.Exists(GetSubtitleFilePathByVideo(file)))
                {
                    invalid += file + "\r\n";
                }
                else
                {
                    if (!IsFileUtf8(GetSubtitleFilePathByVideo(file)))
                    {
                        invalidSubs += file + "\r\n";
                    }
                }
            }

            if (invalidSubs != string.Empty)
            {
                Mes("Subtitle file is not UTF8 (required by ffmpeg) for the videos :\r\n\r\n" + invalidSubs, MessageBoxIcon.Error);
                return false;
            }
            else if (invalid != string.Empty)
            {
                Mes("Video file not found or video subtitle not found for the following :\r\n\r\n" + invalid, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
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

        internal static bool CheckFilesForCombine(string videoFolder, string videoFilenames)
        {
            string[] files = videoFilenames.Split(new char[] { '|' });

            foreach (string f in files)
            {
                if (!File.Exists(videoFolder + f))
                {
                    Mes("Video file doesnt exist :\r\n\r\n" + f);
                    return false;
                }
            }

            return true;
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
    }


    public static class TextBoxWatermarkExtensionMethod
    {
        public const uint ECM_FIRST = 0x1500;
        public const uint EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public static void SetWatermark(this TextBox textBox, string watermarkText)
        {
            SendMessage(textBox.Handle, 0x1501, 0, watermarkText);
        }
    }
}
