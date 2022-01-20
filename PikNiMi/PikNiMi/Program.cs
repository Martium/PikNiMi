using System;
using System.Threading;
using System.Windows.Forms;

namespace PikNiMi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private const string AppUuid = "9c973b26-7a07-11ec-90d6-0242ac120003";

        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + AppUuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    // message cant open more than one application
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

            }
        }
    }
}
