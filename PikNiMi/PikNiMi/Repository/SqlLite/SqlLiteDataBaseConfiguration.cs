using System.IO;
using System.Reflection;

namespace PikNiMi.Repository.SqlLite
{
    public static class SqlLiteDataBaseConfiguration
    {
        private static readonly string DatabaseName = "SellerStorage";
        public static string DatabaseFolder => $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Database";
        public static string DatabaseFile => $"{DatabaseFolder}\\{DatabaseName}.db";
        public static string ConnectionString => $"Data Source={DatabaseFile};Version=3;UseUTF16Encoding=True;";
    }
}
