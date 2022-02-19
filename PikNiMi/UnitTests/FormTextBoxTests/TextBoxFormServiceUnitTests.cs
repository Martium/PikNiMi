using Microsoft.VisualStudio.TestTools.UnitTesting;
using PikNiMi.Forms.Constants;
using PikNiMi.Forms.Service;
using PikNiMi.TranslationsToAnotherLanguages;

namespace UnitTests.FormTextBoxTests
{
    [TestClass]
    public class TextBoxFormServiceUnitTests
    {
        private readonly LanguageTranslator _languageTranslator;
        private readonly TextBoxFormService _textBoxFormService;

        public TextBoxFormServiceUnitTests()
        {
            _textBoxFormService = new TextBoxFormService();
            _languageTranslator = new LanguageTranslator(new TextTranslationsToLithuaniaLanguage());
        }

        [TestMethod]
        public void DisableTextBoxText_DisableTextWhenEqualOrLeaveSameText_MakeStringEmptyOrLeaveSameText()
        {
            string firstTestTextBoxText = _languageTranslator.SetSearchTextBoxPlaceHolder();
            string defaultTextValue = _languageTranslator.SetSearchTextBoxPlaceHolder();
            string firstTestExpectedValue = string.Empty;

            string secondTestTextBoxText = "something";
            string secondTestExpectedValue = secondTestTextBoxText;

            string firstTestResult = _textBoxFormService.DisableTextBoxText(firstTestTextBoxText, defaultTextValue);
            string secondTestResult = _textBoxFormService.DisableTextBoxText(secondTestTextBoxText, defaultTextValue);

            Assert.AreEqual(firstTestResult, firstTestExpectedValue);
            Assert.AreEqual(secondTestResult, secondTestExpectedValue);
        }
        [TestMethod]
        public void
            SetTextBoxTextForEmptyOrWhiteSpaceText_ReturnSpecificTextToTextBoxTextWhenEmpty_ReturnSpecificTextIfEmptyOrWhiteSpace()
        {
            string specificText = _languageTranslator.SetSearchTextBoxPlaceHolder();

            string firstTestTextBoxText = string.Empty;
            string firstTestExpectedResult = specificText;

            string secondTestTextBoxText = "something";
            string secondTestExpectedResult = secondTestTextBoxText;

            string firstTestResult =
                _textBoxFormService.SetTextBoxTextForEmptyOrWhiteSpaceText(firstTestTextBoxText,
                    specificText);
            string secondTestResult =
                _textBoxFormService.SetTextBoxTextForEmptyOrWhiteSpaceText(secondTestTextBoxText, specificText);

            Assert.AreEqual(firstTestExpectedResult, firstTestResult);
            Assert.AreEqual(secondTestExpectedResult, secondTestResult);
        }
    }
}
