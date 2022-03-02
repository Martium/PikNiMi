﻿using System.Collections.Generic;
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
        Task<IEnumerable<int>> GetAllFullProductinfoIdByDate(string date);
        Task<int> UpdateAllTripExpensesRowsByDate(string date, double tripExpenses);

    }

}
