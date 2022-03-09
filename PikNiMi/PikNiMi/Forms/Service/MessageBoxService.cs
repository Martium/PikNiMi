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

        public void ShowEnteredNotNumberError()
        {
            MessageBox.Show(_languageTranslator.ShowEnteredNotNumberError());
        }

        public void ShowDeleteSuccessful()
        {
            MessageBox.Show(_languageTranslator.ShowDeleteSuccessful());
        }

        public void ShowDeleteError()
        {
            MessageBox.Show(_languageTranslator.ShowDeleteError());
        }

        public void ShowProductTypeExist()
        {
            MessageBox.Show(_languageTranslator.ShowProductTypeExist());
        }

        public void ShowProductTypeNotExistsForDelete()
        {
            MessageBox.Show(_languageTranslator.ShowProductTypeNotExistsForDelete());
        }
    }
}
