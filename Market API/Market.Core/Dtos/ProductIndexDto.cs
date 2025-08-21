namespace Market.Core.Dtos
{
    public class ProductIndexDto : BaseDto
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public Guid MarketId { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxRate { get; set; }
        public string Status { get; set; }
    }
}