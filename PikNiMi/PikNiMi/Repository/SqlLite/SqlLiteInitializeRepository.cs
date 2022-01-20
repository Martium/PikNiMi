using System.Data.SQLite;
using System.IO;
using PikNiMi.Interface.RepositoryInterface;

namespace PikNiMi.Repository.SqlLite
{
    public class SqlLiteInitializeRepository : IRepositoryCreate
    {
        public void InitializeDatabaseIfNotExists()
        {
            if (File.Exists(SqlLiteDataBaseConfiguration.DatabaseFile))
            {
#if DEBUG

#else
                return;
#endif
            }

            if (!Directory.Exists(SqlLiteDataBaseConfiguration.DatabaseFolder))
            {
                Directory.CreateDirectory(SqlLiteDataBaseConfiguration.DatabaseFolder);
            }
            else
            {
                DeleteLeftoverFilesAndFolders();
            }

            SQLiteConnection.CreateFile(SqlLiteDataBaseConfiguration.DatabaseFile);
        }

        public void DropAllTablesCommand()
        {
            throw new System.NotImplementedException();
        }

        public void CreateAllTablesCommand()
        {
            throw new System.NotImplementedException();
        }

        #region PrivateCustomMethods

        private void DeleteLeftoverFilesAndFolders()
        {
            var directory = new DirectoryInfo(SqlLiteDataBaseConfiguration.DatabaseFolder);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subdirectories in directory.GetDirectories())
            {
                subdirectories.Delete(true);
            }
        }


        #endregion

       
    }
}
