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

        public string SetFormHeaderText(FormHeaderTextTypeEnum formHeaderTextType)
        {
            string text;
            switch (formHeaderTextType)
            {
                case FormHeaderTextTypeEnum.MainForm:
                    text = @"PikNiMi Sandėlis";
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

        public string SetCountFullOrderDiscountButtonText()
        {
            return "Skaičiuoti savikainą";
        }
    }
}
