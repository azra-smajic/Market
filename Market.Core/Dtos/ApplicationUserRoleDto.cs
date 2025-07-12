using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Core.Dtos
{
    public class ApplicationUserRoleDto : BaseDto
    {
        public int RoleId { get; set; }
        public ApplicationRoleDto Role { get; set; }
        public ApplicationUserDto User { get; set; }
        public int UserId { get; set; }
    }
}