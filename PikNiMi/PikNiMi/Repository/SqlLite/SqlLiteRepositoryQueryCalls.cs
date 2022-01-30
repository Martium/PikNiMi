using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;
using PikNiMi.Interface.RepositoryInterface;
using PikNiMi.Models;

namespace PikNiMi.Repository.SqlLite
{
    public class SqlLiteRepositoryQueryCalls : IRepositoryQueryCalls
    {
        private static readonly string ConnectionString = SqlLiteDataBaseConfiguration.ConnectionString;

        public async Task<IEnumerable<FullProductInfoModel>> GetAllOfFullProductInfo()
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string getAllCommand = SqlLiteQueryToDataBaseCommands.GetAllOfFullProductInfoCommand();

                Task<IEnumerable<FullProductInfoModel>> getExistingInfo =
                    dbConnection.QueryAsync<FullProductInfoModel>(getAllCommand);
                var response = await getExistingInfo;

                return response;
            }
        }

        public Task<IEnumerable<FullProductInfoModel>> GetAllOfProductInfoBySelectedProductType(string productType)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string searchTypeCommand =
                    SqlLiteQueryToDataBaseCommands.SearchByFullProductInfo(productType);

                Task<IEnumerable<FullProductInfoModel>> existingInfo =
                    dbConnection.QueryAsync<FullProductInfoModel>(searchTypeCommand);

                return existingInfo;
            }
        }
    }
}
