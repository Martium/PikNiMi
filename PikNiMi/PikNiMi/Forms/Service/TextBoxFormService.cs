namespace PikNiMi.Forms.Service
{
    public class TextBoxFormService
    {
        public string DisableTextBoxText(string textBoxText, string disableText)
        {
            if (textBoxText == disableText)
            {
                textBoxText = string.Empty;
            }

            return textBoxText;
        }

        public string SetTextBoxTextForEmptyOrWhiteSpaceText(string textBoxText, string newText)
        {
            if (!string.IsNullOrWhiteSpace(textBoxText))
            {
                newText = textBoxText;
            }

            return newText;
        }
    }
}
