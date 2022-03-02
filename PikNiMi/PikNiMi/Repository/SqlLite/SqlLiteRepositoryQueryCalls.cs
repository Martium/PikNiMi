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
                    SqlLiteQueryToDataBaseCommands.SearchBySpecificProductType(productType);

                Task<IEnumerable<FullProductInfoModel>> existingInfo =
                    dbConnection.QueryAsync<FullProductInfoModel>(searchTypeCommand);

                return existingInfo;
            }
        }

        public Task<IEnumerable<FullProductInfoModel>> GetAllInfoBySearchPhrase(string searchPhrase)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string searchCommand = SqlLiteQueryToDataBaseCommands.SearchBySearchPhraseAllInfo(searchPhrase);

                Task<IEnumerable<FullProductInfoModel>> existingInfo =
                    dbConnection.QueryAsync<FullProductInfoModel>(searchCommand);

                return existingInfo;
            }
        }

        public Task<IEnumerable<FullProductInfoModel>> GetAllInfoBySearchAndProductType(string searchPhrase, string productType)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string searchCommand =
                    SqlLiteQueryToDataBaseCommands.SearchInfoByProductTypeAndSearchPhrase(productType, searchPhrase);

                Task<IEnumerable<FullProductInfoModel>> existingInfo =
                    dbConnection.QueryAsync<FullProductInfoModel>(searchCommand);

                return existingInfo;
            }
        }

        public Task<int> AddNewFullProductInfo(FullProductInfoModel fullProductInfo, string[] search)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string addNewCommand = SqlLiteQueryToDataBaseCommands.CreateNewFullProductInfo(fullProductInfo, search);

                var newProduct = dbConnection.ExecuteAsync(addNewCommand);

                return newProduct;
            }
        }

        public Task<int> UpdateExistingFullProductInfo(FullProductInfoModel fullProductInfo, string[] search)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string updateCommand =
                    SqlLiteQueryToDataBaseCommands.UpdateExistingFullProductInfo(fullProductInfo, search);

                var updateProduct = dbConnection.ExecuteAsync(updateCommand);

                return updateProduct;
            }
        }

        public Task<ProductAdditionalInfoModel> GetAdditionalProductInfoById(int productId)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string additionalInfoCommand = SqlLiteQueryToDataBaseCommands.GetAdditionalProductInfoById(productId);

                var additionalInfo = dbConnection.QueryFirstOrDefaultAsync<ProductAdditionalInfoModel>(additionalInfoCommand);
                return additionalInfo;
            }
        }

        public Task<IEnumerable<int>> GetAllFullProductinfoIdByDate(string date)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string allIdCommand = SqlLiteQueryToDataBaseCommands.GetAllFullProductInfoIdByDate(date);

                var idInfo = dbConnection.QueryAsync<int>(allIdCommand);

                return idInfo;
            }
        }

        public Task<int> UpdateAllTripExpensesRowsByDate(string date, double tripExpenses)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string tripExpensesCommand =
                    SqlLiteQueryToDataBaseCommands.UpdateFullProductInfoTripExpensesByDate(date, tripExpenses);

                var result = dbConnection.ExecuteAsync(tripExpensesCommand);

                return result;
            }
        }
    }
}
