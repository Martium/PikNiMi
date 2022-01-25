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

        private BindingSource SetBidingSourceForProductDataGridView()
        {
            var bidingSourceProductModel = new FullProductInfoModel();
            BindingSource productBidingSource = new BindingSource {bidingSourceProductModel};
            return productBidingSource;
        }

        public async Task<DataGridView> LoadFullProductInfo(DataGridView productDataGridView)
        {
            var productBidingSource = SetBidingSourceForProductDataGridView();
            productBidingSource.DataSource = await _repositoryQueryCalls.GetAllOfFullProductInfo();
            productDataGridView.DataSource = productBidingSource;
            //Change header size and text to LT introduceMethod
            return  productDataGridView;
        }

        public async Task<DataGridView> LoadFullProductInfoBySearchPhraseAndProductType(string searchPhrase,
            string productType, DataGridView productDataGridView)
        {
            var productBidingSource = SetBidingSourceForProductDataGridView();
            productBidingSource.DataSource =
                await _repositoryQueryCalls.GetAllOfProductInfoBySearchPhraseAndProductType(searchPhrase, productType);
            productDataGridView.DataSource = productBidingSource;
            return productDataGridView;
        }
        
    }
}
