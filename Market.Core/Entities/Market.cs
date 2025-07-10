using Market.Core.Entities.BaseEntity;

namespace Market.Entities
{
    public class MarketEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}