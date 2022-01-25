using System;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;

namespace PikNiMi.Forms
{
    public partial class MainForm : Form
    {
        private readonly TextBoxFormService _textBoxFormService;
        private readonly ProductTypeComboBoxService _productTypeService;
        private readonly ProductDataGridViewService _productDataGridViewService;

        public MainForm()
        {
            InitializeComponent();

            _textBoxFormService = new TextBoxFormService();
            _productTypeService = new ProductTypeComboBoxService();
            _productDataGridViewService = new ProductDataGridViewService();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = @"PikNiMi Sandėlis";
            SetTextBoxLength();
            SetDefaultTextBoxesTextValue();
            _productTypeService.SetProductTypeCustomValues(ProductTypeComboBox);
            SetAllButtonsControl(false);
             await _productDataGridViewService.LoadFullProductInfo(productDataGridView);
            SetAllButtonsControl(true);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

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

        private void SearchButton_Click(object sender, EventArgs e)
        {
          
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

        #endregion
    }
}
