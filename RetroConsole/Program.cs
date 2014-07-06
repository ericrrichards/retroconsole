using System;
using System.Threading;
using System.Windows.Forms;

namespace RetroConsole {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.ThreadException+=ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException+= CurrentDomainOnUnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            var ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e) {
            MessageBox.Show(e.Exception.Message + "\n" + e.Exception.StackTrace);
        }
    }
}
