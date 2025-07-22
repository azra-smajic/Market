using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Entities
{
    public class ProductCategory : BaseEntity.BaseEntity
    {
        public string? Name { get; set; }
        public Guid MarketId { get; set; }
        public Market.Entities.MarketEntity Market { get; set; }
    }
}