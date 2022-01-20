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
            var allTableCommands = SqlLiteCreateTableCommands.GetTablesCommand();

            foreach (var tableCommand in allTableCommands)
            {
                DropTable(tableCommand.Key);
            }
        }

        public void CreateAllTablesCommand()
        {
            var allTableCommands = SqlLiteCreateTableCommands.GetTablesCommand();

            foreach (var tableCommand in allTableCommands)
            {
                CreateTable(tableCommand.Value);
            }
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

        private void DropTable(string tableName)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();
                string dropTableQuery = $"DROP TABLE IF EXISTS [{tableName}]";
                SQLiteCommand tableCommand = new SQLiteCommand(dropTableQuery, dbConnection);
                tableCommand.ExecuteNonQuery();
            }
        }

        private void CreateTable(string tableCommand)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();
                SQLiteCommand sqLiteCommand = new SQLiteCommand(tableCommand, dbConnection);
                sqLiteCommand.ExecuteNonQuery();
            }
        }


        #endregion


    }
}
