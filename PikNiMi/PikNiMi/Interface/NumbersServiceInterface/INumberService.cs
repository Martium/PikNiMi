namespace PikNiMi.Interface.NumbersServiceInterface
{
    public interface INumberService
    {
        int ParseStringToNumber(string text);
        int TryParseStringToNumberOrDefault(string text);
        double TryParseStringToDoubleNumberOrDefault(string text);
        string ParseDoubleToString(double number);
    }
}
