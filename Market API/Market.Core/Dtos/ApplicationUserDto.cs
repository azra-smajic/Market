using Market.Core.Dto;
using Market.Core.Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Market.Core.Dtos
{
    public class ApplicationUserDto : IdentityUser<Guid>, IBaseEntity
    {
        public int TotalRecordsCount { get; set; }
        public int PersonId { get; set; }
        public PersonDto Person { get; set; }
        public bool OnlineReservation { get; set; }
        public string JobDescription { get; set; }
        public int ApplicationUserRoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public List<ApplicationUserRoleDto> UserRoles { get; set; } = new List<ApplicationUserRoleDto>();
    }
}