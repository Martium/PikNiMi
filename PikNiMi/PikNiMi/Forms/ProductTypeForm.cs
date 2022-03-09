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
            SetLanguageText();
        }

        private void AddNewProductTypeButton_Click(object sender, EventArgs e)
        {
            bool isExists = CheckProductTypeExists(ProductTypeTextBox.Text);

            if (isExists)
            {
                _messageBoxService.ShowProductTypeExist();
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

        private void DeleteProductTypeButton_Click(object sender, EventArgs e)
        {
            bool isExists = CheckProductTypeExists(DeleteProductTypeTextBox.Text);

            if (isExists)
            {
                var task = _repositoryQueryCalls.DeleteExistingProductType(DeleteProductTypeTextBox.Text);

                if (task.IsFaulted)
                {
                    _messageBoxService.ShowDeleteError();
                }
                else
                {
                    _messageBoxService.ShowDeleteSuccessful();
                }

                this.Close();
            }
            else
            {
                _messageBoxService.ShowProductTypeNotExistsForDelete();
            }
        }

        #region Helpers

        private bool CheckProductTypeExists(string text)
        {
            _productTypeList = _languageTranslator.LoadProductTypeDefaultList();

            var task = _repositoryQueryCalls.GetAllProductType();
            var existingProductType = task.Result;

            if (existingProductType != null)
            {
                _productTypeList.AddRange(existingProductType.ToList());
            }

            bool isExists = _productTypeList.Contains(text);

            return isExists;
        }

        private void SetLanguageText()
        {
            AddNewProductTypeButton.Text = _languageTranslator.SetAddNewProductTypeButtonText();
        }


        #endregion
        
    }
}
