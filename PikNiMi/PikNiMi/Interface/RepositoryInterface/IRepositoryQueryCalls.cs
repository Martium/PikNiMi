using System.Collections.Generic;
using System.Threading.Tasks;
using PikNiMi.Models;

namespace PikNiMi.Interface.RepositoryInterface
{
    public interface IRepositoryQueryCalls
    {
        Task<IEnumerable<FullProductInfoModel>> GetAllOfFullProductInfo();
        Task<IEnumerable<FullProductInfoModel>> GetAllOfProductInfoBySelectedProductType(string productType);
        Task<IEnumerable<FullProductInfoModel>> GetAllInfoBySearchPhrase(string searchPhrase);
        Task<IEnumerable<FullProductInfoModel>> GetAllInfoBySearchAndProductType(string searchPhrase,
            string productType);
        Task<int> AddNewFullProductInfo(FullProductInfoModel fullProductInfo, string[] search);
        Task<int> UpdateExistingFullProductInfo(FullProductInfoModel fullProductInfo, string[] search);
        Task<ProductAdditionalInfoModel> GetAdditionalProductInfoById(int productId);
        Task<IEnumerable<ProductQuantityModel>> GetAllFullProductinfoIdAndQuantityByDate(string date);
        Task<int> UpdateAllTripExpensesRowsByDate(string date, double tripExpenses);
        Task<int> AddNewAdditionalInfoById(int id, ProductAdditionalInfoModel additionalInfo);
        Task<int> UpdateAdditionalInfoById(int id, ProductAdditionalInfoModel additionalInfo);
        Task<int> GetMaxIdFromFullProductInfo();
        Task<IEnumerable<FullProductInfoMainInfoForCalculationsStartModel>> GetAllInfoForCalculationFullProductInfo(string date);
        Task<int> UpdateFullProductInfoByDateQuickCalculation(FullProductInfoCalculationModel calculation);
        Task<int> UpdateProfitWantByDateQuickCalculation(double profitWant, int id);
        Task<int> AddNewProductType(string productType);
        Task<IEnumerable<string>> GetAllProductType();
    }

}
