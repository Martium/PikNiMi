using System;
using PikNiMi.Models;

namespace PikNiMi.Repository.SqlLite
{
    public static class SqlLiteQueryToDataBaseCommands
    {
        private const string FullProductInfoTable = "FullProductInfoTable";
        private const string FullProductInfoTableWithShortcut = "FullProductInfoTable FPIT";

        private const string ProductId = "FPIT.ProductId";
        private const string ProductType = "FPIT.ProductType";
        private const string Search = "FPIT.Search";

        private static string ImplementSearchData(string[] search)
        {
            string searchFormat = string.Empty;

            foreach (var info in search)
            {
                searchFormat += $"{info} + {Environment.NewLine} ";
            }

            return searchFormat;
        }

        public static string GetAllOfFullProductInfoCommand()
        {
            string getExistingServiceQuery =
                $@"
                    SELECT * FROM {FullProductInfoTableWithShortcut}
                    ORDER BY {ProductId} DESC;
                ";

            return getExistingServiceQuery;
        }

        public static string SearchBySpecificProductType(string productType)
        {
            string searchQuery =
                $@"
                         SELECT * FROM {FullProductInfoTableWithShortcut}
                        WHERE {ProductType} = '{productType}'
                        ORDER BY {ProductId} DESC;
                ";

            return searchQuery;
        }

        public static string SearchBySearchPhraseAllInfo(string searchPhrase)
        {
            string searchQuery = 
                $@"
                     SELECT * FROM {FullProductInfoTableWithShortcut}
                     WHERE {Search} LIKE '%{searchPhrase}%'
                     ORDER BY {ProductId} DESC;
                ";

            return searchQuery;
        }

        public static string SearchInfoByProductTypeAndSearchPhrase(string productType, string searchPhrase)
        {
            string searchQuery =
                $@"
                     SELECT * FROM {FullProductInfoTableWithShortcut}
                     WHERE {Search} LIKE '%{searchPhrase}%' AND {ProductType} = '{productType}'
                     ORDER BY {ProductId} DESC;
                ";

            return searchQuery;
        }

        public static string CreateNewFullProductInfo(FullProductInfoModel fullProductInfo, string[]search)
        {
            string searchFormat = ImplementSearchData(search);

            string newProductQuery = 
                $@"
                        INSERT INTO '{FullProductInfoTable}'
                        VALUES (NULL, '{fullProductInfo.ProductReceiptDate}', '{fullProductInfo.ProductType}', '{fullProductInfo.ProductDescription}',
                                '{fullProductInfo.ProductColor}', '{fullProductInfo.ProductSize}', '{fullProductInfo.ProductCare}',
                                '{fullProductInfo.ProductMadeStuff}', '{fullProductInfo.ProductMadeIn}', {fullProductInfo.ProductQuantity},
                                {fullProductInfo.ProductQuantityLeft}, {fullProductInfo.ProductOriginalUnitPriceAtOriginalCurrency},
                                {fullProductInfo.ProductQuantityPriceAtOriginalCurrency}, {fullProductInfo.ProductUnitPriceInEuro},
                                {fullProductInfo.ProductQuantityPriceInEuro}, {fullProductInfo.TripExpenses}, 
                                {fullProductInfo.ProductExpensesCostPrice}, {fullProductInfo.ProductSoldPrice}, {fullProductInfo.ProductPvm},
                                {fullProductInfo.ProductSoldPriceWithPvm}, {fullProductInfo.ProductSold}, {fullProductInfo.ProductProfit},
                                {fullProductInfo.Discount}, '{searchFormat}' )
                        
                ";

            return newProductQuery;
        }

        public static string UpdateExistingFullProductInfo(FullProductInfoModel fullProductInfo, string[] search)
        {
            string searchFormat = ImplementSearchData(search);

            string updateProductQuery = 
                $@"
                        UPDATE '{FullProductInfoTable}'
                        SET ProductReceiptDate = '{fullProductInfo.ProductReceiptDate}',
                            ProductType = '{fullProductInfo.ProductType}', ProductDescription = '{fullProductInfo.ProductDescription}',
                            ProductColor = '{fullProductInfo.ProductColor}', ProductSize = '{fullProductInfo.ProductSize}',
                            ProductCare = '{fullProductInfo.ProductCare}', ProductMadeStuff = '{fullProductInfo.ProductMadeStuff}',
                            ProductMadeIn = '{fullProductInfo.ProductMadeIn}', ProductQuantity = {fullProductInfo.ProductQuantity},
                            ProductQuantityLeft = {fullProductInfo.ProductQuantityLeft}, 
                            ProductOriginalUnitPriceAtOriginalCurrency = {fullProductInfo.ProductOriginalUnitPriceAtOriginalCurrency},
                            ProductQuantityPriceAtOriginalCurrency = {fullProductInfo.ProductQuantityPriceAtOriginalCurrency},
                            ProductUnitPriceInEuro = {fullProductInfo.ProductUnitPriceInEuro},
                            ProductQuantityPriceInEuro = {fullProductInfo.ProductQuantityPriceInEuro},
                            TripExpenses = {fullProductInfo.TripExpenses}, ProductExpensesCostPrice = {fullProductInfo.ProductExpensesCostPrice},
                            ProductSoldPrice = {fullProductInfo.ProductSoldPrice}, ProductPvm = {fullProductInfo.ProductPvm},
                            ProductSoldPriceWithPvm = {fullProductInfo.ProductSoldPriceWithPvm}, ProductSold = {fullProductInfo.ProductSold},
                            ProductProfit = {fullProductInfo.ProductProfit}, Discount = {fullProductInfo.Discount},
                            Search = '{searchFormat}'
                        WHERE ProductId = {fullProductInfo.ProductId}
                ";

            return updateProductQuery;
        }
    }
}
