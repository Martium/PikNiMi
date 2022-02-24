using System;
using PikNiMi.Interface.NumbersServiceInterface;

namespace PikNiMi.Forms.Service
{
    public class InvariantCultureCalculatorService : ICalculator
    {
        private readonly InvariantCultureNumberService _numberService;

        public InvariantCultureCalculatorService()
        {
            _numberService = new InvariantCultureNumberService();
        }

        private bool ValidateGivenNumbersIsMoreThanZero(double firstNumber, double secondNumber)
        {
            bool isFirstMoreThanZero = firstNumber > 0;
            bool isSecondMoreThanZero = secondNumber > 0;

            bool isBothMoreThanZero = isFirstMoreThanZero && isSecondMoreThanZero;

            return isBothMoreThanZero;
        }

        public string CountQuantityPrice(string quantity, string unitPrice)
        {
            double doubleQuantity = _numberService.TryParseStringToDoubleNumberOrDefault(quantity);
            double doubleUnitPrice = _numberService.TryParseStringToDoubleNumberOrDefault(unitPrice);

            double result;

            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(doubleQuantity, doubleUnitPrice);

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((doubleQuantity * doubleUnitPrice), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }

        public string ConvertUnitPriceToEuroCurrency(string moneyCourse, string productOriginalUnitPriceAtOriginalCurrency)
        {
            double course = _numberService.TryParseStringToDoubleNumberOrDefault(moneyCourse);
            double originalUnitPrice =
                _numberService.TryParseStringToDoubleNumberOrDefault(productOriginalUnitPriceAtOriginalCurrency);

            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(course, originalUnitPrice);

            double result;

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((originalUnitPrice / course), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);

        }

        public string CountSoldPriceWithoutPvm(string productWantProfit, string productUnitPriceInEuro, string productExpensesCostPrice)
        {
            double wantProfit = _numberService.TryParseStringToDoubleNumberOrDefault(productWantProfit);
            double unitPriceInEuro = _numberService.TryParseStringToDoubleNumberOrDefault(productUnitPriceInEuro);
            double expensesCostPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productExpensesCostPrice);

            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(wantProfit, unitPriceInEuro);

            double result;

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((wantProfit + unitPriceInEuro + expensesCostPrice), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }

        public string CountSoldPriceWithPvm(string productWantProfit, string productUnitPriceInEuro, string productExpensesCostPrice)
        {
            double wantProfit = _numberService.TryParseStringToDoubleNumberOrDefault(productWantProfit);
            double unitPriceInEuro = _numberService.TryParseStringToDoubleNumberOrDefault(productUnitPriceInEuro);
            double expensesCostPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productExpensesCostPrice);

            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(wantProfit, unitPriceInEuro);

            double result;

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round(((wantProfit + unitPriceInEuro + expensesCostPrice) * 1.21), 2,
                    MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }
    }
}
