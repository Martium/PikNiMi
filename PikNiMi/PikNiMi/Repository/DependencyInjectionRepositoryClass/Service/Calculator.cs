using PikNiMi.Interface.NumbersServiceInterface;

namespace PikNiMi.Repository.DependencyInjectionRepositoryClass.Service
{
    public class Calculator
    {
        private readonly ICalculator _calculator;

        public Calculator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public string CountQuantityPrice(string quantity, string unitPrice)
        {
            return _calculator.CountQuantityPrice(quantity, unitPrice);
        }

        public string ConvertUnitPriceToEuroCurrency(string moneyCourse,
            string productOriginalUnitPriceAtOriginalCurrency)
        {
            return _calculator.ConvertUnitPriceToEuroCurrency(moneyCourse, productOriginalUnitPriceAtOriginalCurrency);
        }

        public string CountSoldPriceWithoutPvm(string productWantProfit, string productUnitPriceInEuro, string productExpensesCostPrice)
        {
            return _calculator.CountSoldPriceWithoutPvm(productWantProfit, productUnitPriceInEuro, productExpensesCostPrice);
        }

        public string CountSoldPriceWithPvm(string productWantProfit, string productUnitPriceInEuro, string productExpensesCostPrice)
        {
            return _calculator.CountSoldPriceWithPvm(productWantProfit, productUnitPriceInEuro, productExpensesCostPrice);
        }
    }
}
