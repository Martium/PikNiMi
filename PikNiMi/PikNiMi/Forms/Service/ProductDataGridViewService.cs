using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Models;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Service;
using PikNiMi.Repository.SqlLite;

namespace PikNiMi.Forms.Service
{
    public class ProductDataGridViewService
    {
        private readonly RepositoryQueryCalls _repositoryQueryCalls;
        private readonly NumberService _numberService;

        public ProductDataGridViewService()
        {
            _numberService = new NumberService(new InvariantCultureNumberService());
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
        }

        public DataGridView SetFullRowSelectMode(DataGridView productDataGridView)
        {
            productDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            return productDataGridView;
        }

        public DataGridView SetAutoFontSizeColumnsAndRows(DataGridView productDataGridView, bool isMaximized)
        {
            if (isMaximized)
            {
                productDataGridView.Font = FormFontConstants.MaximizedFontSize;
            }
            else
            {
                productDataGridView.Font = FormFontConstants.DefaultFontSize;
            }
            productDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            productDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            return productDataGridView;
        }

        private BindingSource SetBidingSourceForProductDataGridView()
        {
            var bidingSourceProductModel = new FullProductInfoModel();
            BindingSource productBidingSource = new BindingSource {bidingSourceProductModel};
            return productBidingSource;
        }

        private FullProductInfoModel GetAllInfoFromRow(DataGridView productDataGridView, int row)
        {
            FullProductInfoModel productInfoModel = new FullProductInfoModel()
            {
                ProductId = _numberService.ParseStringToNumber(GetCellValue(productDataGridView, row, 0)),
                ProductReceiptDate = GetCellValue(productDataGridView, row, 1),
                ProductType = GetCellValue(productDataGridView, row, 2),

                ProductDescription = GetCellValue(productDataGridView, row, 3),
                ProductColor = GetCellValue(productDataGridView, row, 4),
                ProductSize = GetCellValue(productDataGridView, row, 5),
                ProductCare = GetCellValue(productDataGridView, row, 6),
                ProductMadeStuff = GetCellValue(productDataGridView, row, 7),
                ProductMadeIn = GetCellValue(productDataGridView, row, 8),

                ProductQuantity = _numberService.TryParseStringToNumberOrZero(GetCellValue(productDataGridView, row, 9)),
                ProductQuantityLeft = _numberService.TryParseStringToNumberOrZero(GetCellValue(productDataGridView, row, 10)),
                ProductOriginalUnitPriceAtOriginalCurrency = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 11)),
                ProductQuantityPriceAtOriginalCurrency = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 12)),
                ProductUnitPriceInEuro = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 13)),
                ProductQuantityPriceInEuro = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 14)),
                TripExpenses = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 15)),
                ProductExpensesCostPrice = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 16)),
                ProductSoldPrice = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 17)),
                ProductPvm = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 18)),
                ProductSoldPriceWithPvm = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView,row, 19)),
                ProductSold = _numberService.TryParseStringToNumberOrZero(GetCellValue(productDataGridView, row, 20)),
                ProductProfit = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 21)),
                Discount = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, row, 22))
            };

            return productInfoModel;
        }

        private string GetCellValue(DataGridView productDataGridView, int row, int cell)
        {
            string cellValue;

            if (productDataGridView.Rows[row].Cells[cell].Value != null)
            {
                cellValue = productDataGridView.Rows[row].Cells[cell].Value.ToString();
            }
            else
            {
                cellValue = null;
            }

            return cellValue;
        }

        public List<FullProductInfoModel> GetLastLoadInfoFromDataGridView(DataGridView productDataGridView)
        {
            var lastLoadInfo = new List<FullProductInfoModel>();

            int rowCount = productDataGridView.RowCount;

            for (int row = 0; row < rowCount; row++)
            {
                var fullRowInfo = GetAllInfoFromRow(productDataGridView, row);

                lastLoadInfo.Add(fullRowInfo);
            }

            return lastLoadInfo;
        }

        public DataGridView LoadLastInfo(DataGridView productDataGridView, List<FullProductInfoModel> lastProductInfo)
        {
            var productBidingSource = SetBidingSourceForProductDataGridView();
            productBidingSource.DataSource = lastProductInfo;
            productDataGridView.DataSource = productBidingSource;

            return productDataGridView;
        }

        public async Task<DataGridView> LoadFullProductInfo(DataGridView productDataGridView)
        {
            var productBidingSource = SetBidingSourceForProductDataGridView();
            productBidingSource.DataSource = await _repositoryQueryCalls.GetAllOfFullProductInfo();
            productDataGridView.DataSource = productBidingSource;
            //Change header size and text to LT introduceMethod

            return  productDataGridView;
        }

        public async Task<DataGridView> LoadFullProductInfoBySelectedProductType(string productType, DataGridView productDataGridView)
        {
            var productBidingSource = SetBidingSourceForProductDataGridView();
            productBidingSource.DataSource =
                await _repositoryQueryCalls.GetAllOfProductInfoBySelectedProductType(productType);
            productDataGridView.DataSource = productBidingSource;
            return productDataGridView;
        }

        public async Task<DataGridView> LoadFullProductInfoBySearchPhrase(DataGridView productDataGridView,
            string searchPhrase)
        {
            var productBidingSource = SetBidingSourceForProductDataGridView();
            productBidingSource.DataSource = await _repositoryQueryCalls.GetAllInfoBySearchPhrase(searchPhrase);
            productDataGridView.DataSource = productBidingSource;
            return productDataGridView;
        }

        public async Task<DataGridView> LoadFullProductInfoBySearchPhraseAndProductType(DataGridView productDataGridView,
            string searchPhrase, string productType)
        {
            var productBidingSource = SetBidingSourceForProductDataGridView();
            productBidingSource.DataSource =
                await _repositoryQueryCalls.GetAllInfoBySearchAndProductType(searchPhrase, productType);
            productDataGridView.DataSource = productBidingSource;
            return productDataGridView;
        }
        
    }
}
