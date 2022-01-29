using PikNiMi.Interface.RepositoryInterface;

namespace PikNiMi.Repository.DependencyInjectionRepositoryClass
{
    public class RepositoryQueryCalls
    {
        private readonly IRepositoryQueryCalls _repository;

        public RepositoryQueryCalls(IRepositoryQueryCalls repository)
        {
            _repository = repository;
        }
    }
}
