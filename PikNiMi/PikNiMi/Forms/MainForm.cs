using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PikNiMi.Enums;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.Models;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class MainForm : Form
    {
        private readonly LanguageTranslator _languageTranslator;

        private readonly TextBoxFormService _textBoxFormService;
        private readonly ComboBoxService _comboBoxService;
        private readonly ProductDataGridViewService _productDataGridViewService;


        private List<FullProductInfoModel> _lastProductsInfo;

        public MainForm()
        {
            InitializeComponent();

            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
            _textBoxFormService = new TextBoxFormService();
            _comboBoxService = new ComboBoxService(_languageTranslator);
            _productDataGridViewService = new ProductDataGridViewService();

            _lastProductsInfo = new List<FullProductInfoModel>();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            SetLanguageText();
            SetTextBoxLength();
            SetDefaultTextBoxesTextValue();
            _comboBoxService.SetProductTypeCustomValues(ProductTypeComboBox);
            SetAllButtonsControl(false);
             await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView, _languageTranslator);
            SetAllButtonsControl(true);
            SetDataGridViewConstantControl();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                tableUpperLayoutPanel.Font = FormFontConstants.MaximizedFontSize;
                tableBottomLayoutPanel.Font = FormFontConstants.MaximizedFontSize;

                _productDataGridViewService.SetAutoFontSizeColumnsAndRows(ProductDataGridView, true);
            }
            else
            {
                tableUpperLayoutPanel.Font = FormFontConstants.DefaultFontSize;
                tableBottomLayoutPanel.Font = FormFontConstants.DefaultFontSize;

                _productDataGridViewService.SetAutoFontSizeColumnsAndRows(ProductDataGridView, false);
            }
        }

        private async void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text) && SearchTextBox.Text != _languageTranslator.SetSearchTextBoxPlaceHolder())
            {
                SetAllButtonsControl(false);
                await _productDataGridViewService.LoadFullProductInfoBySearchPhrase(ProductDataGridView, SearchTextBox.Text);
                SetAllButtonsControl(true);
            }
        }

        private void SearchTextBox_GotFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenGotFocus(_languageTranslator.SetSearchTextBoxPlaceHolder(), SearchTextBox);
        }

        private void SearchTextBox_LostFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenLostFocus(_languageTranslator.SetSearchTextBoxPlaceHolder(), SearchTextBox);
        }

        private void TripExpensesTextBox_GotFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenGotFocus(_languageTranslator.SetTripExpensesTextBoxPlaceHolder(), TripExpensesTextBox);
        }

        private void TripExpensesTextBox_LostFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenLostFocus(_languageTranslator.SetTripExpensesTextBoxPlaceHolder(), TripExpensesTextBox);
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            if (ProductTypeComboBox.Text == _languageTranslator.SetProductTypeComboBoxDefaultText())
            {
                //message box pasirinkite produkto tipą
            }
            else if (SearchTextBox.Text == _languageTranslator.SetSearchTextBoxPlaceHolder())
            {
                SetAllButtonsControl(false);
                await _productDataGridViewService.LoadFullProductInfoBySelectedProductType(ProductTypeComboBox.Text, ProductDataGridView);
                SetAllButtonsControl(true);
            }
            else
            {
                SetAllButtonsControl(false);
                await _productDataGridViewService.LoadFullProductInfoBySearchPhraseAndProductType(ProductDataGridView,
                    searchPhrase: SearchTextBox.Text, productType: ProductTypeComboBox.Text);
                SetAllButtonsControl(true);
            }
        }

        private async void CancelSearchButton_Click(object sender, EventArgs e)
        {
            SetAllButtonsControl(false);
            SearchTextBox.Text = _languageTranslator.SetSearchTextBoxPlaceHolder();
            await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView, _languageTranslator);
            SetAllButtonsControl(true);
        }

        private void ProductTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchButton_Click(this, new EventArgs());
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(this, new EventArgs());
            }
        }

        private void AddNewProductButton_Click(object sender, EventArgs e)
        {
            OpenNewForm(new ProductForm(ProductFormTypeEnum.NewProductForm));
        }

        private async void AnotherForm_Closed(object sender, EventArgs e)
        {
            this.Show();
            SetDefaultTextBoxesTextValue();
            SetAllButtonsControl(false);
            await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView, _languageTranslator);
            SetAllButtonsControl(true);
        }

        #region CustomPrivateMethods

        private void SetTextBoxLength()
        {
            SearchTextBox.MaxLength = TextBoxLength.ProductSearchText;
            DateTextBox.MaxLength = TextBoxLength.ProductDate;
            TripExpensesTextBox.MaxLength = TextBoxLength.NumberLength;
        }

        private void SetDefaultTextBoxesTextValue()
        {
            SearchTextBox.Text = _languageTranslator.SetSearchTextBoxPlaceHolder();
            DateTextBox.Text = FormTextBoxDefaultTexts.DateToday;
            TripExpensesTextBox.Text = _languageTranslator.SetTripExpensesTextBoxPlaceHolder();
        }

        private void SetSpecificTextToTextBoxWhenGotFocus(string specificText, TextBox textBox)
        {
            string textBoxText = _textBoxFormService.DisableTextBoxText(textBox.Text, specificText);
            textBox.Text = textBoxText;
        }

        private void SetSpecificTextToTextBoxWhenLostFocus(string specificText, TextBox textBox)
        {
            string textBoxText = _textBoxFormService.SetTextBoxTextForEmptyOrWhiteSpaceText(textBox.Text, specificText);
            textBox.Text = textBoxText;
        }

        private void SetAllButtonsControl(bool isAllowed)
        {
            AddNewProductButton.Enabled = isAllowed;
            UpdateProductButton.Enabled = isAllowed;

            SearchButton.Enabled = isAllowed;
            CancelSearchButton.Enabled = isAllowed;

            Historybutton.Enabled = isAllowed;
            AddNewProductTypeButton.Enabled = isAllowed;
            DiscountButton.Enabled = isAllowed;
            CountFullOrderDiscountButton.Enabled = isAllowed;
        }

        private void FillLastLoadInfoToList()
        {
            _lastProductsInfo.Clear();
            _lastProductsInfo = _productDataGridViewService.GetLastLoadInfoFromDataGridView(ProductDataGridView);
        }

        private void LoadLastInfoFromListToProductDataGridView()
        {
            _productDataGridViewService.LoadLastInfo(ProductDataGridView, _lastProductsInfo);
        }

        private void SetDataGridViewConstantControl()
        {
            _productDataGridViewService.SetFullRowSelectMode(ProductDataGridView);
            _productDataGridViewService.SetAutoFontSizeColumnsAndRows(ProductDataGridView, false);
        }

        private void OpenNewForm(Form form)
        {
            form.Closed += AnotherForm_Closed;
            HideListOfProductsFullInfoForm(form);
        }

        private void HideListOfProductsFullInfoForm(Form form)
        {
            this.Hide();
            form.Show();

            if (this.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        private void SetLanguageText()
        {
            this.Text = _languageTranslator.FormHeaderText(MainFormTypeEnum.MainForm);

            AddNewProductButton.Text = _languageTranslator.SetAddNewProductButtonText();
            UpdateProductButton.Text = _languageTranslator.SetUpdateProductButtonText();
            SearchButton.Text = _languageTranslator.SetSearchButtonText();
            CancelSearchButton.Text = _languageTranslator.SetCancelSearchButtonText();
            Historybutton.Text = _languageTranslator.SetHistoryButtonText();
            AddNewProductTypeButton.Text = _languageTranslator.SetAddNewProductTypeButtonText();
            DiscountButton.Text = _languageTranslator.SetDiscountButtonText();
            CountFullOrderDiscountButton.Text = _languageTranslator.SetCountFullOrderDiscountButtonText();
        }

        #endregion
       
    }
}
