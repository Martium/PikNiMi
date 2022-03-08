using PikNiMi.Interface.NumbersServiceInterface;

namespace PikNiMi.Repository.DependencyInjectionRepositoryClass.Service
{
    public class NumberService
    {
        private readonly INumberService _numberService;

        public NumberService(INumberService numberService)
        {
            _numberService = numberService;
        }

        public int ParseStringToNumber(string text)
        {
            return _numberService.ParseStringToNumber(text);
        }

        public int TryParseStringToNumberOrZero(string text)
        {
            return _numberService.TryParseStringToNumberOrDefault(text);
        }

        public double TryParseStringToDoubleNumberOrZero(string text)
        {
            return _numberService.TryParseStringToDoubleNumberOrDefault(text);
        }

        public string ParseDoubleToString(double number)
        {
            return _numberService.ParseDoubleToString(number);
        }

        public bool ChangeIntegerValueToBool(int value)
        {
            return _numberService.ChangeIntegerValueToBool(value);
        }

        public int ChangeBoolValueToInteger(bool value)
        {
            return _numberService.ChangeBoolValueToInteger(value);
        }

        public bool CheckStringIsNumber(string text)
        {
            return _numberService.CheckStringIsNumber(text);
        }
    }
}
