namespace PikNiMi.Repository.SqlLite
{
    public static class SqlLiteQueryToDataBaseCommands
    {
        private const string FullProductInfoTable = "FullProductInfoTable FPIT";
        private const string FullProductInfoTableShort = "FPIT";
       // private static readonly string ProductTypeNone = "Pasirinkti tipą...";

        public static string GetAllOfFullProductInfoCommand()
        {
            string getExistingServiceQuery =
                $@"
                    SELECT * FROM {FullProductInfoTable}
                ";

            return getExistingServiceQuery;
        }

        public static string SearchByFullProductInfo(string productType)
        {
            string searchQuery =
                $@"
                         SELECT * FROM {FullProductInfoTable}
                        WHERE {FullProductInfoTableShort}.ProductType = '{productType}'
                        ORDER BY {FullProductInfoTableShort}.ProductId DESC;
                ";

            return searchQuery;
        }
    }
}
