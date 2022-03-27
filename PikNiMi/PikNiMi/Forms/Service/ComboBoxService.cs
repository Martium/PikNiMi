using System.Collections.Generic;
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

        public ComboBox FillDateComboBox(ComboBox comboBox, IEnumerable<string> allDate)
        {
            var list = allDate.ToList();

            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = list;
            comboBox.DisplayMember = list.FirstOrDefault();
            comboBox.SelectedItem = list.FirstOrDefault();

            return comboBox;
        }

        public ComboBox FillYearComboBox(ComboBox comboBox, IEnumerable<int> allYear)
        {
            var list = allYear.ToList();

            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = list;
            comboBox.DisplayMember = list.FirstOrDefault().ToString();
            comboBox.SelectedItem = list.FirstOrDefault();

            return comboBox;
        }

        
    }
}
