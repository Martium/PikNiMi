using System;
using System.Linq;
using PikNiMi.Interface.NumbersServiceInterface;
using PikNiMi.Models;

namespace PikNiMi.Forms.Service
{
    public class InvariantCultureCalculatorService : ICalculator
    {
        private readonly InvariantCultureNumberService _numberService;

        public InvariantCultureCalculatorService()
        {
            _numberService = new InvariantCultureNumberService();
        }

        private string[] ImplementSearchToSaveToDataBase(string search, FullProductInfoCalculationModel calculation)
        {
            string[] calculationValues = search.Split(new []{Environment.NewLine}, StringSplitOptions.None);

            calculationValues[8] = calculation.ProductQuantity.ToString();
            calculationValues[10] =
                _numberService.ParseDoubleToString(calculation.ProductOriginalUnitPriceAtOriginalCurrency);
            calculationValues[11] =
                _numberService.ParseDoubleToString(calculation.ProductQuantityPriceAtOriginalCurrency);
            calculationValues[12] = _numberService.ParseDoubleToString(calculation.ProductUnitPriceInEuro);
            calculationValues[13] = _numberService.ParseDoubleToString(calculation.ProductQuantityPriceInEuro);
            calculationValues[14] = _numberService.ParseDoubleToString(calculation.TripExpenses);
            calculationValues[15] = _numberService.ParseDoubleToString(calculation.ProductExpensesCostPrice);
            calculationValues[16] = _numberService.ParseDoubleToString(calculation.ProductSoldPrice);
            calculationValues[17] = _numberService.ParseDoubleToString(calculation.ProductPvm);
            calculationValues[18] = _numberService.ParseDoubleToString(calculation.ProductSoldPriceWithPvm);
            calculationValues[19] = calculation.ProductSold.ToString();
            calculationValues[20] = _numberService.ParseDoubleToString(calculation.ProductProfit);
            calculationValues[21] = _numberService.ParseDoubleToString(calculation.Discount);
            calculationValues = calculationValues.Take(calculationValues.Length - 1).ToArray();

            return calculationValues;
        }
        private static bool ValidateGivenNumbersIsMoreThanZero(double firstNumber, double secondNumber)
        {
            bool isFirstMoreThanZero = firstNumber > 0;
            bool isSecondMoreThanZero = secondNumber > 0;

            bool isBothMoreThanZero = isFirstMoreThanZero && isSecondMoreThanZero;

            return isBothMoreThanZero;
        }

