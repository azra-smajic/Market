using Market.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Dtos
{
    public class ProductImageDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }
    }
}