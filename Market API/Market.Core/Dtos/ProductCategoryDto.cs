using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Dtos
{
    public class ProductCategoryDto : BaseDto
    {
        public string? Name { get; set; }
        public Guid MarketId { get; set; }
    }
}