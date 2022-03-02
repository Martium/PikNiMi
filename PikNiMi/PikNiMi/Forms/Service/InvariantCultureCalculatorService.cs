﻿using System;
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

        private static bool ValidateGivenNumbersIsMoreThanZero(double firstNumber, double secondNumber)
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

        public string CountSoldPriceWithoutPvm(string productWantProfit, string productExpensesCostPrice)
        {
            double wantProfit = _numberService.TryParseStringToDoubleNumberOrDefault(productWantProfit);
            double expensesCostPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productExpensesCostPrice);

            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(wantProfit, expensesCostPrice);

            double result;

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((wantProfit + expensesCostPrice), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }

        public string CountSoldPriceWithPvm(string productWantProfit, string productExpensesCostPrice)
        {
            double wantProfit = _numberService.TryParseStringToDoubleNumberOrDefault(productWantProfit);
            double expensesCostPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productExpensesCostPrice);

            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(wantProfit, expensesCostPrice);

            double result;

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round(((wantProfit + expensesCostPrice) * 1.21), 2,
                    MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }

        public string CountJustPvm(string productSoldPrice)
        {
            double soldPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productSoldPrice);
            double result;

            if (soldPrice > 0)
            {
                result = Math.Round((soldPrice * 0.21), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }

        public string CountProductExpenses(string productPriceInEuro, string productTripExpenses)
        {
            double priceInEuro = _numberService.TryParseStringToDoubleNumberOrDefault(productPriceInEuro);
            double tripExpenses = _numberService.TryParseStringToDoubleNumberOrDefault(productTripExpenses);

            bool isBothNumberMoreThanZero = ValidateGivenNumbersIsMoreThanZero(priceInEuro, tripExpenses);
            double result;

            if (isBothNumberMoreThanZero)
            {
                result = Math.Round((priceInEuro + tripExpenses), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }

        public string CalculateWantProfitBySoldPriceWithoutPvm(string productSoldPrice, string productExpensesCostPrice)
        {
            double soldPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productSoldPrice);
            double expensesCostPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productExpensesCostPrice);
            double result;
            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(soldPrice, expensesCostPrice);

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((soldPrice - expensesCostPrice), 4, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }

        public string CalculateWantProfitBySoldPriceWithPvm(string productSoldPriceWithPvm, string productExpensesCostPrice)
        {
            double soldPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productSoldPriceWithPvm);
            double expensesCostPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productExpensesCostPrice);
            double result;
            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(soldPrice, expensesCostPrice);

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((soldPrice / 1.21 - expensesCostPrice), 4, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return _numberService.ParseDoubleToString(result);
        }
    }
}