using Market.Core.Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;

namespace Market.Core.Entities.Identity
{
    public class ApplicationRole : IdentityRole<Guid>, IBaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ApplicationUserRole> Roles { get; set; }
    }
}