using Market.Core.Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Entities.Identity
{
    public class ApplicationUserRole : IdentityUserRole<Guid>, IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}