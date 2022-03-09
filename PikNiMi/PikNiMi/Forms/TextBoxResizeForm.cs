using System;
using System.Windows.Forms;
using PikNiMi.Enums;
using PikNiMi.Forms.Constants;
using PikNiMi.Repository.MemoryCache;
using PikNiMi.TranslationsToAnotherLanguages;

namespace PikNiMi.Forms
{
    public partial class TextBoxResizeForm : Form
    {
        private readonly TextBoxResizeFormTypeEnum _textBoxResizeFormType;
        private readonly string _textValue;
        private readonly LanguageTranslator _languageTranslator;
        private readonly MemoryCacheControl _memoryCacheControl;

        public TextBoxResizeForm(TextBoxResizeFormTypeEnum textBoxResizeFormType, string textValue, MemoryCacheControl memoryCacheControl)
        {
            _textBoxResizeFormType = textBoxResizeFormType;
            _textValue = textValue;
            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
            _memoryCacheControl = memoryCacheControl;
            InitializeComponent();
        }

        private void TextBoxResizeForm_Load(object sender, EventArgs e)
        {
            SetResizeTextBoxMaxLength();
            SetFormText();
            ResizeRichTextBox.Text = _textValue;
        }

        private void TextBoxResizeForm_Resize(object sender, EventArgs e)
        {
            TableLayoutPanel.Font = WindowState == FormWindowState.Maximized ? FormFontConstants.MaximizedFontSize : FormFontConstants.DefaultFontSize;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _memoryCacheControl.SetNewStringValueToCache("TextBoxResize", ResizeRichTextBox.Text, 1);
            this.Close();
        }

        #region Helpers

        private void SetFormText()
        {
            switch (_textBoxResizeFormType)
            {
                case TextBoxResizeFormTypeEnum.ProductDescription:
                    this.Text = _languageTranslator.SetProductDescriptionInfoLabelText();
                    break;
                case TextBoxResizeFormTypeEnum.ProductColor:
                    this.Text = _languageTranslator.SetProductColorInfoLabelText();
                    break;
                case TextBoxResizeFormTypeEnum.ProductSize:
                    this.Text = _languageTranslator.SetProductSizeInfoLabelText();
                    break;
                case TextBoxResizeFormTypeEnum.ProductCare:
                    this.Text = _languageTranslator.SetProductCareInfoLabelText();
                    break;
                case TextBoxResizeFormTypeEnum.ProductMadeStuff:
                    this.Text = _languageTranslator.SetProductMadeStuffInfoLabelText();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SaveButton.Text = _languageTranslator.SetSaveButtonText();
        }

        private void SetResizeTextBoxMaxLength()
        {
            switch (_textBoxResizeFormType)
            {
                case TextBoxResizeFormTypeEnum.ProductDescription:
                    ResizeRichTextBox.MaxLength = TextBoxLength.ProductDescription;
                    break;
                case TextBoxResizeFormTypeEnum.ProductColor:
                    ResizeRichTextBox.MaxLength = TextBoxLength.ProductColor;
                    break;
                case TextBoxResizeFormTypeEnum.ProductSize:
                    ResizeRichTextBox.MaxLength = TextBoxLength.ProductSize;
                    break;
                case TextBoxResizeFormTypeEnum.ProductCare:
                    ResizeRichTextBox.MaxLength = TextBoxLength.ProductCare;
                    break;
                case TextBoxResizeFormTypeEnum.ProductMadeStuff:
                    ResizeRichTextBox.MaxLength = TextBoxLength.ProductMadeStuff;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
