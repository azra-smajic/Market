using Market.Core.Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;

namespace Market.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>, IBaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public Person Person { get; set; }
        public ICollection<ApplicationUserRole> Roles { get; set; }
    }
}