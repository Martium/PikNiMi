﻿using System.Collections.Generic;
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
        private const string FullProductInfoTable = "FullProductInfoTable";

        public SqlLiteRepositoryQueryCalls()
        {
            _dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString);
        }
        public static string GetFullProductInfo()
        {
            string getExistingServiceQuery =
                $@"
                    SELECT * FROM {FullProductInfoTable}
                ";

            return getExistingServiceQuery;
        }

        public async Task<IEnumerable<Task<FullProductInfoModel>>> GetAllOfFullProductInfo()
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                string getAllCommand = SqlLiteRepositoryQueryCalls.GetFullProductInfo();

                Task<IEnumerable<Task<FullProductInfoModel>>> getExistingInfo =
                    _dbConnection.QueryAsync<Task<FullProductInfoModel>>(getAllCommand);

                return await getExistingInfo;
            }
        }
    }
}
