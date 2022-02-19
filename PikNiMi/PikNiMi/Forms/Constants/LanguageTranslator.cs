using System.Collections.Generic;
using PikNiMi.Enums;
using PikNiMi.Interface;

namespace PikNiMi.Forms.Constants
{
    public class LanguageTranslator
    {
        private readonly ILanguageTranslator _languageTranslator;

        public LanguageTranslator(ILanguageTranslator languageTranslator)
        {
            _languageTranslator = languageTranslator;
        }

        public List<string> LoadProductTypeDefaultList()
        {
            return _languageTranslator.LoadProductTypeDefaultList();
        }

        public string FormHeaderText(FormHeaderTextTypeEnum formHeaderTextType)
        {
            return _languageTranslator.SetFormHeaderText(formHeaderTextType);
        }

        public string SetProductTypeComboBoxDefaultText()
        {
            return _languageTranslator.SetProductTypeComboBoxDefaultText();
        }

        public string SetSearchTextBoxPlaceHolder()
        {
            return _languageTranslator.SetSearchTextBoxPlaceHolder();
        }

        public string SetTripExpensesTextBoxPlaceHolder()
        {
            return _languageTranslator.SetTripExpensesTextBoxPlaceHolder();
        }

        public string SetAddNewProductButtonText()
        {
            return _languageTranslator.SetAddNewProductButtonText();
        }

        public string SetUpdateProductButtonText()
        {
            return _languageTranslator.SetUpdateProductButtonText();
        }

        public string SetSearchButtonText()
        {
            return _languageTranslator.SetSearchButtonText();
        }

        public string SetCancelSearchButtonText()
        {
            return _languageTranslator.SetCancelSearchButtonText();
        }

        public string SetHistoryButtonText()
        {
            return _languageTranslator.SetHistoryButtonText();
        }

        public string SetAddNewProductTypeButtonText()
        {
            return _languageTranslator.SetAddNewProductTypeButtonText();
        }

        public string SetDiscountButtonText()
        {
            return _languageTranslator.SetDiscountButtonText();
        }

        public string SetCountFullOrderDiscountButtonText()
        {
            return _languageTranslator.SetCountFullOrderDiscountButtonText();
        }


    }
}
