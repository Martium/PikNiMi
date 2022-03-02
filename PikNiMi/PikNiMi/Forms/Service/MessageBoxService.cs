using System.Windows.Forms;
using PikNiMi.Forms.Constants;

namespace PikNiMi.Forms.Service
{
    public class MessageBoxService
    {
        private readonly LanguageTranslator _languageTranslator;

        public MessageBoxService(LanguageTranslator languageTranslator)
        {
            _languageTranslator = languageTranslator;
        }

        public void ShowSaveNewRecordSuccessMessage()
        {
            MessageBox.Show(_languageTranslator.ShowSaveNewRecordSuccessMessage());
        }

        public void ShowSaveNewRecordErrorMessage()
        {
            MessageBox.Show(_languageTranslator.ShowSaveNewErrorRecordSuccessMessage());
        }

        public void ShowRecordNotFoundByDateErrorMessage()
        {
            MessageBox.Show(_languageTranslator.ShowRecordNotFoundByDateErrorMessage());
        }

        public void ShowSelectRowErrorMessage()
        {
            MessageBox.Show(_languageTranslator.ShowSelectRowErrorMessage());
        }
    }
}
