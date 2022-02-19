using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Repository.Custom_Repository;

namespace PikNiMi.Forms.Service
{
    public class ProductTypeComboBoxService
    {
        private readonly LanguageTranslator _languageTranslator;

        public ProductTypeComboBoxService(LanguageTranslator languageTranslator)
        {
            _languageTranslator = languageTranslator;
        }

        public ComboBox SetProductTypeCustomValues(ComboBox comboBox)
        {
            var customProductTypes = _languageTranslator.LoadProductTypeDefaultList();
            customProductTypes.Sort();

            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = customProductTypes;
            comboBox.DisplayMember = _languageTranslator.SetProductTypeComboBoxDefaultText();
            comboBox.SelectedItem = _languageTranslator.SetProductTypeComboBoxDefaultText();

            return comboBox;
        }
    }
}
