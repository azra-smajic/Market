using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Dtos
{
    public class ProductCategoryIndexDto : BaseDto
    {
        public string? Name { get; set; }
        public string? MarketName { get; set; }
    }
}