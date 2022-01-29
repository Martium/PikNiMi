using System.Data.SQLite;

namespace PikNiMi.Repository.SqlLite
{
    public class FakeRepository
    {
        private const string FullProductInfoTable = "FullProductInfoTable";

        public void FillTestingInfoForProduct()
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string testingInfo =
                    $@"
                    BEGIN TRANSACTION;
                    INSERT INTO '{FullProductInfoTable}'
                    VALUES (NULL, '2022-01-22', 'Suknelė', 'graži daili suknė', 'red', 'xl', 'neskalbti', 'medvilnė', 'Lenkija', 10, 
                       9, 4.2, 42, 1.05, 10.5, 0.2, 1.25, 2, 1, 0.95);
                    INSERT INTO '{FullProductInfoTable}'
                    VALUES (NULL, '2022-01-22', 'Džinsai', 'plėšyti vyriški džinsai', 'black', 'M', 'skalbiami', 'sintetika', 'Lenkija', 10, 
                       9, 4.2, 42, 1.05, 10.5, 0.2, 1.25, 2, 1, NULL);
                    INSERT INTO '{FullProductInfoTable}'
                    VALUES (NULL, '2022-01-22', 'Džemperis', 'grublėtas dryžuotas', 'blue', 'XXL', 'lyginamas', 'vilna', 'Lenkija', 10, 
                       9, 4.2, 42, 1.05, 10.5, 0.2, 1.25, 2, 1, 0.95);
                    COMMIT;
                ";

                SQLiteCommand fillInvoiceTestingInfoTableCommand = new SQLiteCommand(testingInfo, dbConnection);
                fillInvoiceTestingInfoTableCommand.ExecuteNonQuery();
            }
           
        }
    }
}
