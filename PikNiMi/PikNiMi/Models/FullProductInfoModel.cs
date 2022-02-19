namespace PikNiMi.Models
{
    public class FullProductInfoModel
    {
        public int ProductId { get; set; }
        public string ProductReceiptDate { get; set; }
        public string ProductType { get; set; }

        public string ProductDescription { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public string ProductCare { get; set; }
        public string ProductMadeStuff { get; set; }
        public string ProductMadeIn { get; set; }

        public int? ProductQuantity { get; set; }
        public int? ProductQuantityLeft { get; set; }

        public double? ProductOriginalUnitPriceAtOriginalCurrency { get; set; }
        public double? ProductQuantityPriceAtOriginalCurrency { get; set; }
        public double? ProductUnitPriceInEuro { get; set; }
        public double? ProductQuantityPriceInEuro { get; set; }
        public double? TripExpenses { get; set; }
        public double? ProductExpensesCostPrice { get; set; }
        public double? ProductSoldPrice { get; set; }
        public double? ProductPvm { get; set; }
        public double? ProductSoldPriceWithPvm { get; set; }
        public int? ProductSold { get; set; }
        public double? ProductProfit { get; set; }
        public double? Discount { get; set; }
    }
}
