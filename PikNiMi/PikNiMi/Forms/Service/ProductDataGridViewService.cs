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

        private string GetCellValue(DataGridView productDataGridView, int cell)
        {
            return productDataGridView.SelectedRows[0].Cells[cell].Value.ToString();
        }

        private void SetFullProductInfoAllHeadersTexts(LanguageTranslator languageTranslator, DataGridView productDataGridView)
        {
            productDataGridView.Columns[0].HeaderText = @"Id";

            productDataGridView.Columns[1].HeaderText = languageTranslator.SetProductReceiptDateInfoLabelText();
            productDataGridView.Columns[2].HeaderText = languageTranslator.SetProductTypeInfoLabelText();
            productDataGridView.Columns[3].HeaderText = languageTranslator.SetProductDescriptionInfoLabelText();
            productDataGridView.Columns[4].HeaderText = languageTranslator.SetProductColorInfoLabelText();
            productDataGridView.Columns[5].HeaderText = languageTranslator.SetProductSizeInfoLabelText();
            productDataGridView.Columns[6].HeaderText = languageTranslator.SetProductCareInfoLabelText();
            productDataGridView.Columns[7].HeaderText = languageTranslator.SetProductMadeStuffInfoLabelText();
            productDataGridView.Columns[8].HeaderText = languageTranslator.SetProductMadeInInfoLabelText();
            productDataGridView.Columns[9].HeaderText = languageTranslator.SetProductQuantityInfoLabelText();
            productDataGridView.Columns[10].HeaderText = languageTranslator.SetProductQuantityLeftInfoLabelText();
            productDataGridView.Columns[11].HeaderText = languageTranslator.SetProductOriginalUnitPriceAtOriginalCurrencyInfoLabelText();
            productDataGridView.Columns[12].HeaderText = languageTranslator.SetProductQuantityPriceAtOriginalCurrencyInfoLabelText();
            productDataGridView.Columns[13].HeaderText = languageTranslator.SetProductUnitPriceInEuroInfoLabelText();
            productDataGridView.Columns[14].HeaderText = languageTranslator.SetProductQuantityPriceInEuroInfoLabelText();
            productDataGridView.Columns[15].HeaderText = languageTranslator.SetTripExpensesInfoLabelText();
            productDataGridView.Columns[16].HeaderText = languageTranslator.SetProductExpensesCostPriceInfoLabelText();
            productDataGridView.Columns[17].HeaderText = languageTranslator.SetProductSoldPriceInfoLabelText();
            productDataGridView.Columns[18].HeaderText = languageTranslator.SetProductPvmInfoLabelText();
            productDataGridView.Columns[19].HeaderText = languageTranslator.SetProductSoldPriceWithPvmInfoLabelText();
            productDataGridView.Columns[20].HeaderText = languageTranslator.SetProductSoldInfoLabelText();
            productDataGridView.Columns[21].HeaderText = languageTranslator.SetProductProfitInfoLabelText();
            productDataGridView.Columns[22].HeaderText = languageTranslator.SetDiscountInfoLabelText();
        }

        public FullProductInfoModel GetAllInfoFromSelectedRow(DataGridView productDataGridView)
        {
            FullProductInfoModel productInfoModel = new FullProductInfoModel()
            {
                ProductId = _numberService.ParseStringToNumber(GetCellValue(productDataGridView, 0)),
                ProductReceiptDate = GetCellValue(productDataGridView, 1),
                ProductType = GetCellValue(productDataGridView, 2),

                ProductDescription = GetCellValue(productDataGridView, 3),
                ProductColor = GetCellValue(productDataGridView, 4),
                ProductSize = GetCellValue(productDataGridView, 5),
                ProductCare = GetCellValue(productDataGridView, 6),
                ProductMadeStuff = GetCellValue(productDataGridView, 7),
                ProductMadeIn = GetCellValue(productDataGridView, 8),

                ProductQuantity = _numberService.TryParseStringToNumberOrZero(GetCellValue(productDataGridView, 9)),
                ProductQuantityLeft = _numberService.TryParseStringToNumberOrZero(GetCellValue(productDataGridView, 10)),
                ProductOriginalUnitPriceAtOriginalCurrency = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 11)),
                ProductQuantityPriceAtOriginalCurrency = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 12)),
                ProductUnitPriceInEuro = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 13)),
                ProductQuantityPriceInEuro = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 14)),
                TripExpenses = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 15)),
                ProductExpensesCostPrice = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 16)),
                ProductSoldPrice = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 17)),
                ProductPvm = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 18)),
                ProductSoldPriceWithPvm = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 19)),
                ProductSold = _numberService.TryParseStringToNumberOrZero(GetCellValue(productDataGridView, 20)),
                ProductProfit = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 21)),
                Discount = _numberService.TryParseStringToDoubleNumberOrZero(GetCellValue(productDataGridView, 22))
            };

            return productInfoModel;
        }

        public async Task<DataGridView> LoadFullProductInfo(DataGridView productDataGridView, LanguageTranslator languageTranslator)
        {
            var productBidingSource = SetBidingSourceForProductDataGridView();
            productBidingSource.DataSource = await _repositoryQueryCalls.GetAllOfFullProductInfo();
            productDataGridView.DataSource = productBidingSource;
            SetFullProductInfoAllHeadersTexts(languageTranslator, productDataGridView);

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
