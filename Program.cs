using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ffmpeg_mini_gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //FileInfo f = new FileInfo(@"C:\Users\Administrator\Downloads\Breaking\s04e15.vtt");
            //FileInfo fd = new FileInfo(@"C:\Users\Administrator\Downloads\Breaking\s04e152.srt");

            //var items = new VttParser().ParseStream(f.OpenRead(), Encoding.Default);

            //new SrtWriter().WriteStream(fd.OpenWrite(), items, true);


            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
