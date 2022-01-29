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
        private List<FullProductInfoModel> _fullProductInfo;


        public MainForm()
        {
            InitializeComponent();

            _textBoxFormService = new TextBoxFormService();
            _productTypeService = new ProductTypeComboBoxService();
            _productDataGridViewService = new ProductDataGridViewService();
            _fullProductInfo = new List<FullProductInfoModel>();
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
            FillLastLoadInfoToList();
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

        private void FillLastLoadInfoToList()
        {
            int rowCount = ProductDataGridView.Rows.Count;

            for (int i = 0; i < rowCount; i++)
            {
                FullProductInfoModel productInfoModel = new FullProductInfoModel()
                {
                    ProductId = int.Parse(ProductDataGridView.Rows[i].Cells[0].Value.ToString()),
                    ProductReceiptDate = ProductDataGridView.Rows[i].Cells[1].Value.ToString(),
                    ProductType = ProductDataGridView.Rows[i].Cells[2].Value.ToString(),

                    ProductDescription = ProductDataGridView.Rows[i].Cells[3].Value.ToString(),
                    ProductColor = ProductDataGridView.Rows[i].Cells[4].Value.ToString(),
                    ProductSize = ProductDataGridView.Rows[i].Cells[5].Value.ToString(),
                    ProductCare = ProductDataGridView.Rows[i].Cells[6].Value.ToString(),
                    ProductMadeStuff = ProductDataGridView.Rows[i].Cells[7].Value.ToString(),
                    ProductBuyLocation = ProductDataGridView.Rows[i].Cells[8].Value.ToString()


                };

                _fullProductInfo.Add(productInfoModel);
            }

        }

        #endregion
       
    }
}
