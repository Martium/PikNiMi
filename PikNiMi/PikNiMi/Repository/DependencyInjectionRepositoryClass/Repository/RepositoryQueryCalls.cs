using System.Collections.Generic;
using System.Threading.Tasks;
using PikNiMi.Interface.RepositoryInterface;
using PikNiMi.Models;

namespace PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository
{
    public class RepositoryQueryCalls
    {
        private readonly IRepositoryQueryCalls _repository;

        public RepositoryQueryCalls(IRepositoryQueryCalls repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FullProductInfoModel>> GetAllOfFullProductInfo()
        {
            var getInfo = _repository.GetAllOfFullProductInfo();
            return await getInfo;
        }

        public Task<IEnumerable<FullProductInfoModel>> GetAllOfProductInfoBySelectedProductType(string productType)
        {
            var getInfo = _repository.GetAllOfProductInfoBySelectedProductType(productType);
            return getInfo;
        }

        public Task<IEnumerable<FullProductInfoModel>> GetAllInfoBySearchPhrase(string searchPhrase)
        {
            var getInfo = _repository.GetAllInfoBySearchPhrase(searchPhrase);
            return getInfo;
        }

        public Task<IEnumerable<FullProductInfoModel>> GetAllInfoBySearchAndProductType(string searchPhrase,
            string productType)
        {
            var getInfo = _repository.GetAllInfoBySearchAndProductType(searchPhrase, productType);
            return getInfo;
        }

        public Task<int> CreateNewFullProductInfo(FullProductInfoModel fullProductInfo,
            string[] search)
        {
            var newProduct = _repository.AddNewFullProductInfo(fullProductInfo, search);
            return newProduct;
        }

        public Task<int> UpdateExistingFullProductInfo(FullProductInfoModel fullProductInfo, string[] search)
        {
            var updatedProduct = _repository.UpdateExistingFullProductInfo(fullProductInfo, search);
            return updatedProduct;
        }

        public Task<ProductAdditionalInfoModel> GetAdditionalProductInfoById(int productId)
        {
            var additionalInfo = _repository.GetAdditionalProductInfoById(productId);
            return additionalInfo;
        }

        public Task<IEnumerable<ProductQuantityModel>> GetAllFullProductinfoIdByDate(string date)
        {
            var idAndQuantityByDate = _repository.GetAllFullProductinfoIdAndQuantityByDate(date);
            return idAndQuantityByDate;
        }

        public Task<int> UpdateAllTripExpensesRowsByDate(string date, double tripExpenses)
        {
            var rowsUpdate = _repository.UpdateAllTripExpensesRowsByDate(date, tripExpenses);
            return rowsUpdate;
        }

        public Task<int> AddNewAdditionalInfoById(int id, ProductAdditionalInfoModel additionalInfo)
        {
            var task = _repository.AddNewAdditionalInfoById(id, additionalInfo);
            return task;
        }

        public Task<int> UpdateAdditionalInfoById(int id, ProductAdditionalInfoModel additionalInfo)
        {
            var task = _repository.UpdateAdditionalInfoById(id, additionalInfo);
            return task;
        }

        public Task<int> GetMaxIdFromFullProductInfo()
        {
            var task = _repository.GetMaxIdFromFullProductInfo();
            return task;
        }

        public Task<IEnumerable<FullProductInfoMainInfoForCalculationsStartModel>> GetAllInfoForCalculationFullProductInfo(string date)
        {
            var task = _repository.GetAllInfoForCalculationFullProductInfo(date);
            return task;
        }

        public Task<int> UpdateFullProductInfoByDateQuickCalculation(FullProductInfoCalculationModel calculation)
        {
            var task = _repository.UpdateFullProductInfoByDateQuickCalculation(calculation);
            return task;
        }

        public Task<int> UpdateProfitWantByDateQuickCalculation(double profitWant, int id)
        {
            var task = _repository.UpdateProfitWantByDateQuickCalculation(profitWant: profitWant, id);
            return task;
        }

        public Task<int> AddNewProductType(string productType)
        {
            var task = _repository.AddNewProductType(productType);
            return task;
        }

        public Task<IEnumerable<string>> GetAllProductType()
        {
            var task = _repository.GetAllProductType();
            return task;
        }

        public Task<int> DeleteExistingProductType(string productType)
        {
            var task = _repository.DeleteExistingProductType(productType);
            return task;
        }

        public Task<IEnumerable<string>> GetAllExistingYears()
        {
            var task = _repository.GetAllExistingYears();
            return task;
        }

        public Task<IEnumerable<string>> GetAllExistingDates()
        {
            var task = _repository.GetAllExistingDates();
            return task;
        }
    }
}
