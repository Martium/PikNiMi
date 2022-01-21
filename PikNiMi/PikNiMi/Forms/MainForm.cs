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

        public MainForm()
        {
            InitializeComponent();

            _textBoxFormService = new TextBoxFormService();
            _productTypeService = new ProductTypeComboBoxService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = @"PikNiMi Sandėlis";
            SetTextBoxLength();
            SetDefaultTextBoxesTextValue();
            _productTypeService.SetProductTypeCustomValues(productTypeComboBox);
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchTextBox_GotFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenGotFocus(FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder, searchTextBox);
        }

        private void searchTextBox_LostFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenLostFocus(FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder, searchTextBox);
        }

        private void tripExpensesTextBox_GotFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenGotFocus(FormTextBoxDefaultTexts.TripExpensesTextBoxPlaceHolder, tripExpensesTextBox);
        }

        private void tripExpensesTextBox_LostFocus(object sender, EventArgs e)
        {
            SetSpecificTextToTextBoxWhenLostFocus(FormTextBoxDefaultTexts.TripExpensesTextBoxPlaceHolder, tripExpensesTextBox);
        }

        #region CustomPrivateMethods

        private void SetTextBoxLength()
        {
            searchTextBox.MaxLength = TextBoxLength.ProductSearchText;
            dateTextBox.MaxLength = TextBoxLength.ProductDate;
            tripExpensesTextBox.MaxLength = TextBoxLength.NumberLength;
        }

        private void SetDefaultTextBoxesTextValue()
        {
            searchTextBox.Text = FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder;
            dateTextBox.Text = FormTextBoxDefaultTexts.DateToday;
            tripExpensesTextBox.Text = FormTextBoxDefaultTexts.TripExpensesTextBoxPlaceHolder;
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

        #endregion


       
    }
}
