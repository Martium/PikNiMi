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

    }
}
