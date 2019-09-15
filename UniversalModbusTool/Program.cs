using System;
using System.Windows.Forms;
using UniversalModbusTool.Forms;

namespace UniversalModbusTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //try
            {
                Application.Run(new MainForm());
            }
            //catch (Exception ex)
            {
                //ExceptionHelper.ShowException(ex);
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //ExceptionHelper.ShowException();
        }
    }
}
