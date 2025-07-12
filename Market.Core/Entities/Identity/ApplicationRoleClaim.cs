using Market.Core.Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;

namespace Market.Core.Entities.Identity
{
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>, IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}