using PikNiMi.Interface.RepositoryInterface;

namespace PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository
{
    public class RepositoryCreate 
    {
        private readonly IRepositoryCreate _repositoryCreate;

        public RepositoryCreate(IRepositoryCreate repositoryCreate)
        {
            _repositoryCreate = repositoryCreate;
        }

        public void CreateRepositoryFile()
        {
           _repositoryCreate.InitializeDatabaseIfNotExists();
        }

       
    }
}
