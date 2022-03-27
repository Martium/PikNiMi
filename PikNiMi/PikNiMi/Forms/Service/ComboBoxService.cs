using System.Linq;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository;
using PikNiMi.Repository.SqlLite;

namespace PikNiMi.Forms.Service
{
    public class ComboBoxService
    {
        private readonly LanguageTranslator _languageTranslator;
        private readonly RepositoryQueryCalls _repositoryQueryCalls;

        public ComboBoxService(LanguageTranslator languageTranslator)
        {
            _languageTranslator = languageTranslator;
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
        }

        public ComboBox SetProductTypeCustomValues(ComboBox comboBox)
        {
            var customProductTypes = _languageTranslator.LoadProductTypeDefaultList();
            var task = _repositoryQueryCalls.GetAllProductType();
            var additionalProductType = task.Result;

            if (additionalProductType != null)
            {
                customProductTypes.AddRange(additionalProductType.ToList());
            }

            customProductTypes.Sort();

            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = customProductTypes;
            comboBox.DisplayMember = _languageTranslator.SetProductTypeComboBoxDefaultText();
            comboBox.SelectedItem = _languageTranslator.SetProductTypeComboBoxDefaultText();

            return comboBox;
        }

        
    }
}
