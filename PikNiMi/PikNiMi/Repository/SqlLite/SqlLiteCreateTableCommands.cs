using System.Collections.Generic;
using PikNiMi.Forms.Constants;

namespace PikNiMi.Repository.SqlLite
{
    public static class SqlLiteCreateTableCommands
    {
        public static Dictionary<string, string> CreateTables()
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

                    [ProductBuyLocation] [nvarchar] ({TextBoxLength.ProductBuyLocation}) NULL,
                    [ProductQuantity] [Integer] NULL,
                    [ProductQuantityLeft] [Integer] NULL,
                    
                    [ProductOriginalUnitPriceAtOriginalCurrency] [Numeric] NULL,
                    [ProductQuantityPriceAtOriginalCurrency] [Numeric] NULL,

                    [ProductUnitPriceInEuro] [Numeric] NULL,
                    [ProductQuantityPriceInEuro] [Numeric] NULL,

                    [TripExpenses] [Numeric] NULL,
                    [ProductExpensesCostPrice] [Numeric] NULL,
                    
                    [ProductSoldPrice] [Numeric] NULL,
                    [ProductSold] [Integer] NULL,
                    [ProductProfit] [Numeric] NULL,

                    UNIQUE (ProductId)
                );
            ";

            var tableCommands = new Dictionary<string, string>()
            {
                {fullProductInfoTable, createFullProductInfoTable}
            };

            return tableCommands;
        }
    }
}
