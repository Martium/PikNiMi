using System;
using System.Threading;
using System.Windows.Forms;
using PikNiMi.Forms;
using PikNiMi.Repository.DependencyInjectionRepositoryClass;
using PikNiMi.Repository.SqlLite;

namespace PikNiMi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private const string AppUuid = "9c973b26-7a07-11ec-90d6-0242ac120003";

        private static RepositoryCreate _repositoryCreate;

        [STAThread]
        static void Main()
        {
            _repositoryCreate = new RepositoryCreate(new SqlLiteInitializeRepository());

            using (Mutex mutex = new Mutex(false, "Global\\" + AppUuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    // message cant open more than one application
                }

                bool isDatabaseIsInitialize = CreateDataBase();

                if (isDatabaseIsInitialize)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }

            }
        }

        private static bool CreateDataBase()
        {
            bool isDatabaseInitialize;

            try
            {
                _repositoryCreate.CreateRepositoryFile();
                _repositoryCreate.CreateRepositoryTable();

                isDatabaseInitialize = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                isDatabaseInitialize = false;
            }

            return isDatabaseInitialize;
        }
    }
}
