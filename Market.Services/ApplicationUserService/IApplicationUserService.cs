using Market.Core.Dtos;
using Market.Services.BaseService;

namespace Market.Services.ApplicationUserService
{
    public interface IApplicationUserService : IBaseService<ApplicationUserDto>
    {
        Task<ApplicationUserDto> FindByUserNameAsync(string pUserName);
    }
}