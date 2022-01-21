using System.Collections.Generic;
using System.Threading.Tasks;
using PikNiMi.Interface.RepositoryInterface;
using PikNiMi.Models;

namespace PikNiMi.Repository.DependencyInjectionRepositoryClass
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

    }
}
