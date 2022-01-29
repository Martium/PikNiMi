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

        public int? TryParseStringToNumberOrNull(string text)
        {
            int? numberOrNull;

            if (int.TryParse(text, out int number))
            {
                numberOrNull = number;
            }
            else
            {
                numberOrNull = null;
            }

            return numberOrNull;
        }

        public double? TryParseStringToDoubleNumberOrNull(string text)
        {
            string changeCommaToDot = ChangeCommaToDot(text);

            double? numberOrNull;

            if (double.TryParse(changeCommaToDot, _numberStyles, _cultureInfo ,out double number))
            {
                numberOrNull = number;
            }
            else
            {
                numberOrNull = null;
            }

            return numberOrNull;
        }
    }
}