        private double CountQuantityPrice(int quantity, double unitPrice)
        {
            double result;

            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(quantity, unitPrice);

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((quantity * unitPrice), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return result;
        }

        private double ConvertUnitPriceToEuroCurrency(double moneyCourse, double productOriginalUnitPriceAtOriginalCurrency)
        {
            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(moneyCourse, productOriginalUnitPriceAtOriginalCurrency);

            double result;

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((productOriginalUnitPriceAtOriginalCurrency / moneyCourse), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return result;
        }

        private double CountSoldPriceWithoutPvm(double productWantProfit, double productExpensesCostPrice)
        {
            double result = Math.Round((productWantProfit + productExpensesCostPrice), 2, MidpointRounding.ToEven);
            return result;
        }

        private double CountProductExpenses(double productPriceInEuro, double productTripExpenses)
        {
            double result = Math.Round((productPriceInEuro + productTripExpenses), 2, MidpointRounding.ToEven);
            return result;
        }

        private double CountJustPvm(double productSoldPrice)
        {
            double result;

            if (productSoldPrice > 0)
            {
                result = Math.Round((productSoldPrice * 0.21), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return result;
        }

        private double CountSoldPriceWithPvm(double productWantProfit, double productExpensesCostPrice)
        {
            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(productWantProfit, productExpensesCostPrice);

            double result;

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round(((productWantProfit + productExpensesCostPrice) * 1.21), 2,
                    MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return result;
        }

        private double CountProductProfit(double profitWant, int productSold, double discount)
        {
            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(profitWant, productSold);

            double result;

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((profitWant * productSold - discount), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return result;
        }

        private double CalculateWantProfitBySoldPriceWithPvm(double productSoldPriceWithPvm,
            double productExpensesCostPrice)
        {
            double result;
            bool isBothNumbersMoreThanZero = ValidateGivenNumbersIsMoreThanZero(productSoldPriceWithPvm, productExpensesCostPrice);

            if (isBothNumbersMoreThanZero)
            {
                result = Math.Round((productSoldPriceWithPvm / 1.21 - productExpensesCostPrice), 4, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return result;
        }

        private double CalculateWantProfitBySoldPriceWithoutPvm(double productSoldPrice,
            double productExpensesCostPrice)
        {
            double result = Math.Round((productSoldPrice - productExpensesCostPrice), 4, MidpointRounding.ToEven);
            return result;
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

            double result = Math.Round((wantProfit + expensesCostPrice), 2, MidpointRounding.ToEven);

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

            double result = Math.Round((priceInEuro + tripExpenses), 2, MidpointRounding.ToEven);

            return _numberService.ParseDoubleToString(result);
        }

        public string CalculateWantProfitBySoldPriceWithoutPvm(string productSoldPrice, string productExpensesCostPrice)
        {
            double soldPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productSoldPrice);
            double expensesCostPrice = _numberService.TryParseStringToDoubleNumberOrDefault(productExpensesCostPrice);
            double result = Math.Round((soldPrice - expensesCostPrice), 4, MidpointRounding.ToEven);

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

        public string CalculateProfit(string wantProfit, string discount, string productSold)
        {
            double wantProfitResult = _numberService.TryParseStringToDoubleNumberOrDefault(wantProfit);
            double discountResult = _numberService.TryParseStringToDoubleNumberOrDefault(discount);
            double productSoldResult = _numberService.TryParseStringToDoubleNumberOrDefault(productSold);

            double result = Math.Round((wantProfitResult * productSoldResult - discountResult), 2, MidpointRounding.ToEven);

            return _numberService.ParseDoubleToString(result);
        }

        public double CalculateTripExpensesByDate(int elementsByDate, string fullTripExpenses)
        {
            double tripExpenses = _numberService.TryParseStringToDoubleNumberOrDefault(fullTripExpenses);
            bool isTripExpenses = tripExpenses != 0;
            double result;

            if (isTripExpenses)
            {
                result = Math.Round((tripExpenses / elementsByDate), 2, MidpointRounding.ToEven);
            }
            else
            {
                result = default;
            }

            return result;

        }

        public FullProductInfoCalculationModel MakeFullCalculationsOfSpecificProduct(
            FullProductInfoMainInfoForCalculationsStartModel mainInfoForCalculations)
        {
            bool isPvmIncluded = _numberService.ChangeIntegerValueToBool(mainInfoForCalculations.IncludePvm);

            FullProductInfoCalculationModel calculations;

            if (isPvmIncluded)
            {
                calculations = CountByIncludePvm(mainInfoForCalculations);
            }
            else
            {
                calculations = CountByNotIncludedPvm(mainInfoForCalculations);
            }

            return calculations;
        }

        private FullProductInfoCalculationModel CountByIncludePvm(FullProductInfoMainInfoForCalculationsStartModel mainInfoForCalculations)
        {
            bool isCountByWantProfit = _numberService.ChangeIntegerValueToBool(mainInfoForCalculations.CountByWantProfit);

            var calculations = new FullProductInfoCalculationModel();

            if (isCountByWantProfit)
            {
                // main calculations

                calculations.ProductId = mainInfoForCalculations.ProductId;
                calculations.ProductQuantity = mainInfoForCalculations.ProductQuantity;

                calculations.ProductOriginalUnitPriceAtOriginalCurrency =
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency;

                calculations.ProductQuantityPriceAtOriginalCurrency = CountQuantityPrice(quantity:
                    mainInfoForCalculations.ProductQuantity,
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency);

                calculations.ProductUnitPriceInEuro = ConvertUnitPriceToEuroCurrency(moneyCourse: mainInfoForCalculations.MoneyCourse,
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency);

                calculations.ProductQuantityPriceInEuro = CountQuantityPrice(
                    quantity: mainInfoForCalculations.ProductQuantity, calculations.ProductUnitPriceInEuro);

                calculations.TripExpenses = mainInfoForCalculations.TripExpenses;

                calculations.ProductExpensesCostPrice = CountProductExpenses(
                    productPriceInEuro: calculations.ProductUnitPriceInEuro, mainInfoForCalculations.TripExpenses);

                calculations.ProductSold = mainInfoForCalculations.ProductSold;
                calculations.Discount = mainInfoForCalculations.Discount;

                // validate calculations

                calculations.ProductSoldPrice = CountSoldPriceWithoutPvm(
                    productWantProfit: mainInfoForCalculations.ProfitWant, calculations.ProductExpensesCostPrice);

                calculations.ProductPvm = CountJustPvm(calculations.ProductSoldPrice);

                calculations.ProductSoldPriceWithPvm = CountSoldPriceWithPvm(
                    productWantProfit: mainInfoForCalculations.ProfitWant, calculations.ProductExpensesCostPrice);

                calculations.ProductProfit = CountProductProfit(profitWant: mainInfoForCalculations.ProfitWant,
                    productSold: mainInfoForCalculations.ProductSold, mainInfoForCalculations.Discount);

                calculations.ProfitWant = mainInfoForCalculations.ProfitWant;

            }
            else
            {
                calculations.ProductId = mainInfoForCalculations.ProductId;
                calculations.ProductQuantity = mainInfoForCalculations.ProductQuantity;

                calculations.ProductOriginalUnitPriceAtOriginalCurrency =
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency;

                calculations.ProductQuantityPriceAtOriginalCurrency = CountQuantityPrice(quantity:
                    mainInfoForCalculations.ProductQuantity,
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency);

                calculations.ProductUnitPriceInEuro = ConvertUnitPriceToEuroCurrency(moneyCourse: mainInfoForCalculations.MoneyCourse,
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency);

                calculations.ProductQuantityPriceInEuro = CountQuantityPrice(
                    quantity: mainInfoForCalculations.ProductQuantity, calculations.ProductUnitPriceInEuro);

                calculations.TripExpenses = mainInfoForCalculations.TripExpenses;

                calculations.ProductExpensesCostPrice = CountProductExpenses(
                    productPriceInEuro: calculations.ProductUnitPriceInEuro, mainInfoForCalculations.TripExpenses);

                calculations.ProductSold = mainInfoForCalculations.ProductSold;
                calculations.Discount = mainInfoForCalculations.Discount;

                // validate calculations

                calculations.ProfitWant = CalculateWantProfitBySoldPriceWithPvm(
                    productSoldPriceWithPvm: mainInfoForCalculations.ProductSoldPriceWithPvm,
                    calculations.ProductExpensesCostPrice);

                calculations.ProductSoldPrice = CountSoldPriceWithoutPvm(productWantProfit: calculations.ProfitWant,
                    calculations.ProductExpensesCostPrice);

                calculations.ProductPvm = CountJustPvm(calculations.ProductSoldPrice);

                calculations.ProductProfit = CountProductProfit(profitWant: calculations.ProfitWant,
                    productSold: mainInfoForCalculations.ProductSold, mainInfoForCalculations.Discount);

                calculations.ProductSoldPriceWithPvm = mainInfoForCalculations.ProductSoldPriceWithPvm;
            }

            // todo search update 
            calculations.Search = ImplementSearchToSaveToDataBase(mainInfoForCalculations.Search, calculations);

            return calculations;
        }

        private FullProductInfoCalculationModel CountByNotIncludedPvm(
            FullProductInfoMainInfoForCalculationsStartModel mainInfoForCalculations)
        {
            bool isCountByWantProfit = _numberService.ChangeIntegerValueToBool(mainInfoForCalculations.CountByWantProfit);

            var calculations = new FullProductInfoCalculationModel();

            if (isCountByWantProfit)
            {
                // main calculations

                calculations.ProductId = mainInfoForCalculations.ProductId;
                calculations.ProductQuantity = mainInfoForCalculations.ProductQuantity;

                calculations.ProductOriginalUnitPriceAtOriginalCurrency =
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency;

                calculations.ProductQuantityPriceAtOriginalCurrency = CountQuantityPrice(quantity:
                    mainInfoForCalculations.ProductQuantity,
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency);

                calculations.ProductUnitPriceInEuro = ConvertUnitPriceToEuroCurrency(moneyCourse: mainInfoForCalculations.MoneyCourse,
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency);

                calculations.ProductQuantityPriceInEuro = CountQuantityPrice(
                    quantity: mainInfoForCalculations.ProductQuantity, calculations.ProductUnitPriceInEuro);

                calculations.TripExpenses = mainInfoForCalculations.TripExpenses;

                calculations.ProductExpensesCostPrice = CountProductExpenses(
                    productPriceInEuro: calculations.ProductUnitPriceInEuro, mainInfoForCalculations.TripExpenses);

                calculations.ProductSold = mainInfoForCalculations.ProductSold;
                calculations.Discount = mainInfoForCalculations.Discount;

                //valid calculations

                calculations.ProductSoldPrice = CountSoldPriceWithoutPvm(
                    productWantProfit: mainInfoForCalculations.ProfitWant, calculations.ProductExpensesCostPrice);

                calculations.ProductPvm = 0;

                calculations.ProductSoldPriceWithPvm = 0;

                calculations.ProductProfit = CountProductProfit(profitWant: mainInfoForCalculations.ProfitWant,
                    productSold: mainInfoForCalculations.ProductSold, mainInfoForCalculations.Discount);

                calculations.ProfitWant = mainInfoForCalculations.ProfitWant;

            }
            else
            {
                // main calculations 

                calculations.ProductId = mainInfoForCalculations.ProductId;
                calculations.ProductQuantity = mainInfoForCalculations.ProductQuantity;

                calculations.ProductOriginalUnitPriceAtOriginalCurrency =
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency;

                calculations.ProductQuantityPriceAtOriginalCurrency = CountQuantityPrice(quantity:
                    mainInfoForCalculations.ProductQuantity,
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency);

                calculations.ProductUnitPriceInEuro = ConvertUnitPriceToEuroCurrency(moneyCourse: mainInfoForCalculations.MoneyCourse,
                    mainInfoForCalculations.ProductOriginalUnitPriceAtOriginalCurrency);

                calculations.ProductQuantityPriceInEuro = CountQuantityPrice(
                    quantity: mainInfoForCalculations.ProductQuantity, calculations.ProductUnitPriceInEuro);

                calculations.TripExpenses = mainInfoForCalculations.TripExpenses;

                calculations.ProductExpensesCostPrice = CountProductExpenses(
                    productPriceInEuro: calculations.ProductUnitPriceInEuro, mainInfoForCalculations.TripExpenses);

                calculations.ProductSold = mainInfoForCalculations.ProductSold;
                calculations.Discount = mainInfoForCalculations.Discount;

                // valid calculations 

                calculations.ProfitWant = CalculateWantProfitBySoldPriceWithoutPvm(
                    productSoldPrice: mainInfoForCalculations.ProductSoldPrice, calculations.ProductExpensesCostPrice);

                calculations.ProductPvm = 0;
                calculations.ProductSoldPriceWithPvm = 0;

                calculations.ProductProfit = CountProductProfit(profitWant: calculations.ProfitWant,
                    productSold: mainInfoForCalculations.ProductSold, mainInfoForCalculations.Discount);
                calculations.ProductSoldPrice = mainInfoForCalculations.ProductSoldPrice;

            }

            // todo searchUpdate
            calculations.Search = ImplementSearchToSaveToDataBase(mainInfoForCalculations.Search, calculations);

            return calculations;
        }
    }
}
