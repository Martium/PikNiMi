using System.Collections.Generic;
using PikNiMi.Enums;

namespace PikNiMi.Interface
{
    public interface ILanguageTranslator
    {
        List<string> LoadProductTypeDefaultList();
        string SetFormHeaderText(FormHeaderTextTypeEnum formHeaderTextType);
        string SetProductTypeComboBoxDefaultText();
        string SetSearchTextBoxPlaceHolder();
        string SetTripExpensesTextBoxPlaceHolder();
        string SetAddNewProductButtonText();
        string SetUpdateProductButtonText();
        string SetSearchButtonText();
        string SetCancelSearchButtonText();
        string SetHistoryButtonText();
        string SetAddNewProductTypeButtonText();
        string SetDiscountButtonText();
        string SetCountFullOrderDiscountButtonText();
        string SetProductReceiptDateInfoLabelText();
        string SetProductDescriptionInfoLabelText();
        string SetProductColorInfoLabelText();
        string SetProductSizeInfoLabelText();
        string SetProductCareInfoLabelText();
        string SetProductMadeStuffInfoLabelText();
        string SetProductMadeInInfoLabelText();
        string SetProductQuantityInfoLabelText();
        string SetProductQuantityLeftInfoLabelText();
        string SetProductOriginalUnitPriceAtOriginalCurrencyInfoLabelText();
        string SetProductQuantityPriceAtOriginalCurrencyInfoLabelText();
        string SetProductUnitPriceInEuroInfoLabelText();
        string SetProductQuantityPriceInEuroInfoLabelText();
        string SetTripExpensesInfoLabelText();
        string SetProductExpensesCostPriceInfoLabelText();
        string SetProductSoldPriceInfoLabelText();
        string SetProductPvmInfoLabelText();
        string SetProductSoldPriceWithPvmInfoLabelText();
        string SetProductSoldInfoLabelText();
        string SetProductProfitInfoLabelText();
        string SetDiscountInfoLabelText();
        string SetProductTypeInfoLabelText();
        string SetProductWantProfitInfoLabelText();
        string SetTextBoxResizeButtonText();
        string SetMoneyCourseText();
        string SetSaveButtonText();
    }
}
