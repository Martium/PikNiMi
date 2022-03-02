using System;
using System.Linq;
using System.Windows.Forms;
using PikNiMi.Enums;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.Models;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Service;
using PikNiMi.Repository.SqlLite;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class MainForm : Form
    {
        private readonly LanguageTranslator _languageTranslator;

        private readonly TextBoxFormService _textBoxFormService;
        private readonly ComboBoxService _comboBoxService;
        private readonly ProductDataGridViewService _productDataGridViewService;

        private readonly Calculator _calculator;
        private readonly RepositoryQueryCalls _repositoryQueryCalls;
        private readonly MessageBoxService _messageBoxService;

        public MainForm()
        {
            InitializeComponent();

            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
            _textBoxFormService = new TextBoxFormService();
            _comboBoxService = new ComboBoxService(_languageTranslator);
            _productDataGridViewService = new ProductDataGridViewService();
            _calculator = new Calculator(new InvariantCultureCalculatorService());
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
            _messageBoxService =
                new MessageBoxService(new LanguageTranslator(new TextTranslationsToLithuaniaLanguage()));

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
            if (IsDateAndMoneyCourseTextBoxFilled())
            {
                var additionalInfoForNewProduct = new AdditionalInfoForNewProductOperationModel()
                {
                    Date = DateTextBox.Text,
                    MoneyCourse = MoneyCourseTextBox.Text
                };

                OpenNewForm(new ProductForm(ProductFormTypeEnum.NewProductForm, additionalInfoForNewProduct: additionalInfoForNewProduct));
            }
            else
            {
                //message box  please enter value to red text box 
            }
        }

        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            if (ProductDataGridView.SelectedRows.Count == 1)
            {
                var allFullProductInfo = _productDataGridViewService.GetAllInfoFromSelectedRow(ProductDataGridView);
                OpenNewForm(new ProductForm(ProductFormTypeEnum.UpdateProductForm, allFullProductInfo));
            }
            else
            {
                // message box select something 
            }
           
        }

        private async void AnotherForm_Closed(object sender, EventArgs e)
        {
            this.Show();
            SetDefaultTextBoxesTextValue();
            SetAllButtonsControl(false);
            await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView, _languageTranslator);
            SetAllButtonsControl(true);
        }

        private async void CountFullOrderDiscountButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (LoadingForm loadingForm  = new LoadingForm(SetTripExpensesByDate))
            {
                loadingForm.ShowDialog(this);
            }

            await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView, _languageTranslator);
            this.Show();
        }

        #region CustomPrivateMethods

        private void SetTextBoxLength()
        {
            SearchTextBox.MaxLength = TextBoxLength.ProductSearchText;
            DateTextBox.MaxLength = TextBoxLength.ProductDate;
            TripExpensesTextBox.MaxLength = TextBoxLength.NumberLength;
            MoneyCourseTextBox.MaxLength = TextBoxLength.NumberLength;
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
            MoneyCourseInfoLabel.Text = _languageTranslator.SetMoneyCourseText();
        }

        private bool IsDateAndMoneyCourseTextBoxFilled()
        {
            bool isNotEmpty = !string.IsNullOrWhiteSpace(DateTextBox.Text) &&
                              !string.IsNullOrWhiteSpace(MoneyCourseTextBox.Text);
            return isNotEmpty;
        }

        private void SetTripExpensesByDate()
        {
            var taskToGetIdByDate = _repositoryQueryCalls.GetAllFullProductinfoIdByDate(DateTextBox.Text);
            var resultOfIEnumerable = taskToGetIdByDate.Result;

            var ofIEnumerable = resultOfIEnumerable as int[] ?? resultOfIEnumerable.ToArray();
            if (ofIEnumerable.Count() != 0)
            {
                double tripExpenses =
                    _calculator.CalculateTripExpensesByDate(ofIEnumerable.Count(), TripExpensesTextBox.Text);

                var taskOfUpdate =
                    _repositoryQueryCalls.UpdateAllTripExpensesRowsByDate(DateTextBox.Text, tripExpenses);
                ShowSaveToDataBaseMessage(taskOfUpdate.IsCompleted);
            }
            else
            {
                _messageBoxService.ShowRecordNotFoundByDateErrorMessage();
            }
        }

        private void ShowSaveToDataBaseMessage(bool isSuccess)
        {
            if (isSuccess)
            {
                _messageBoxService.ShowSaveNewRecordSuccessMessage();
            }
            else
            {
                _messageBoxService.ShowSaveNewRecordErrorMessage();
            }
        }

        #endregion
    }
}
