using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;
using PikNiMi.Interface.RepositoryInterface;
using PikNiMi.Models;
using PikNiMi.Repository.SqlLite;

namespace PikNiMi.Repository.DependencyInjectionRepositoryClass
{
    public class RepositoryQueryCalls
    {
        private readonly IRepositoryQueryCalls _repository;

        public RepositoryQueryCalls(IRepositoryQueryCalls repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Task<FullProductInfoModel>>> GetAllOfFullProductInfo()
        {
            var getInfo = _repository.GetAllOfFullProductInfo();
            return getInfo;
        }

    }
}
