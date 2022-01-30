namespace PikNiMi.Repository.SqlLite
{
    public static class SqlLiteQueryToDataBaseCommands
    {
        private const string FullProductInfoTable = "FullProductInfoTable FPIT";

        private const string ProductId = "FPIT.ProductId";
        private const string ProductType = "FPIT.ProductType";
        private const string Search = "FPIT.Search";

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
                        WHERE {ProductType} = '{productType}'
                        ORDER BY {ProductId} DESC;
                ";

            return searchQuery;
        }

        public static string SearchBySearchPhraseAllInfo(string searchPhrase)
        {
            string searchQuery = 
                $@"
                     SELECT * FROM {FullProductInfoTable}
                     WHERE {Search} LIKE '%{searchPhrase}%'
                     ORDER BY {ProductId} DESC;
                ";

            return searchQuery;
        }

        public static string SearchInfoByProductTypeAndSearchPhrase(string productType, string searchPhrase)
        {
            string searchQuery =
                $@"
                     SELECT * FROM {FullProductInfoTable}
                     WHERE {Search} LIKE '%{searchPhrase}%' AND {ProductType} = '{productType}'
                     ORDER BY {ProductId} DESC;
                ";

            return searchQuery;
        }
    }
}
