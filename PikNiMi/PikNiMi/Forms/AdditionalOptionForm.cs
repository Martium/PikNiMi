using System;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class AdditionalOptionForm : Form
    {
        private readonly LanguageTranslator _languageTranslator;
        private readonly ComboBoxService _comboBoxService;

        public AdditionalOptionForm()
        {
            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
            _comboBoxService = new ComboBoxService(new LanguageTranslator(new TextTranslationsToLithuaniaLanguage()));
            InitializeComponent();
        }

        private void AdditionalOptionForm_Load(object sender, EventArgs e)
        {
            SetLanguageText();
        }

        private void AdditionalOptionForm_Resize(object sender, EventArgs e)
        {
            TableLayoutPanel.Font = WindowState == FormWindowState.Maximized ? FormFontConstants.MaximizedFontSize : FormFontConstants.DefaultFontSize;
        }

        #region Helpers

        private void SetLanguageText()
        {
            ProductSoldPriceInfoLabel.Text = _languageTranslator.SetProductSoldPriceInfoLabelText();
            ProductPvmInfoLabel.Text = _languageTranslator.SetProductPvmInfoLabelText();
            ProductSoldPriceWithPvmTextBox.Text = _languageTranslator.SetProductSoldPriceWithPvmInfoLabelText();
            ProductProfitInfoLabel.Text = _languageTranslator.SetProductProfitInfoLabelText();

            DateInfoLabel.Text = _languageTranslator.SetProductReceiptDateInfoLabelText();
            YearInfoLabel.Text = _languageTranslator.SetYearText();
        }

        private void PopulateComboBoxesInfo()
        {

        }

        #endregion
    }
}
