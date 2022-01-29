namespace PikNiMi.Interface.NumbersServiceInterface
{
    public interface INumberService
    {
        int ParseStringToNumber(string text);
        int? TryParseStringToNumberOrNull(string text);
        double? TryParseStringToDoubleNumberOrNull(string text);
    }
}
