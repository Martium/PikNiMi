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
            string value;

            if (number == 0)
            {
                value = string.Empty;
            }
            else
            {
                value = number.ToString(_cultureInfo);
            }

            return value;
        }

        public bool ChangeIntegerValueToBool(int value)
        {
            bool isValueOne = value == 1;

            return isValueOne;
        }

        public int ChangeBoolValueToInteger(bool value)
        {
            int number = value ? 1 : 0;

            return number;
        }
    }
}
