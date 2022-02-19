using System;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class ProductForm : Form
    {
        private readonly LanguageTranslator _languageTranslator;
        public ProductForm()
        {
            InitializeComponent();

            _languageTranslator = new LanguageTranslator( new TextTranslationsToLithuaniaLanguage());
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            TableLayoutPanel.Font = FormFontConstants.DefaultFontSize;
            SetLanguage();
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

        private void SetLanguage()
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

            ProductDescriptionTextBoxResizeButton.Text = _languageTranslator.SetTextBoxResizeButtonText();
            // set all other button text 
        }

        #endregion
    }
}
