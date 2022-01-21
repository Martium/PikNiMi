using System.Collections.Generic;
using System.Threading.Tasks;
using PikNiMi.Models;

namespace PikNiMi.Interface.RepositoryInterface
{
    public interface IRepositoryQueryCalls
    {
        Task<IEnumerable<FullProductInfoModel>> GetAllOfFullProductInfo();
    }

}
