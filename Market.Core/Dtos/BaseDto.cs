using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Core.Entities.BaseEntity;

namespace Market.Core.Dtos
{
    public class BaseDto : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int TotalRecordsCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}