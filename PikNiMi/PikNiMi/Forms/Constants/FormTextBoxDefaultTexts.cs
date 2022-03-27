using System;

namespace PikNiMi.Forms.Constants
{
    public static class FormTextBoxDefaultTexts
    {
        public static string DateFormat => "yyyy-MM-dd";
        public static string DateToday => DateTime.Now.ToString(DateFormat);
    }
}
