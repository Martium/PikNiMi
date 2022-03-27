using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
            DateTextBox.Text = FormTextBoxDefaultTexts.DateToday;
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
                var additionalInfoForNewProduct = new AdditionalInfoForNewProductOperationModel()
                {
                    Date = DateTextBox.Text,
                    MoneyCourse = "1"
                };

                OpenNewForm(new ProductForm(ProductFormTypeEnum.NewProductForm, additionalInfoForNewProduct: additionalInfoForNewProduct));
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
                _messageBoxService.ShowSelectRowErrorMessage();
            }
           
        }

        private async void AnotherForm_Closed(object sender, EventArgs e)
        {
            this.Show();
            SetDefaultTextBoxesTextValue();
            SetAllButtonsControl(false);
            _comboBoxService.SetProductTypeCustomValues(ProductTypeComboBox);
            await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView, _languageTranslator);
            SetAllButtonsControl(true);
        }

        private async void CountFullOrderDiscountButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SetAllButtonsControl(false);

            using (LoadingForm loadingForm  = new LoadingForm(SetTripExpensesByDate))
            {
                loadingForm.ShowDialog(this);
            }

            await _productDataGridViewService.LoadFullProductInfo(ProductDataGridView, _languageTranslator);
            SetAllButtonsControl(true);
            this.Show();
        }

        private void DateTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DateTextBox.Text))
            {
                SetAllButtonsControl(false);
                e.Cancel = true;
                DateTextBox.BackColor = Color.Red;
            }
            else if (!DateTime.TryParseExact(DateTextBox.Text, FormTextBoxDefaultTexts.DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out _))
            {
                SetAllButtonsControl(false);
                e.Cancel = true;
                DateTextBox.BackColor = Color.Red;
            }
            else
            {
                SetAllButtonsControl(true);
                e.Cancel = false;
                DateTextBox.BackColor = default;
            }
        }

        private void AddNewProductTypeButton_Click(object sender, EventArgs e)
        {
            OpenNewForm(new ProductTypeForm());
        }

        private void AdditionalOptionButton_Click(object sender, EventArgs e)
        { 
            OpenNewForm(new AdditionalOptionForm()); // todo lot of logic mistakes
           // MessageBox.Show(@"Paslauga nesuprogamuota :( ");
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

            HistoryButton.Enabled = isAllowed;
            AddNewProductTypeButton.Enabled = isAllowed;
            CountFullOrderDiscountButton.Enabled = isAllowed;
            AdditionalOptionButton.Enabled = isAllowed;
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
            HistoryButton.Text = _languageTranslator.SetHistoryButtonText();
            AddNewProductTypeButton.Text = _languageTranslator.SetProductTypeInfoLabelText();
            CountFullOrderDiscountButton.Text = _languageTranslator.SetCountFullOrderCalculationButtonText();
            MoneyCourseInfoLabel.Text = _languageTranslator.SetMoneyCourseText();

            AdditionalOptionButton.Text = _languageTranslator.SetAdditionalOption();
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
            var resultOfQuantity = taskToGetIdByDate.Result.ToList();

            int allQuantity = resultOfQuantity.Sum(q => q.ProductQuantity);

            if (allQuantity != 0)
            {
                double tripExpenses =
                    _calculator.CalculateTripExpensesByDate(allQuantity, TripExpensesTextBox.Text);

                var taskOfUpdate =
                    _repositoryQueryCalls.UpdateAllTripExpensesRowsByDate(DateTextBox.Text, tripExpenses);
                StartFinalCalculationByDate(!taskOfUpdate.IsFaulted);
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

        private void StartFinalCalculationByDate(bool isTripExpensesCalculated)
        {
            if (!isTripExpensesCalculated)
            {
                _messageBoxService.ShowSaveNewRecordErrorMessage();
                return;
            }

            var taskMainCalculationInfo = _repositoryQueryCalls.GetAllInfoForCalculationFullProductInfo(DateTextBox.Text);
            var resultMainCalculationInfo = taskMainCalculationInfo.Result;
            bool isAllRecordsSave = true;

            if (resultMainCalculationInfo != null)
            {
                List<FullProductInfoMainInfoForCalculationsStartModel> mainInfoForCalculations =
                    resultMainCalculationInfo.ToList();

                var calculations = ReturnCalculationsList(mainInfoForCalculations);

                foreach (var record in calculations)
                {
                    var taskFullProductinfoCalculationsUpdate =
                        _repositoryQueryCalls.UpdateFullProductInfoByDateQuickCalculation(record);

                    var taskUpdateProfitWant =
                        _repositoryQueryCalls.UpdateProfitWantByDateQuickCalculation(profitWant: record.ProfitWant,
                            record.ProductId);

                    if (taskFullProductinfoCalculationsUpdate.IsFaulted && taskUpdateProfitWant.IsFaulted)
                    {
                        isAllRecordsSave = false;
                    }
                }

                ShowSaveToDataBaseMessage(isAllRecordsSave);
            }
        }

        private List<FullProductInfoCalculationModel> ReturnCalculationsList(
            List<FullProductInfoMainInfoForCalculationsStartModel> mainInfoForCalculations)
        {
            List<FullProductInfoCalculationModel> calculationList = new List<FullProductInfoCalculationModel>();

            foreach (var calculation in mainInfoForCalculations)
            {
                var taskAdditionalInfo = _repositoryQueryCalls.GetAdditionalProductInfoById(calculation.ProductId);
                var additionalInfoResult = taskAdditionalInfo.Result;

                var singleRecordInfoForCalculation = new FullProductInfoMainInfoForCalculationsStartModel()
                {
                    ProfitWant = additionalInfoResult.ProfitWant,
                    MoneyCourse = additionalInfoResult.MoneyCourse,
                    IncludePvm = additionalInfoResult.IncludePvm,
                    CountByWantProfit = additionalInfoResult.CountByWantProfit,

                    ProductId = calculation.ProductId,
                    ProductQuantity = calculation.ProductQuantity,
                    ProductOriginalUnitPriceAtOriginalCurrency = calculation.ProductOriginalUnitPriceAtOriginalCurrency,
                    TripExpenses = calculation.TripExpenses,
                    ProductExpensesCostPrice = calculation.ProductExpensesCostPrice,
                    ProductSoldPrice = calculation.ProductSoldPrice,
                    ProductSoldPriceWithPvm = calculation.ProductSoldPriceWithPvm,
                    ProductSold = calculation.ProductSold,
                    Discount = calculation.Discount,
                    Search = calculation.Search
                };

                calculationList.Add(_calculator.MakeFullCalculationsOfSpecificProduct(singleRecordInfoForCalculation));
            }

            return calculationList;
        }


        #endregion

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Paslauga nesuprogamuota :( ");
        }
        
    }
}
