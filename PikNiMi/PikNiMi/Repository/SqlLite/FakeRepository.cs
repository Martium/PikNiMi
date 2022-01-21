namespace PikNiMi.Repository.SqlLite
{
    public class FakeRepository
    {
        private const string FullProductInfoTable = "FullProductInfoTable";


        public void FillTestingInfoForProduct()
        {

            string testingInfo = 
                $@"
                    BEGIN TRANSACTION;
                    INSERT INTO '{FullProductInfoTable}'
                    VALUES (
                    );
                    COMMIT;
                  
                ";
        }
    }
}
