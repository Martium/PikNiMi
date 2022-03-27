using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.Models;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Service;
using PikNiMi.Repository.SqlLite;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class AdditionalOptionForm : Form
    {
        private readonly LanguageTranslator _languageTranslator;
        private readonly ComboBoxService _comboBoxService;
        private readonly RepositoryQueryCalls _repositoryQueryCalls;
        private readonly NumberService _numberService;
        private readonly Calculator _calculator;

        public AdditionalOptionForm()
        {
            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
            _comboBoxService = new ComboBoxService(new LanguageTranslator(new TextTranslationsToLithuaniaLanguage()));
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
            _numberService = new NumberService(new InvariantCultureNumberService());
            _calculator = new Calculator(new InvariantCultureCalculatorService());

            InitializeComponent();
        }

        private void AdditionalOptionForm_Load(object sender, EventArgs e)
        {
            SetLanguageText();
            PopulateComboBoxesInfo();
        }

        private void AdditionalOptionForm_Resize(object sender, EventArgs e)
        {
            TableLayoutPanel.Font = WindowState == FormWindowState.Maximized ? FormFontConstants.MaximizedFontSize : FormFontConstants.DefaultFontSize;
        }

        private void CountSumByDateButton_Click(object sender, EventArgs e)
        {
           CountAllMoneyResultsByDate();
        }

        #region Helpers

        private void SetLanguageText()
        {
            ProductSoldPriceInfoLabel.Text = _languageTranslator.SetProductSoldPriceInfoLabelText();
            ProductPvmInfoLabel.Text = _languageTranslator.SetProductPvmInfoLabelText();
            ProductSoldPriceWithPvmLabel.Text = _languageTranslator.SetProductSoldPriceWithPvmInfoLabelText();
            ProductProfitInfoLabel.Text = _languageTranslator.SetProductProfitInfoLabelText();

            IncludePvmCheckBox.Text = _languageTranslator.SetIncludePvmText();

            DateInfoLabel.Text = _languageTranslator.SetProductReceiptDateInfoLabelText();
            YearInfoLabel.Text = _languageTranslator.SetYearText();

            CountSumByDateButton.Text = _languageTranslator.SetCountFullOrderCalculationButtonText();
            CountSumByYearButton.Text = _languageTranslator.SetCountFullOrderCalculationButtonText();
        }

        private void PopulateComboBoxesInfo()
        {
            var taskAllDates = _repositoryQueryCalls.GetAllExistingDates();
            var allDate = taskAllDates.Result;

            if (allDate != null)
            {
                var enumerableAllDate = allDate as string[] ?? allDate.ToArray();
                var existingYears = GetAllYearFromIEnumerable(enumerableAllDate);
                _comboBoxService.FillDateComboBox(DateComboBox, enumerableAllDate);
                _comboBoxService.FillYearComboBox(YearComboBox, existingYears);
            }
        }

        private IEnumerable<int> GetAllYearFromIEnumerable(IEnumerable<string> allDate)
        {
            var allYear = new List<int>();

            foreach (var date in allDate)
            {
                var year = DateTime.ParseExact(date, FormTextBoxDefaultTexts.DateFormat, CultureInfo.InvariantCulture).Year;
                allYear.Add(year);
            }

            var existingYears = allYear.Distinct().OrderByDescending(d => d);

            return existingYears;
        }

        private void CountAllMoneyResultsByDate()
        {
            var task = _repositoryQueryCalls.GetAllMoneyMainInfoFromFullProductByDate(DateComboBox.Text);
            var result = task.Result;

            if (result != null)
            {
                var moneyMainInfo = result.ToList();

                var allProductId = new List<int>();

                foreach (var model in moneyMainInfo)
                {
                    int productIdElement = model.ProductId;
                    allProductId.Add(productIdElement);
                }

                var id = allProductId.ToArray();

                var taskOfIncludePvm = _repositoryQueryCalls.GetAllIncludePvmInfoByMultipleId(id);

                var resultOfIncludePvm = taskOfIncludePvm.Result.ToList();

                CountAllMoneyResultByDateAndIncludePvmOptionType(moneyMainInfo, resultOfIncludePvm);

            }
        }

        private void CountAllMoneyResultByDateAndIncludePvmOptionType(List<MoneyMainInfoModel> mainInfo, List<AdditionalInfoIncludePvmModel> includePvmInfo )
        {
            var mainMoneyCountList = new List<MainMoneyCountingModel>();

            foreach (var moneyMainInfoModel in mainInfo)
            {
                var countingModel = new MainMoneyCountingModel()
                {
                    ProductId = moneyMainInfoModel.ProductId,
                    ProductSoldPrice = moneyMainInfoModel.ProductSoldPrice,
                    ProductPvm = moneyMainInfoModel.ProductPvm,
                    ProductSoldPriceWithPvm = moneyMainInfoModel.ProductSoldPriceWithPvm
                };

                countingModel.IncludePvm = includePvmInfo.Find(f => f.Id == countingModel.ProductId).IncludePvm;
                mainMoneyCountList.Add(countingModel);
            }

            if (IncludePvmCheckBox.Checked)
            {
                mainMoneyCountList.RemoveAll(r => r.IncludePvm == 0);
            }
            else
            {
                mainMoneyCountList.RemoveAll(r => r.IncludePvm == 1);
            }

            ProductSoldPriceTextBox.Text =
                _numberService.ParseDoubleToString(mainMoneyCountList.Sum(s => s.ProductSoldPrice));
            ProductPvmTextBox.Text = _numberService.ParseDoubleToString(mainMoneyCountList.Sum(s => s.ProductPvm));
            ProductSoldPriceWithPvmTextBox.Text =
                _numberService.ParseDoubleToString(mainMoneyCountList.Sum(s => s.ProductSoldPriceWithPvm));
            ProfitTextBox.Text = _numberService.ParseDoubleToString(mainMoneyCountList.Sum(s => s.ProductProfit));
        }

        #endregion
        
    }
}
