using System.Windows.Forms;
using PikNiMi.Repository.Custom_Repository;

namespace PikNiMi.Forms.Service
{
    public class ProductTypeComboBoxService
    {
        public ComboBox SetProductTypeCustomValues(ComboBox comboBox)
        {
            var customProductTypes = ProductTypeRepository.ProductType;
            customProductTypes.Sort();

            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = customProductTypes;
            comboBox.DisplayMember = "Pasirinkti tipą...";
            comboBox.SelectedItem = "Pasirinkti tipą...";

            return comboBox;
        }
    }
}
