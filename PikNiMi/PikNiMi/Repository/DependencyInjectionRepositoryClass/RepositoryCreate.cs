using PikNiMi.Interface.RepositoryInterface;

namespace PikNiMi.Repository.DependencyInjectionRepositoryClass
{
    public class RepositoryCreate 
    {
        private readonly IRepositoryCreate _repositoryCreate;

        public RepositoryCreate(IRepositoryCreate repositoryCreate)
        {
            _repositoryCreate = repositoryCreate;
        }
    }
}
