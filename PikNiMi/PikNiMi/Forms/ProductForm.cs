using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.Models;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Service;
using PikNiMi.Repository.SqlLite;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class ProductForm : Form
    {
        private readonly LanguageTranslator _languageTranslator;
        private readonly RepositoryQueryCalls _repositoryQueryCalls;
        private readonly NumberService _numberService;

        private readonly ComboBoxService _comboBoxService;

        public ProductForm()
        {
            InitializeComponent();

            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
            _numberService = new NumberService(new InvariantCultureNumberService());

            _comboBoxService = new ComboBoxService(_languageTranslator);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            TableLayoutPanel.Font = FormFontConstants.DefaultFontSize;
            SetTextBoxLength();
            SetLanguageText();
            PopulateComboBoxInfo();
        }

        private void ProductForm_Resize(object sender, EventArgs e)
        {
            TableLayoutPanel.Font = WindowState == FormWindowState.Maximized ? FormFontConstants.MaximizedFontSize : FormFontConstants.DefaultFontSize;
        }

        private void ProductDescriptionTextBoxResizeButton_Click(object sender, EventArgs e)
        {
            OpenNewForm(new TextBoxResizeForm());
        }

        private void AnotherForm_Closed(object sender, EventArgs e)
        {
            this.Show();

            //load last data update new data
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // testing passed
            FullProductInfoModel fullProductInfo = new FullProductInfoModel()
            {
                ProductReceiptDate = ProductReceiptDateTextBox.Text,
                ProductType = "Suknelė", // for testing 
                ProductDescription = ProductDescriptionTextBox.Text,
                ProductColor = ProductColorTextBox.Text,
                ProductSize = ProductSizeTextBox.Text,
                ProductCare = ProductCareTextBox.Text,
                ProductMadeStuff = ProductMadeStuffTextBox.Text,
                ProductMadeIn = ProductMadeInTextBox.Text,

                ProductQuantity = _numberService.TryParseStringToNumberOrZero(ProductQuantityTextBox.Text),
                ProductQuantityLeft = _numberService.TryParseStringToNumberOrZero(ProductQuantityLeftTextBox.Text),
                ProductOriginalUnitPriceAtOriginalCurrency = _numberService.TryParseStringToDoubleNumberOrZero(ProductOriginalUnitPriceAtOriginalCurrencyTextBox.Text),
                ProductQuantityPriceAtOriginalCurrency = _numberService.TryParseStringToDoubleNumberOrZero(ProductQuantityPriceAtOriginalCurrencyTextBox.Text),
                ProductUnitPriceInEuro = _numberService.TryParseStringToDoubleNumberOrZero(ProductUnitPriceInEuroTextBox.Text),
                ProductQuantityPriceInEuro = _numberService.TryParseStringToDoubleNumberOrZero(ProductQuantityPriceInEuroTextBox.Text),
                TripExpenses = _numberService.TryParseStringToDoubleNumberOrZero(TripExpensesTextBox.Text),
                ProductExpensesCostPrice = _numberService.TryParseStringToDoubleNumberOrZero(ProductExpensesCostPriceTextBox.Text),
                ProductSoldPrice = _numberService.TryParseStringToDoubleNumberOrZero(ProductSoldPriceTextBox.Text),
                ProductPvm = _numberService.TryParseStringToDoubleNumberOrZero(ProductPvmTextBox.Text),
                ProductSoldPriceWithPvm = _numberService.TryParseStringToDoubleNumberOrZero(ProductSoldPriceWithPvmTextBox.Text),
                ProductSold = _numberService.TryParseStringToNumberOrZero(ProductSoldTextBox.Text),
                ProductProfit = _numberService.TryParseStringToDoubleNumberOrZero(ProductProfitTextBox.Text),
                Discount = _numberService.TryParseStringToDoubleNumberOrZero(DiscountTextBox.Text)
            };

            string[] search =
            {
                ProductReceiptDateTextBox.Text,
                ProductTypeComboBox.Text,
                ProductDescriptionTextBox.Text,
                ProductColorTextBox.Text,
                ProductSizeTextBox.Text,
                ProductCareTextBox.Text,
                ProductMadeStuffTextBox.Text,
                ProductMadeInTextBox.Text,
                ProductQuantityTextBox.Text,
                ProductQuantityLeftTextBox.Text,
                ProductOriginalUnitPriceAtOriginalCurrencyTextBox.Text,
                ProductQuantityPriceAtOriginalCurrencyTextBox.Text,
                ProductUnitPriceInEuroTextBox.Text,
                ProductQuantityPriceInEuroTextBox.Text,
                TripExpensesTextBox.Text,
                ProductExpensesCostPriceTextBox.Text,
                ProductSoldPriceTextBox.Text,
                ProductPvmTextBox.Text,
                ProductSoldPriceWithPvmTextBox.Text,
                ProductSoldTextBox.Text,
                ProductProfitTextBox.Text,
                DiscountTextBox.Text
            };

            SetButtonControl(false);

            Task<int> taskAffectedRows = _repositoryQueryCalls.CreateNewFullProductInfo(fullProductInfo, search);

            if (taskAffectedRows.IsCompleted)
            {
               MessageBox.Show(@"bingo");
            }
            SetButtonControl(true);
        }

        #region Heplers

        private void OpenNewForm(Form form)
        {
            form.Closed += AnotherForm_Closed;
            HideProductForm(form);
        }

        private void HideProductForm(Form form)
        {
            this.Hide();
            form.Show();

            if (this.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        private void SetButtonControl(bool isAllowed)
        {
            ProductDescriptionTextBoxResizeButton.Enabled = isAllowed;
            SaveButton.Enabled = isAllowed;
        }

        private void SetLanguageText()
        {
            ProductReceiptDateInfoLabel.Text = _languageTranslator.SetProductReceiptDateInfoLabelText();
            ProductDescriptionInfoLabel.Text = _languageTranslator.SetProductDescriptionInfoLabelText();
            ProductColorInfoLabel.Text = _languageTranslator.SetProductColorInfoLabelText();
            ProductSizeInfoLabel.Text = _languageTranslator.SetProductSizeInfoLabelText();
            ProductCareInfoLabel.Text = _languageTranslator.SetProductCareInfoLabelText();
            ProductMadeStuffInfoLabel.Text = _languageTranslator.SetProductMadeStuffInfoLabelText();
            ProductMadeInInfoLabel.Text = _languageTranslator.SetProductMadeInInfoLabelText();
            ProductQuantityInfoLabel.Text = _languageTranslator.SetProductQuantityInfoLabelText();
            ProductQuantityLeftInfoLabel.Text = _languageTranslator.SetProductQuantityLeftInfoLabelText();
            ProductOriginalUnitPriceAtOriginalCurrencyInfoLabel.Text =
                _languageTranslator.SetProductOriginalUnitPriceAtOriginalCurrencyInfoLabelText();
            ProductQuantityPriceAtOriginalCurrencyInfoLabel.Text =
                _languageTranslator.SetProductQuantityPriceAtOriginalCurrencyInfoLabelText();
            ProductUnitPriceInEuroInfoLabel.Text = _languageTranslator.SetProductUnitPriceInEuroInfoLabelText();
            ProductQuantityPriceInEuroInfoLabel.Text = _languageTranslator.SetProductQuantityPriceInEuroInfoLabelText();
            TripExpensesInfoLabel.Text = _languageTranslator.SetTripExpensesInfoLabelText();
            ProductExpensesCostPriceInfoLabel.Text = _languageTranslator.SetProductExpensesCostPriceInfoLabelText();
            ProductSoldPriceInfoLabel.Text = _languageTranslator.SetProductSoldPriceInfoLabelText();
            ProductPvmInfoLabel.Text = _languageTranslator.SetProductPvmInfoLabelText();
            ProductSoldPriceWithPvmInfoLabel.Text = _languageTranslator.SetProductSoldPriceWithPvmInfoLabelText();
            ProductSoldInfoLabel.Text = _languageTranslator.SetProductSoldInfoLabelText();
            ProductProfitInfoLabel.Text = _languageTranslator.SetProductProfitInfoLabelText();
            DiscountInfoLabel.Text = _languageTranslator.SetDiscountInfoLabelText();
            ProductTypeInfoLabel.Text = _languageTranslator.SetProductTypeInfoLabelText();
            ProductWantProfitInfoLabel.Text = _languageTranslator.SetProductWantProfitInfoLabelText();
            MoneyCourseInfoLabel.Text = _languageTranslator.SetMoneyCourseText();

            ProductDescriptionTextBoxResizeButton.Text = _languageTranslator.SetTextBoxResizeButtonText();
            SaveButton.Text = _languageTranslator.SetSaveButtonText();

        }

        private void PopulateComboBoxInfo()
        {
            _comboBoxService.SetProductTypeCustomValues(ProductTypeComboBox);
        }

        private void SetTextBoxLength()
        {
            ProductReceiptDateTextBox.MaxLength = TextBoxLength.ProductDate;
            ProductDescriptionTextBox.MaxLength = TextBoxLength.ProductDescription;
            ProductColorTextBox.MaxLength = TextBoxLength.ProductColor;
            ProductSizeTextBox.MaxLength = TextBoxLength.ProductSize;
            ProductCareTextBox.MaxLength = TextBoxLength.ProductCare;
            ProductMadeStuffTextBox.MaxLength = TextBoxLength.ProductMadeStuff;
            ProductMadeInTextBox.MaxLength = TextBoxLength.ProductMadeIn;

            ProductQuantityTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductQuantityLeftTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductOriginalUnitPriceAtOriginalCurrencyTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductQuantityPriceAtOriginalCurrencyTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductUnitPriceInEuroTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductQuantityPriceInEuroTextBox.MaxLength = TextBoxLength.NumberLength;
            TripExpensesTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductExpensesCostPriceTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductSoldPriceTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductPvmTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductSoldPriceWithPvmTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductSoldTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductProfitTextBox.MaxLength = TextBoxLength.NumberLength;
            DiscountTextBox.MaxLength = TextBoxLength.NumberLength;
            ProductWantProfitTextBox.MaxLength = TextBoxLength.NumberLength;
            MoneyCourseTextBox.MaxLength = TextBoxLength.NumberLength;
        }

        #endregion
        
    }
}
