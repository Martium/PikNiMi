using System.Collections;
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
        private static SQLiteConnection _dbConnection;

        public SqlLiteRepositoryQueryCalls()
        {
            _dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString);
        }
        

        public async Task<IEnumerable<FullProductInfoModel>> GetAllOfFullProductInfo()
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                string getAllCommand = SqlLiteQueryToDataBaseCommands.GetAllOfFullProductInfoCommand();

                Task<IEnumerable<FullProductInfoModel>> getExistingInfo =
                    _dbConnection.QueryAsync<FullProductInfoModel>(getAllCommand);
                var response = await getExistingInfo;

                return response;
            }
        }
    }
}
