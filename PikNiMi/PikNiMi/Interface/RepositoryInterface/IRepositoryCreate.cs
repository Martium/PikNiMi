namespace PikNiMi.Interface.RepositoryInterface
{
    public interface IRepositoryCreate
    {
        void InitializeDatabaseIfNotExists();
        void DropAllTablesCommand();
        void CreateAllTablesCommand();
    }
}
