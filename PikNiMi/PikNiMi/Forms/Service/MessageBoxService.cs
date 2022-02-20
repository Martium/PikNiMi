using PikNiMi.Forms.Constants;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms.Service
{
    public class MessageBoxService
    {
        private readonly LanguageTranslator _languageTranslator;

        public MessageBoxService()
        {
            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
        }

        
    }
}
