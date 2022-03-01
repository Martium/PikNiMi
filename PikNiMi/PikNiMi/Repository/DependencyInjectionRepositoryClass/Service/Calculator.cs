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

        public string CountSoldPriceWithoutPvm(string productWantProfit, string productExpensesCostPrice)
        {
            return _calculator.CountSoldPriceWithoutPvm(productWantProfit, productExpensesCostPrice);
        }

        public string CountJustPvm(string productSoldPrice)
        {
            return _calculator.CountJustPvm(productSoldPrice);
        }

        public string CountSoldPriceWithPvm(string productWantProfit, string productExpensesCostPrice)
        {
            return _calculator.CountSoldPriceWithPvm(productWantProfit, productExpensesCostPrice);
        }

        public string CountProductExpenses(string productPriceInEuro, string productTripExpenses)
        {
            return _calculator.CountProductExpenses(productPriceInEuro, productTripExpenses);
        }

        public string CalculateWantProfitBySoldPriceWithoutPvm(string productSoldPrice, string productExpensesCostPrice)
        {
            return _calculator.CalculateWantProfitBySoldPriceWithoutPvm(productSoldPrice, productExpensesCostPrice);
        }

        public string CalculateWantProfitBySoldPriceWithPvm(string productSoldPriceWithPvm, string productExpensesCostPrice)
        {
            return _calculator.CalculateWantProfitBySoldPriceWithPvm(productSoldPriceWithPvm, productExpensesCostPrice);
        }
    }
}
