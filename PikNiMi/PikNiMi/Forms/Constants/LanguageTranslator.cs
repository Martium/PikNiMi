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

        public string SetProductReceiptDateInfoLabelText()
        {
            return _languageTranslator.SetProductReceiptDateInfoLabelText();
        }

        public string SetProductDescriptionInfoLabelText()
        {
            return _languageTranslator.SetProductDescriptionInfoLabelText();
        }

        public string SetProductColorInfoLabelText()
        {
            return _languageTranslator.SetProductColorInfoLabelText();
        }

        public string SetProductSizeInfoLabelText()
        {
            return _languageTranslator.SetProductSizeInfoLabelText();
        }

        public string SetProductCareInfoLabelText()
        {
            return _languageTranslator.SetProductCareInfoLabelText();
        }

        public string SetProductMadeStuffInfoLabelText()
        {
            return _languageTranslator.SetProductMadeStuffInfoLabelText();
        }

        public string SetProductMadeInInfoLabelText()
        {
            return _languageTranslator.SetProductMadeInInfoLabelText();
        }

        public string SetProductQuantityInfoLabelText()
        {
            return _languageTranslator.SetProductQuantityInfoLabelText();
        }

        public string SetProductQuantityLeftInfoLabelText()
        {
            return _languageTranslator.SetProductQuantityLeftInfoLabelText();
        }

        public string SetProductOriginalUnitPriceAtOriginalCurrencyInfoLabelText()
        {
            return _languageTranslator.SetProductOriginalUnitPriceAtOriginalCurrencyInfoLabelText();
        }

        public string SetProductQuantityPriceAtOriginalCurrencyInfoLabelText()
        {
            return _languageTranslator.SetProductQuantityPriceAtOriginalCurrencyInfoLabelText();
        }

        public string SetProductUnitPriceInEuroInfoLabelText()
        {
            return _languageTranslator.SetProductUnitPriceInEuroInfoLabelText();
        }

        public string SetProductQuantityPriceInEuroInfoLabelText()
        {
            return _languageTranslator.SetProductQuantityPriceInEuroInfoLabelText();
        }

        public string SetTripExpensesInfoLabelText()
        {
            return _languageTranslator.SetTripExpensesInfoLabelText();
        }

        public string SetProductExpensesCostPriceInfoLabelText()
        {
            return _languageTranslator.SetProductExpensesCostPriceInfoLabelText();
        }

        public string SetProductSoldPriceInfoLabelText()
        {
            return _languageTranslator.SetProductSoldPriceInfoLabelText();
        }

        public string SetProductPvmInfoLabelText()
        {
            return _languageTranslator.SetProductPvmInfoLabelText();
        }

        public string SetProductSoldPriceWithPvmInfoLabelText()
        {
            return _languageTranslator.SetProductSoldPriceWithPvmInfoLabelText();
        }

        public string SetProductSoldInfoLabelText()
        {
            return _languageTranslator.SetProductSoldInfoLabelText();
        }

        public string SetProductProfitInfoLabelText()
        {
            return _languageTranslator.SetProductProfitInfoLabelText();
        }

        public string SetDiscountInfoLabelText()
        {
            return _languageTranslator.SetDiscountInfoLabelText();
        }

        public string SetProductTypeInfoLabelText()
        {
            return _languageTranslator.SetProductTypeInfoLabelText();
        }

        public string SetProductWantProfitInfoLabelText()
        {
            return _languageTranslator.SetProductWantProfitInfoLabelText();
        }

        public string SetTextBoxResizeButtonText()
        {
            return _languageTranslator.SetTextBoxResizeButtonText();
        }

        public string SetMoneyCourseText()
        {
            return _languageTranslator.SetMoneyCourseText();
        }

        public string SetSaveButtonText()
        {
            return _languageTranslator.SetSaveButtonText();
        }

        public string SetNotChooseText()
        {
            return _languageTranslator.SetNotChooseText();
        }
    }
}
