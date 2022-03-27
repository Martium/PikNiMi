using System;
using System.Collections.Generic;
using PikNiMi.Enums;
using PikNiMi.Interface;

namespace PikNiMi.TranslationsToAnotherLanguages
{
    public class TextTranslationsToLithuaniaLanguage : ILanguageTranslator
    {
        public List<string> LoadProductTypeDefaultList()
        {
            var productType = new List<string>()
            {
                "Suknelė", "Sijonas", "Palaidinė", "Megztukas", "Kelnės", "Džinsai", "Kepurė", "Šalikas",
                "Diržas", "Aksesuaras", "Kojinės", "Apatinis trikotažas", "Striukė", "Paltas", "Tunika",
                "Kardiganas", "Džemperis", "Pasirinkti tipą..."
            };

            return productType;
        }

        public string LoadProductTypeDefaultValue()
        {
            return "Pasirinkti tipą...";
        }

        public string SetFormHeaderText(MainFormTypeEnum mainFormType)
        {
            string text;
            switch (mainFormType)
            {
                case MainFormTypeEnum.MainForm:
                    text = @"PikNiMi Sandėlis";
                    break;
                default:
                    text = @"Nenumatyta Forma kreiptis į Administratorių";
                    break;
            }

            return text;
        }

        public string SetProductFormHeaderText(ProductFormTypeEnum productFormType)
        {
            string text;
            switch (productFormType)
            {
                case ProductFormTypeEnum.NewProductForm:
                    text = @"Nauja Prekė";
                    break;
                case ProductFormTypeEnum.UpdateProductForm:
                    text = @"Atnaujinti Prekę";
                    break;
                default:
                    text = @"Nenumatyta Forma kreiptis į Administratorių";
                    break;
            }

            return text;
        }

        public string SetProductTypeComboBoxDefaultText()
        {
            return "Pasirinkti tipą...";
        }

        public string SetSearchTextBoxPlaceHolder()
        {
            return "Įveskite paieškos frazę... ";
        }

        public string SetTripExpensesTextBoxPlaceHolder()
        {
            return "Įveskite kelionės išlaidas...";
        }

        public string SetAddNewProductButtonText()
        {
            return "Pridėti naują produktą";
        }

        public string SetUpdateProductButtonText()
        {
            return "Atnaujinti Produktą";
        }

        public string SetSearchButtonText()
        {
            return "Ieškoti";
        }

        public string SetCancelSearchButtonText()
        {
            return "atšaukti";
        }

        public string SetHistoryButtonText()
        {
            return "Istorija";
        }

        public string SetAddNewProductTypeButtonText()
        {
            return $" Pridėti Naują {Environment.NewLine} Tipą";
        }

        public string SetDiscountButtonText()
        {
            return "Nuolaidos";
        }

        public string SetCountFullOrderCalculationButtonText()
        {
            return "Skaičiuoti viską";
        }

        public string SetProductReceiptDateInfoLabelText()
        {
            return "Data";
        }

        public string SetProductDescriptionInfoLabelText()
        {
            return "Aprašymas";
        }

        public string SetProductColorInfoLabelText()
        {
            return "Spalva";
        }

        public string SetProductSizeInfoLabelText()
        {
            return "Dydis";
        }

        public string SetProductCareInfoLabelText()
        {
            return "Priežiūra";
        }

        public string SetProductMadeStuffInfoLabelText()
        {
            return "Sudėtis";
        }

        public string SetProductMadeInInfoLabelText()
        {
            return "Pagaminta";
        }

        public string SetProductQuantityInfoLabelText()
        {
            return "Kiekis";
        }

        public string SetProductQuantityLeftInfoLabelText()
        {
            return "Likutis";
        }

        public string SetProductOriginalUnitPriceAtOriginalCurrencyInfoLabelText()
        {
            return "Vnt. Kaina Kt. Valiuta";
        }

        public string SetProductQuantityPriceAtOriginalCurrencyInfoLabelText()
        {
            return "Kiekio Kaina Kt. Valiuta";
        }

        public string SetProductUnitPriceInEuroInfoLabelText()
        {
            return "Vnt. Kaina EUR";
        }

        public string SetProductQuantityPriceInEuroInfoLabelText()
        {
            return "Kiekio Kaina EUR";
        }

        public string SetTripExpensesInfoLabelText()
        {
            return "Kelionės išlaidos";
        }

        public string SetProductExpensesCostPriceInfoLabelText()
        {
            return "Savikaina su išlaidomis";
        }

        public string SetProductSoldPriceInfoLabelText()
        {
            return "Pardavimo Kaina";
        }

        public string SetProductPvmInfoLabelText()
        {
            return "PVM";
        }

        public string SetProductSoldPriceWithPvmInfoLabelText()
        {
            return "Pardavimo Kaina + PVM";
        }

        public string SetProductSoldInfoLabelText()
        {
            return "Produkto Parduota";
        }

        public string SetProductProfitInfoLabelText()
        {
            return "Pelnas";
        }

        public string SetDiscountInfoLabelText()
        {
            return "Nuolaidos";
        }

        public string SetProductTypeInfoLabelText()
        {
            return "Produkto Tipas";
        }

        public string SetProductWantProfitInfoLabelText()
        {
            return "Norimas Pelnas";
        }

        public string SetTextBoxResizeButtonText()
        {
            return @"Peržiūra";
        }

        public string SetMoneyCourseText()
        {
            return @"Kursas";
        }

        public string SetSaveButtonText()
        {
            return @"Išsaugoti";
        }

        public string SetNotChooseText()
        {
            return @"Nepasirinkta";
        }

        public string SetCalculateButtonText()
        {
            return @"Skaičiuoti";
        }

        public string SetCalculateByWantProfitText()
        {
            return @"Norimą pelną";
        }

        public string SetCalculateBySoldPriceText()
        {
            return @"Pardavimo kainą";
        }

        public string SetCalculateBySoldPriceWithPvm()
        {
            return @"Pardavimo kainą + Pvm";
        }

        public string SetIncludePvmText()
        {
            return @"Taikyti Pvm";
        }

        public string SetDeleteText()
        {
            return @"Trinti";
        }

        public string SetYearText()
        {
            return @"Metai";
        }

        public string SetAdditionalOption()
        {
            return $@"Papildomos {Environment.NewLine} Funkcijos ";
        }

        #region MessageBoxMessage

        public string ShowSaveNewRecordSuccessMessage()
        {
            return @"Sekmingai išsaugota";
        }

        public string ShowSaveNewRecordErrorMessage()
        {
            return @"Neišsaugota kreiptis arba išsaugota nepilna informacija į Administratorių";
        }

        public string ShowRecordNotFoundByDateErrorMessage()
        {
            return @"Nebuvo Rasta įrašų pagal šitą datą !";
        }

        public string ShowSelectRowErrorMessage()
        {
            return @"Nėra pasirinktas produktas kurį galima būtų atnaujinti";
        }

        public string ShowEnteredNotNumberError()
        {
            return
                @"Raudoname(uose) langelyje(uose) tai ką įvedėte nėra skaičius(iai), nebus atlikti teisingi skaičiavimai!";
        }

        public string ShowDeleteSuccessful()
        {
            return @"Ištrinta sekmingai";
        }

        public string ShowDeleteError()
        {
            return @"Neištrinta kreiptis į Administratorių";
        }

        public string ShowProductTypeExist()
        {
            return @"Šis Produkto tipas egzistuoja";
        }

        public string ShowProductTypeNotExistsForDelete()
        {
            return @"Tokio tipo nėra kurį norite ištrinti";
        }

        #endregion
    }
}
