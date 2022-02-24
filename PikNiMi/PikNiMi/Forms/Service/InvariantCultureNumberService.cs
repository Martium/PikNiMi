using System;
using System.Globalization;
using PikNiMi.Interface.NumbersServiceInterface;

namespace PikNiMi.Forms.Service
{
    public class InvariantCultureNumberService : INumberService
    {
        private readonly CultureInfo _cultureInfo = CultureInfo.InvariantCulture;
        private readonly NumberStyles _numberStyles = NumberStyles.Any;

        private string ChangeCommaToDot(string text)
        {
            return text.Replace(",", ".");
        }

        public int ParseStringToNumber(string text)
        {
            return int.Parse(text);
        }

        public int TryParseStringToNumberOrDefault(string text)
        {
            int numberOrNull;

            if (int.TryParse(text, out int number))
            {
                numberOrNull = number;
            }
            else
            {
                numberOrNull = default;
            }

            return numberOrNull;
        }

        public double TryParseStringToDoubleNumberOrDefault(string text)
        {
            string changeCommaToDot = text != null ? ChangeCommaToDot(text) : null;

            double numberOrNull;

            if (double.TryParse(changeCommaToDot, _numberStyles, _cultureInfo ,out double number))
            {
                numberOrNull = number;
            }
            else
            {
                numberOrNull = default;
            }

            return numberOrNull;
        }

        public string ParseDoubleToString(double number)
        {
            return number.ToString(_cultureInfo);
        }

       

    }
}
