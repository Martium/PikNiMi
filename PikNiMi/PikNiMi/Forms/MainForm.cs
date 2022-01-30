using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.Models;

namespace PikNiMi.Forms
{
    public partial class MainForm : Form
    {
        private readonly TextBoxFormService _textBoxFormService;
        private readonly ProductTypeComboBoxService _productTypeService;
        private readonly ProductDataGridViewService _productDataGridViewService;
        private List<FullProductInfoModel> _lastProductsInfo;


        public MainForm()
        {
            InitializeComponent();

            _textBoxFormService = new TextBoxFormService();
            _productTypeService = new ProductTypeComboBoxService();
            _productDataGridViewService = new ProductDataGridViewService();
            _lastProductsInfo = new List<FullProductInfoModel>();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = @"PikNiMi Sandėlis";
            SetTextBoxLength();
            SetDefaultTextBoxesTextValue();
            _productTypeService.SetProductTypeCustomValues(ProductTypeComboBox);
            SetAllButtonsControl(false);
             await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView);
            SetAllButtonsControl(true);
        }

        private async void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SetAllButtonsControl(false);
                await _productDataGridViewService.LoadFullProductInfoBySearchPhrase(ProductDataGridView, SearchTextBox.Text);
                SetAllButtonsControl(true);
            }
        }

        private void SearchTextBox_GotFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenGotFocus(FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder, SearchTextBox);
        }

        private void SearchTextBox_LostFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenLostFocus(FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder, SearchTextBox);
        }

        private void TripExpensesTextBox_GotFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenGotFocus(FormTextBoxDefaultTexts.TripExpensesTextBoxPlaceHolder, TripExpensesTextBox);
        }

        private void TripExpensesTextBox_LostFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenLostFocus(FormTextBoxDefaultTexts.TripExpensesTextBoxPlaceHolder, TripExpensesTextBox);
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            if (ProductTypeComboBox.Text == FormTextBoxDefaultTexts.ProductTypeComboBoxDefaultText)
            {
                //message box pasirinkite produkto tipą
            }
            else if (SearchTextBox.Text == FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder)
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
            await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView);
            SearchTextBox.Text = FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder;
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
            OpenFormOrClosed(new ProductForm());
        }

        private async void AnotherForm_Closed(object sender, EventArgs e)
        {
            this.Show();
            SetDefaultTextBoxesTextValue();
            SetAllButtonsControl(false);
            await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView);
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
            SearchTextBox.Text = FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder;
            DateTextBox.Text = FormTextBoxDefaultTexts.DateToday;
            TripExpensesTextBox.Text = FormTextBoxDefaultTexts.TripExpensesTextBoxPlaceHolder;
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

        private void OpenFormOrClosed(Form form)
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





        #endregion

    }
}
