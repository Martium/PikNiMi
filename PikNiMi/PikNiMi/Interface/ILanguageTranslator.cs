using System.Collections.Generic;
using PikNiMi.Enums;

namespace PikNiMi.Interface
{
    public interface ILanguageTranslator
    {
        List<string> LoadProductTypeDefaultList();
        string LoadProductTypeDefaultValue();
        string SetFormHeaderText(MainFormTypeEnum mainFormType);
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
        string SetCountFullOrderCalculationButtonText();
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
        string SetNotChooseText();
        string SetCalculateButtonText();
        string SetCalculateByWantProfitText();
        string SetCalculateBySoldPriceText();
        string SetCalculateBySoldPriceWithPvm();
        string SetIncludePvmText();

        string ShowSaveNewRecordSuccessMessage();
        string ShowSaveNewRecordErrorMessage();
        string ShowRecordNotFoundByDateErrorMessage();
        string ShowSelectRowErrorMessage();
        string ShowEnteredNotNumberError();
        string ShowDeleteSuccessful();
        string ShowDeleteError();
        string ShowProductTypeExist();
        string ShowProductTypeNotExistsForDelete();
    }
}
