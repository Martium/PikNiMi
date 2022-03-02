using System;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;

namespace PikNiMi.Repository.SqlLite
{
    public class FakeRepository
    {
        private const string FullProductInfoTable = "FullProductInfoTable";

        private readonly string[] _firstAllInfo =
        {
            "2022-02-22",
            "Suknelė",
            "graži daili suknė",
            "red",
            "xl",
            "neskalbti",
            "medvilnė",
            "Lenkija",
            "10",
            "9",
            "4.2",
            "42",
            "1.05",
            "10.5",
            "0.2",
            "1.25",
            "2",
            "2.42",
            "1",
            "0.95"
        };

        private readonly string[] _secondAllInfo =
        {
            "2022-02-22",
            "Džinsai",
            "plėšyti vyriški džinsai",
            "black",
            "M",
            "skalbiami",
            "sintetika",
            "Lenkija",
            "10",
            "9",
            "4.2",
            "42",
            "1.05",
            "10.5",
            "0.2",
            "1.25",
            "2",
            "2.42",
            "1",
            "NULL"
        };

        private readonly string[] _thirdAllInfo =
        {
            "2022-02-22",
            "Džemperis",
            "grublėtas dryžuotas",
            "blue",
            "XXL",
            "lyginamas",
            "vilna",
            "Lenkija",
            "10",
            "9",
            "4.2",
            "42",
            "1.05",
            "10.5",
            "0.2",
            "1.25",
            "2",
            "2.42",
            "1",
            "0.95"
        };

        private string ImplementSearchData(string[] allInfo)
        {
            string searchFormat = string.Empty;

            foreach (var info in allInfo)
            {
                searchFormat += $"{info} + {Environment.NewLine} ";
            }

            return searchFormat;
        }
        public void FillTestingInfoForProduct()
        {
            string firstSearchInfo = ImplementSearchData(_firstAllInfo);
            string secondSearchInfo = ImplementSearchData(_secondAllInfo);
            string thirdSearchInfo = ImplementSearchData(_thirdAllInfo);
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string testingInfo =
                    $@"
                    BEGIN TRANSACTION;
                    INSERT INTO '{FullProductInfoTable}'
                    VALUES (NULL, '2022-01-22', 'Suknelė', 'graži daili suknė', 'red', 'xl', 'neskalbti', 'medvilnė', 'Lenkija', 10, 
                       9, 4.2, 42, 1.05, 10.5, 0.2, 1.25, 2, 0.42, 2.42, 1, 0.95, NULL, '{firstSearchInfo}');
                    INSERT INTO '{FullProductInfoTable}'
                    VALUES (NULL, '2022-01-22', 'Džinsai', 'plėšyti vyriški džinsai', 'black', 'M', 'skalbiami', 'sintetika', 'Lenkija', 10, 
                       9, 4.2, 42, 1.05, 10.5, 0.2, 1.25, 2, 0.42, 2.42, 1, NULL, NULL, '{secondSearchInfo}');
                    INSERT INTO '{FullProductInfoTable}'
                    VALUES (NULL, '2022-01-22', 'Džemperis', 'grublėtas dryžuotas', 'blue', 'XXL', 'lyginamas', 'vilna', 'Lenkija', 10, 
                       9, 4.2, 42, 1.05, 10.5, 0.2, 1.25, 2, 0.42,2.42, 1, 0.95, NULL, '{thirdSearchInfo}');
                    COMMIT;
                ";

                SQLiteCommand fillInvoiceTestingInfoTableCommand = new SQLiteCommand(testingInfo, dbConnection);
                fillInvoiceTestingInfoTableCommand.ExecuteNonQuery();
            }
           
        }

        public void FillTestingAdditionalInfoForProduct()
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string testingInfo = 
                    $@"
                        BEGIN TRANSACTION;
                        INSERT INTO 'ProductAdditionalInfo'
                        VALUES (1, 5, 4);
                        INSERT INTO 'ProductAdditionalInfo'
                        VALUES (2, 5, 4);
                        INSERT INTO 'ProductAdditionalInfo'
                        VALUES (3, 5, 4);
                        COMMIT;
                    ";

                SQLiteCommand fillInvoiceTestingInfoTableCommand = new SQLiteCommand(testingInfo, dbConnection);
                fillInvoiceTestingInfoTableCommand.ExecuteNonQuery();
            }
        }
    }
}
