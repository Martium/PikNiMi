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

        public Task<IEnumerable<ProductQuantityModel>> GetAllFullProductinfoIdAndQuantityByDate(string date)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string allIdCommand = SqlLiteQueryToDataBaseCommands.GetAllFullProductInfoIdByDate(date);

                var info = dbConnection.QueryAsync<ProductQuantityModel>(allIdCommand);

                return info;
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

        public Task<int> AddNewAdditionalInfoById(int id, ProductAdditionalInfoModel additionalInfo)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string addNewCommand = SqlLiteQueryToDataBaseCommands.AddNewAdditionalInfoById(id, additionalInfo);

                var result = dbConnection.ExecuteAsync(addNewCommand);

                return result;
            }
        }

        public Task<int> UpdateAdditionalInfoById(int id, ProductAdditionalInfoModel additionalInfo)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string updateNewCommand = SqlLiteQueryToDataBaseCommands.UpdateAdditionalInfoById(id, additionalInfo);

                var result = dbConnection.ExecuteAsync(updateNewCommand);

                return result;
            }
        }

        public Task<int> GetMaxIdFromFullProductInfo()
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string getMaxId = SqlLiteQueryToDataBaseCommands.GetMaxIdFromFullProductInfo();

                var result = dbConnection.QuerySingleAsync<int>(getMaxId);

                return result;
            }
        }

        public Task<IEnumerable<FullProductInfoMainInfoForCalculationsStartModel>> GetAllInfoForCalculationFullProductInfo(string date)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string sqlCommand = SqlLiteQueryToDataBaseCommands.GetMainInfoForFullProductInfoCalculations(date);

                var result = dbConnection.QueryAsync<FullProductInfoMainInfoForCalculationsStartModel>(sqlCommand);

                return result;
            }
        }

        public Task<int> UpdateFullProductInfoByDateQuickCalculation(FullProductInfoCalculationModel calculation)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string sqlCommand =
                    SqlLiteQueryToDataBaseCommands.UpdateFullProductInfoByDateQuickCalculation(calculation);

                var result = dbConnection.ExecuteAsync(sqlCommand);

                return result;
            }
        }

        public Task<int> UpdateProfitWantByDateQuickCalculation(double profitWant, int id)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();

                string sqlCommand = SqlLiteQueryToDataBaseCommands.UpdateProfitWant(profitWant: profitWant, id);

                var result = dbConnection.ExecuteAsync(sqlCommand);

                return result;
            }
        }

        public Task<int> AddNewProductType(string productType)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();
                string command = SqlLiteQueryToDataBaseCommands.AddNewProductType(productType);

                var result = dbConnection.ExecuteAsync(command);

                return result;
            }
        }

        public Task<IEnumerable<string>> GetAllProductType()
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();
                string command = SqlLiteQueryToDataBaseCommands.GetAllExistingProductType();

                var result = dbConnection.QueryAsync<string>(command);

                return result;
            }
        }

        public Task<int> DeleteExistingProductType(string productType)
        {
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();
                string command = SqlLiteQueryToDataBaseCommands.DeleteProductType(productType);

                var result = dbConnection.ExecuteAsync(command);

                return result;
            }
        }
    }
}
