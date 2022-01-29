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

        public int? TryParseStringToNumberOrNull(string text)
        {
            return _numberService.TryParseStringToNumberOrNull(text);
        }

        public double? TryParseStringToDoubleNumberOrNull(string text)
        {
            return _numberService.TryParseStringToDoubleNumberOrNull(text);
        }
    }
}
