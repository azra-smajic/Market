using Market.Core.Dtos;
using Market.Core.Entities.Identity;
using Market.Core.SearchObjects;
using Market.Infrastructure.Repositories.BaseRepository;

namespace Market.Infrastructure.Repositories.ApplicationUserRepository
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser, Guid>
    {
        Task<ApplicationUserDto> FindByUserNameAsync(string pUserName);

        Task<ApplicationUserDto> GetDtoByIdAsync(int pId);

        Task<List<ApplicationUserIndexDto>> GetUsersForPaginationAsync(BaseSearchObject searchObj, int pageSize, int offeset);
    }
}