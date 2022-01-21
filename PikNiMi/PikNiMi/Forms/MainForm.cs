using System;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;

namespace PikNiMi.Forms
{
    public partial class MainForm : Form
    {
        private readonly TextBoxFormService _textBoxFormService;
        public MainForm()
        {
            InitializeComponent();
            _textBoxFormService = new TextBoxFormService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetTextBoxLength();
            SetDefaultTextBoxesTextValue();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            //button logic in future
        }

        private void searchTextBox_GotFocus(object sender, EventArgs e)
        {
            string searchTextBoxText = _textBoxFormService.DisableTextBoxText(searchTextBox.Text, FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder);
            searchTextBox.Text = searchTextBoxText;
        }

        private void searchTextBox_LostFocus(object sender, EventArgs e)
        {
           string searchTextBoxText = _textBoxFormService.SetTextBoxTextForEmptyOrWhiteSpaceText(searchTextBox.Text, FormTextBoxDefaultTexts.SearchTextBoxPlaceHolder);
           searchTextBox.Text = searchTextBoxText;
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

        #endregion
        
    }
}
