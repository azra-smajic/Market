using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Entities.BaseEntity
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime? ModifiedAt { get; set; }
        DateTime CreatedAt { get; set; }
    }
}