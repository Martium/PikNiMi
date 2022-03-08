namespace PikNiMi.Models
{
    public class FullProductInfoCalculationModel
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public double ProductOriginalUnitPriceAtOriginalCurrency { get; set; }
        public double ProductQuantityPriceAtOriginalCurrency { get; set; }
        public double ProductUnitPriceInEuro { get; set; }
        public double ProductQuantityPriceInEuro { get; set; }
        public double TripExpenses { get; set; }
        public double ProductExpensesCostPrice { get; set; }
        public double ProductSoldPrice { get; set; }
        public double ProductPvm { get; set; }
        public double ProductSoldPriceWithPvm { get; set; }
        public int ProductSold { get; set; }
        public double ProductProfit { get; set; }
        public double Discount { get; set; }
        public double ProfitWant { get; set; }
        public string[] Search { get; set; }

    }
}
