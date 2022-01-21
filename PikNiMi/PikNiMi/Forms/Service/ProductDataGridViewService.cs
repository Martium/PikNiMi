using System.Threading.Tasks;
using System.Windows.Forms;
using PikNiMi.Models;
using PikNiMi.Repository.DependencyInjectionRepositoryClass;
using PikNiMi.Repository.SqlLite;

namespace PikNiMi.Forms.Service
{
    public class ProductDataGridViewService
    {
        private readonly RepositoryQueryCalls _repositoryQueryCalls;

        public ProductDataGridViewService()
        {
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
        }

        public async Task<DataGridView> LoadFullProductInfo(DataGridView productDataGridView)
        {
            var bidingSourceProductModel = new FullProductInfoModel();
            BindingSource productBidingSource = new BindingSource {bidingSourceProductModel};
            productBidingSource.DataSource = await _repositoryQueryCalls.GetAllOfFullProductInfo();
            productDataGridView.DataSource = productBidingSource;
            return  productDataGridView;
        }
    }
}
