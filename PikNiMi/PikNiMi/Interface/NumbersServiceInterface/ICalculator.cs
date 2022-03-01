namespace PikNiMi.Interface.NumbersServiceInterface
{
    public interface ICalculator
    {
        string CountQuantityPrice(string quantity, string unitPrice);
        string ConvertUnitPriceToEuroCurrency(string moneyCourse, string productOriginalUnitPriceAtOriginalCurrency);
        string CountSoldPriceWithoutPvm(string productWantProfit, string productExpensesCostPrice);
        string CountSoldPriceWithPvm(string productWantProfit, string productExpensesCostPrice);
        string CountJustPvm(string productSoldPrice);
        string CountProductExpenses(string productPriceInEuro, string productTripExpenses);
    }
}
