using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotifyCP
{
    static class Program
    {
        static Form1 f;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f = new Form1();
            t = new Thread(new ThreadStart(collectText));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            Application.Run(f);
           
        }

        static Thread t;
        static String currentClip = "";
        private static void collectText()
        {
            
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    String s = new StreamReader(WebRequest.Create("http://localhost/TextSharer/test.text?a=c").GetResponse().GetResponseStream()).ReadToEnd();
                    if (s != currentClip)
                    {
                        currentClip = s;
                        Clipboard.SetText(s);
                        f.notifyIcon1.ShowBalloonTip(0, "Content Copied", s, ToolTipIcon.None);
                    }
                } catch (Exception ex) {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
