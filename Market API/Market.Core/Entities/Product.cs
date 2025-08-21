using Market.Entities;

namespace Market.Core.Entities
{
    public class Product : BaseEntity.BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public Guid ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public Guid MarketId { get; set; }
        public virtual MarketEntity Market { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxRate { get; set; }
        public string Tags { get; set; }
        public string Attributes { get; set; }
        public string Status { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}