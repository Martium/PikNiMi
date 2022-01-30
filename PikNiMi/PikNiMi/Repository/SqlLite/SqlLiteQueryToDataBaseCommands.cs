namespace PikNiMi.Repository.SqlLite
{
    public static class SqlLiteQueryToDataBaseCommands
    {
        private const string FullProductInfoTable = "FullProductInfoTable FPIT";
        private const string FullProductInfoTableShort = "FPIT";

        private const string ProductId = "FPIT.ProductId";
       // private static readonly string ProductTypeNone = "Pasirinkti tipą...";

        public static string GetAllOfFullProductInfoCommand()
        {
            string getExistingServiceQuery =
                $@"
                    SELECT * FROM {FullProductInfoTable}
                    ORDER BY {ProductId} DESC;
                ";

            return getExistingServiceQuery;
        }

        public static string SearchBySpecificProductType(string productType)
        {
            string searchQuery =
                $@"
                         SELECT * FROM {FullProductInfoTable}
                        WHERE {FullProductInfoTableShort}.ProductType = '{productType}'
                        ORDER BY {ProductId} DESC;
                ";

            return searchQuery;
        }

        public static string SearchBySearchPhraseAllInfo(string searchPhrase)
        {
            string searchQuery = 
                $@"
                     SELECT * FROM {FullProductInfoTable}
                     WHERE {FullProductInfoTableShort}.Search LIKE '%{searchPhrase}%'
                     ORDER BY {ProductId} DESC;
                ";

            return searchQuery;
        }
    }
}
