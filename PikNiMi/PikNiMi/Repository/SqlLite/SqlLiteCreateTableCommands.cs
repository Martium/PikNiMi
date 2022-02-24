using System.Collections.Generic;
using PikNiMi.Forms.Constants;

namespace PikNiMi.Repository.SqlLite
{
    public static class SqlLiteCreateTableCommands
    {
        public static Dictionary<string, string> GetTablesCommand()
        {
            string fullProductInfoTable = "FullProductInfoTable";
            string createFullProductInfoTable = 
            $@"
                CREATE TABLE [{fullProductInfoTable}] (
                    [ProductId] [Integer] PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [ProductReceiptDate] [nvarchar] ({TextBoxLength.ProductDate}) NOT NULL,
                    [ProductType] [nvarchar] ({TextBoxLength.ProductType}) NOT NULL,

                    [ProductDescription] [nvarchar] ({TextBoxLength.ProductDescription}) NULL,
                    [ProductColor] [nvarchar] ({TextBoxLength.ProductColor}) NULL,
                    [ProductSize] [nvarchar] ({TextBoxLength.ProductSize}) NULL,
                    [ProductCare] [nvarchar] ({TextBoxLength.ProductCare}) NULL,
                    [ProductMadeStuff] [nvarchar] ({TextBoxLength.ProductMadeStuff}) NULL,

                    [ProductMadeIn] [nvarchar] ({TextBoxLength.ProductMadeIn}) NULL,
                    [ProductQuantity] [Integer] NULL,
                    [ProductQuantityLeft] [Integer] NULL,
                    
                    [ProductOriginalUnitPriceAtOriginalCurrency] [Numeric] NULL,
                    [ProductQuantityPriceAtOriginalCurrency] [Numeric] NULL,

                    [ProductUnitPriceInEuro] [Numeric] NULL,
                    [ProductQuantityPriceInEuro] [Numeric] NULL,

                    [TripExpenses] [Numeric] NULL,
                    [ProductExpensesCostPrice] [Numeric] NULL,
                    
                    [ProductSoldPrice] [Numeric] NULL,
                    [ProductPvm] [Numeric] NULL,
                    [ProductSoldPriceWithPvm] [Numeric] NULL,
                    [ProductSold] [Integer] NULL,
                    [ProductProfit] [Numeric] NULL,
                    [Discount] [Numeric] NULL,

                    [Search] [nvarchar] (3000) NOT NULL,
                    
                    UNIQUE (ProductId)
                );
            ";

            string productAdditionalInfoTable = "ProductAdditionalInfo";
            string createProductAdditionalInfoTable = 
                $@"
                    CREATE TABLE [{productAdditionalInfoTable}] (
                        [Id] [Integer] NOT NULL,
                        [ProfitWant] [Numeric] NULL,
                        [MoneyCourse] [Numeric] NULL,
                        FOREIGN KEY (Id) REFERENCES {fullProductInfoTable} (ProductId) ON DELETE CASCADE,
                        UNIQUE (Id)
                    );
                ";

            var tableCommands = new Dictionary<string, string>()
            {
                {fullProductInfoTable, createFullProductInfoTable},
                {productAdditionalInfoTable, createProductAdditionalInfoTable}
            };

            return tableCommands;
        }

    }
}
