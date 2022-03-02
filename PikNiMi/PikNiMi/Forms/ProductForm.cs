using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Caching.Memory;
using PikNiMi.Enums;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.Models;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Service;
using PikNiMi.Repository.MemoryCache;
using PikNiMi.Repository.SqlLite;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class ProductForm : Form
    {
        private readonly ProductFormTypeEnum _productFormType;
        private TextBoxResizeFormTypeEnum _textBoxResizeFormType;

        private readonly FullProductInfoModel _productInfo;
        private readonly AdditionalInfoForNewProductOperationModel _additionalInfoForNewProduct;

        private readonly LanguageTranslator _languageTranslator;
        private readonly RepositoryQueryCalls _repositoryQueryCalls;
        private readonly NumberService _numberService;
        private readonly MessageBoxService _messageBoxService;
        private readonly MemoryCacheControl _memoryCacheControl;
        private readonly Calculator _calculator;

        private readonly ComboBoxService _comboBoxService;

        public ProductForm(ProductFormTypeEnum productFormType, FullProductInfoModel productInfo = null, AdditionalInfoForNewProductOperationModel additionalInfoForNewProduct = null)
        {
            _productFormType = productFormType;
            _productInfo = productInfo;
            _additionalInfoForNewProduct = additionalInfoForNewProduct;

            InitializeComponent();

            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
            _numberService = new NumberService(new InvariantCultureNumberService());
            _messageBoxService = new MessageBoxService(_languageTranslator);
            _memoryCacheControl = new MemoryCacheControl(new MemoryCache(new MemoryCacheOptions()));
            _calculator = new Calculator(new InvariantCultureCalculatorService());

            _comboBoxService = new ComboBoxService(_languageTranslator);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            TableLayoutPanel.Font = FormFontConstants.DefaultFontSize;

            SetTextBoxLength();
            SetLanguageText();
            PassedAdditionalValuesForNewProductOperation();
            PopulateComboBoxInfo();
            FillTextBoxInfoIfUpdateOperation();
            SetTextBoxColorByFormOperationForLoad();
            this.ActiveControl = ProductDescriptionTextBox;
        }

        private void ProductForm_Resize(object sender, EventArgs e)
        {
            TableLayoutPanel.Font = WindowState == FormWindowState.Maximized ? FormFontConstants.MaximizedFontSize : FormFontConstants.DefaultFontSize;
        }

        private void ProductDescriptionTextBoxResizeButton_Click(object sender, EventArgs e)
        {
            _textBoxResizeFormType = TextBoxResizeFormTypeEnum.ProductDescription;
            OpenNewForm(new TextBoxResizeForm(_textBoxResizeFormType, ProductDescriptionTextBox.Text, _memoryCacheControl));
        }

        private void AnotherForm_Closed(object sender, EventArgs e)
        {
            this.Show();
            SetTextToSpecificTextBoxAfterTextBoxResizeFormClosed(_textBoxResizeFormType);
        }

        private void CalculateBySoldPriceWithPvmButton_Click(object sender, EventArgs e)
        {
            StartAllCalculationsForSoldPriceWithPvmOption();
        }

        private void CalculateBySoldPriceButton_Click(object sender, EventArgs e)
        {
            StartAllCalculationsForSoldPriceOption();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            StartAllCalculationsForWantProfitOption();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveOrUpdateRecord();
        }

        private void TextBoxControl_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            textBox.SelectionStart = textBox.Text.Length;
            int indexOfTextBox = textBox.TabIndex;
            SetColorOfInfoLabelBySpecificTextBox(true, indexOfTextBox);
        }

        private void TextBoxControl_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            int indexOfTextBox = textBox.TabIndex;
            SetColorOfInfoLabelBySpecificTextBox(false, indexOfTextBox);
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
            CalculateButton.Text = _languageTranslator.SetCalculateButtonText();
            CalculateBySoldPriceButton.Text = _languageTranslator.SetCalculateButtonText();
            CalculateBySoldPriceWithPvmButton.Text = _languageTranslator.SetCalculateButtonText();

            CalculateByWantProfitInfoLabel.Text = _languageTranslator.SetCalculateByWantProfitText();
            CalculateBySoldPriceInfoLabel.Text = _languageTranslator.SetCalculateBySoldPriceText();
            CalculateBySoldPriceWithPvmInfoLabel.Text = _languageTranslator.SetCalculateBySoldPriceWithPvm();
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

        private string SetProductTypeTextForSavingInDataBase()
        {
            string newText;

            string defaultProductTypeValue = _languageTranslator.SetProductTypeComboBoxDefaultText();

            if (defaultProductTypeValue == ProductTypeComboBox.Text)
            {
                newText = _languageTranslator.SetNotChooseText();
            }
            else
            {
                newText = ProductTypeComboBox.Text;
            }

            return newText;
        }

        private FullProductInfoModel GetInfoFromTextBoxForFullProductInfo()
        {
            bool isProductIdTextBoxHasValue = ProductIdTextBox.Text != string.Empty;

            FullProductInfoModel fullProductInfo = new FullProductInfoModel()
            {
                ProductReceiptDate = ProductReceiptDateTextBox.Text,
                ProductType = SetProductTypeTextForSavingInDataBase(),
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

            if (isProductIdTextBoxHasValue)
            {
                fullProductInfo.ProductId = int.Parse(ProductIdTextBox.Text);
            }

            return fullProductInfo;
        }

        private string[] GetAllInfoForSearchInDataBase()
        {
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

            return search;
        }

        private void ShowSaveNewOperationMessage(bool isCompleted)
        {
            if (isCompleted)
            {
                _messageBoxService.ShowSaveNewRecordSuccessMessage();
            }
            else
            {
                _messageBoxService.ShowSaveNewRecordErrorMessage();
            }
        }

        private void SaveOrUpdateRecord()
        {
            var fullProductInfo = GetInfoFromTextBoxForFullProductInfo();
            var search = GetAllInfoForSearchInDataBase();
            SetButtonControl(false);

            switch (_productFormType)
            {
                case ProductFormTypeEnum.NewProductForm:
                    Task<int> taskAddNew = _repositoryQueryCalls.CreateNewFullProductInfo(fullProductInfo, search);
                    ShowSaveNewOperationMessage(taskAddNew.IsCompleted);
                    break;
                case ProductFormTypeEnum.UpdateProductForm:
                    var taskUpdate = _repositoryQueryCalls.UpdateExistingFullProductInfo(fullProductInfo, search);
                    ShowSaveNewOperationMessage(taskUpdate.IsCompleted);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SetButtonControl(true);
        }

        private void SetTextToSpecificTextBoxAfterTextBoxResizeFormClosed(TextBoxResizeFormTypeEnum textBoxResizeFormType)
        {
            switch (textBoxResizeFormType)
            {
                case TextBoxResizeFormTypeEnum.ProductDescription:
                    ProductDescriptionTextBox.Text = _memoryCacheControl.GetExistingStringDataFromCache("TextBoxResize");
                    break;
                default: 
                    throw new ArgumentOutOfRangeException();
            }

            _memoryCacheControl.DeleteExistingCache("TextBoxResize");
        }

        private void FillTextBoxInfoIfUpdateOperation()
        {
            if (_productFormType == ProductFormTypeEnum.UpdateProductForm)
            {
                ProductIdTextBox.Text = _productInfo.ProductId.ToString();
                ProductReceiptDateTextBox.Text = _productInfo.ProductReceiptDate;
                ProductTypeComboBox.Text = SetProductTypeComboBoxTextForUpdateOperation();
                ProductDescriptionTextBox.Text = _productInfo.ProductDescription;
                ProductColorTextBox.Text = _productInfo.ProductColor;
                ProductSizeTextBox.Text = _productInfo.ProductSize;
                ProductCareTextBox.Text = _productInfo.ProductCare;
                ProductMadeStuffTextBox.Text = _productInfo.ProductMadeStuff;
                ProductMadeInTextBox.Text = _productInfo.ProductMadeIn;

                ProductQuantityTextBox.Text = _productInfo.ProductQuantity.ToString();
                ProductQuantityLeftTextBox.Text = _productInfo.ProductQuantityLeft.ToString();

                ProductOriginalUnitPriceAtOriginalCurrencyTextBox.Text =
                    _numberService.ParseDoubleToString(_productInfo.ProductOriginalUnitPriceAtOriginalCurrency);
                ProductQuantityPriceAtOriginalCurrencyTextBox.Text =
                    _numberService.ParseDoubleToString(_productInfo.ProductQuantityPriceAtOriginalCurrency);

                ProductUnitPriceInEuroTextBox.Text =
                    _numberService.ParseDoubleToString(_productInfo.ProductUnitPriceInEuro);
                ProductQuantityPriceInEuroTextBox.Text =
                    _numberService.ParseDoubleToString(_productInfo.ProductQuantityPriceInEuro);
                TripExpensesTextBox.Text = _numberService.ParseDoubleToString(_productInfo.TripExpenses);
                ProductExpensesCostPriceTextBox.Text =
                    _numberService.ParseDoubleToString(_productInfo.ProductExpensesCostPrice);
                ProductSoldPriceTextBox.Text = _numberService.ParseDoubleToString(_productInfo.ProductSoldPrice);
                ProductPvmTextBox.Text = _numberService.ParseDoubleToString(_productInfo.ProductPvm);
                ProductSoldPriceWithPvmTextBox.Text =
                    _numberService.ParseDoubleToString(_productInfo.ProductSoldPriceWithPvm);
                ProductSoldTextBox.Text = _productInfo.ProductSold.ToString();
                ProductProfitTextBox.Text = _numberService.ParseDoubleToString(_productInfo.ProductProfit);
                DiscountTextBox.Text = _numberService.ParseDoubleToString(_productInfo.Discount);

                var taskAdditionalInfo = _repositoryQueryCalls.GetAdditionalProductInfoById(_productInfo.ProductId);
                var additionalInfo = taskAdditionalInfo.Result;

                if (additionalInfo != null)
                {
                    MoneyCourseTextBox.Text = _numberService.ParseDoubleToString(additionalInfo.MoneyCourse);
                    ProductWantProfitTextBox.Text = _numberService.ParseDoubleToString(additionalInfo.ProfitWant);
                }
            }
        }

        private string SetProductTypeComboBoxTextForUpdateOperation()
        {
            string productType;

            if (!ProductTypeComboBox.Items.Contains(_productInfo.ProductType))
            {
                productType = _languageTranslator.SetProductTypeComboBoxDefaultText();
            }
            else
            {
                productType = _productInfo.ProductType;
            }

            return productType;
        }

        private static void SetSpecificTextBoxColorForEmptyText(TextBox textBox, Color color)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = color;
            }
        }

        private void SetTextBoxColorByFormOperationForLoad()
        {
            switch (_productFormType)
            {
                case ProductFormTypeEnum.NewProductForm:
                    break;
                case ProductFormTypeEnum.UpdateProductForm:
                    SetSpecificTextBoxColorForEmptyText(ProductQuantityTextBox, Color.Yellow);
                    SetSpecificTextBoxColorForEmptyText(ProductOriginalUnitPriceAtOriginalCurrencyTextBox,Color.Yellow);
                    SetSpecificTextBoxColorForEmptyText(MoneyCourseTextBox, Color.Yellow);
                    SetSpecificTextBoxColorForEmptyText(ProductWantProfitTextBox, Color.Yellow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PassedAdditionalValuesForNewProductOperation()
        {
            if (_additionalInfoForNewProduct != null)
            {
                ProductReceiptDateTextBox.Text = _additionalInfoForNewProduct.Date;
                MoneyCourseTextBox.Text = _additionalInfoForNewProduct.MoneyCourse;
            }
        }

        private void SetColorOfInfoLabelBySpecificTextBox(bool isEntered, int indexOfTextBox)
        {
            switch (indexOfTextBox)
            {
                case 23:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductReceiptDateInfoLabel, isEntered);
                    break;
                case 24:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductDescriptionInfoLabel, isEntered);
                    break;
                case 25:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductColorInfoLabel, isEntered);
                    break;
                case 26:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductSizeInfoLabel, isEntered);
                    break;
                case 27:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductCareInfoLabel, isEntered);
                    break;
                case 28:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductMadeStuffInfoLabel, isEntered);
                    break;
                case 29:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductMadeInInfoLabel, isEntered);
                    break;
                case 30:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductQuantityInfoLabel, isEntered);
                    break;
                case 31:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductQuantityLeftInfoLabel, isEntered);
                    break;
                case 32:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductOriginalUnitPriceAtOriginalCurrencyInfoLabel, isEntered);
                    break;
                case 33:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductQuantityPriceAtOriginalCurrencyInfoLabel, isEntered);
                    break;
                case 34:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductUnitPriceInEuroInfoLabel, isEntered);
                    break;
                case 35:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductQuantityPriceInEuroInfoLabel, isEntered);
                    break;
                case 36:
                    SetInfoLabelColorByEnterORLeaveTextBox(TripExpensesInfoLabel, isEntered);
                    break;
                case 37:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductExpensesCostPriceInfoLabel, isEntered);
                    break;
                case 38:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductSoldPriceInfoLabel, isEntered);
                    break;
                case 39:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductPvmInfoLabel, isEntered);
                    break;
                case 40:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductSoldPriceWithPvmInfoLabel, isEntered);
                    break;
                case 41:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductSoldInfoLabel, isEntered);
                    break;
                case 42:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductProfitInfoLabel, isEntered);
                    break;
                case 63:
                    SetInfoLabelColorByEnterORLeaveTextBox(ProductWantProfitInfoLabel, isEntered);
                    break;
                case 65:
                    SetInfoLabelColorByEnterORLeaveTextBox(DiscountInfoLabel, isEntered);
                    break;
                case 70:
                    SetInfoLabelColorByEnterORLeaveTextBox(MoneyCourseInfoLabel, isEntered);
                    break;
            }
            
        }

        private void SetInfoLabelColorByEnterORLeaveTextBox(Label label, bool isEntered)
        {
            if (isEntered)
            {
                label.ForeColor = Color.Green;
            }
            else
            {
                label.ForeColor = default;
            }
        }

        private void StartMainCalculations()
        {
            ProductQuantityPriceAtOriginalCurrencyTextBox.Text = _calculator.CountQuantityPrice(
                quantity: ProductQuantityTextBox.Text, ProductOriginalUnitPriceAtOriginalCurrencyTextBox.Text);
            ProductUnitPriceInEuroTextBox.Text = _calculator.ConvertUnitPriceToEuroCurrency(
                moneyCourse: MoneyCourseTextBox.Text, ProductOriginalUnitPriceAtOriginalCurrencyTextBox.Text);
            ProductQuantityPriceInEuroTextBox.Text =
                _calculator.CountQuantityPrice(quantity: ProductQuantityTextBox.Text,
                    ProductUnitPriceInEuroTextBox.Text);
            ProductExpensesCostPriceTextBox.Text =
                _calculator.CountProductExpenses(productPriceInEuro: ProductUnitPriceInEuroTextBox.Text,
                    TripExpensesTextBox.Text);
        }

        private void StartAllCalculationsForWantProfitOption()
        {
            StartMainCalculations();

            ProductSoldPriceTextBox.Text = _calculator.CountSoldPriceWithoutPvm(
                productWantProfit: ProductWantProfitTextBox.Text, ProductExpensesCostPriceTextBox.Text);
            ProductPvmTextBox.Text = _calculator.CountJustPvm(ProductSoldPriceTextBox.Text);
            ProductSoldPriceWithPvmTextBox.Text = _calculator.CountSoldPriceWithPvm(
                productWantProfit: ProductWantProfitTextBox.Text, ProductExpensesCostPriceTextBox.Text);
        }

        private void StartAllCalculationsForSoldPriceOption()
        {
            StartMainCalculations();

            ProductWantProfitTextBox.Text =
                _calculator.CalculateWantProfitBySoldPriceWithoutPvm(productSoldPrice: ProductSoldPriceTextBox.Text,
                    ProductExpensesCostPriceTextBox.Text);
            ProductPvmTextBox.Text = _calculator.CountJustPvm(ProductSoldPriceTextBox.Text);
            ProductSoldPriceWithPvmTextBox.Text = _calculator.CountSoldPriceWithPvm(
                productWantProfit: ProductWantProfitTextBox.Text, ProductExpensesCostPriceTextBox.Text);
        }

        private void StartAllCalculationsForSoldPriceWithPvmOption()
        {
            StartMainCalculations();

            ProductWantProfitTextBox.Text = _calculator.CalculateWantProfitBySoldPriceWithPvm(
                productSoldPriceWithPvm: ProductSoldPriceWithPvmTextBox.Text, ProductExpensesCostPriceTextBox.Text);
            ProductSoldPriceTextBox.Text =
                _calculator.CountSoldPriceWithoutPvm(productWantProfit: ProductWantProfitTextBox.Text,
                    ProductExpensesCostPriceTextBox.Text);
            ProductPvmTextBox.Text = _calculator.CountJustPvm(ProductSoldPriceTextBox.Text);
        }

        #endregion
    }
}
