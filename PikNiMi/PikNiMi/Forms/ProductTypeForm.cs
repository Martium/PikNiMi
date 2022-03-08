using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.Repository.DependencyInjectionRepositoryClass.Repository;
using PikNiMi.Repository.SqlLite;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class ProductTypeForm : Form
    {
        private readonly RepositoryQueryCalls _repositoryQueryCalls;
        private readonly LanguageTranslator _languageTranslator;
        private readonly MessageBoxService _messageBoxService;
        private List<string> _productTypeList;
        public ProductTypeForm()
        {
            _repositoryQueryCalls = new RepositoryQueryCalls(new SqlLiteRepositoryQueryCalls());
            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
            _messageBoxService = new MessageBoxService(_languageTranslator);
            _productTypeList = new List<string>();
            InitializeComponent();
        }

        private void ProductTypeForm_Load(object sender, EventArgs e)
        {
            ProductTypeTextBox.MaxLength = TextBoxLength.ProductType;
        }

        private void AddNewProductTypeButton_Click(object sender, EventArgs e)
        {
            bool isExists = CheckProductTypeExists();

            if (isExists)
            {
                // todo message box exists
            }
            else
            {
                var task = _repositoryQueryCalls.AddNewProductType(ProductTypeTextBox.Text);

                if (task.IsFaulted)
                {
                    _messageBoxService.ShowSaveNewRecordErrorMessage();
                }
                else
                {
                    _messageBoxService.ShowSaveNewRecordSuccessMessage();
                }

                this.Close();
            }
        }

        #region Helpers

        private bool CheckProductTypeExists()
        {
            _productTypeList = _languageTranslator.LoadProductTypeDefaultList();

            var task = _repositoryQueryCalls.GetAllProductType();
            var existingProductType = task.Result;

            if (existingProductType != null)
            {
                _productTypeList.AddRange(existingProductType.ToList());
            }

            bool isExists = _productTypeList.Contains(ProductTypeTextBox.Text);

            return isExists;
        }

        #endregion
    }
}
