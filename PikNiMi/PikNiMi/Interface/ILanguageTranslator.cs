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
    }
}
