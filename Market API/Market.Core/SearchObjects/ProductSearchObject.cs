using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.SearchObjects
{
    public class ProductSearchObject : BaseSearchObject
    {
        public Guid? ProductCategoryId { get; set; }
        public string? Sku { get; set; }
    }
}