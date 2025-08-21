namespace Market.Core.Entities
{
    public class ProductImage : BaseEntity.BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}