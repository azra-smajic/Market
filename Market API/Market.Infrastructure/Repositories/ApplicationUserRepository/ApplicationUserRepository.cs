using AutoMapper;
using Dapper;
using Market.Core.Dto;
using Market.Core.Dtos;
using Market.Core.Entities.Identity;
using Market.Core.SearchObjects;
using Market.Infrastructure.Database;
using Market.Infrastructure.Repositories.BaseRepository;

namespace Market.Infrastructure.Repositories.ApplicationUserRepository
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser, Guid>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IMapper mapper, DatabaseContext databaseContext) : base(mapper, databaseContext)
        {
        }

        public async Task<ApplicationUserDto> FindByUserNameAsync(string pUserName)
        {
            var query = "SELECT * FROM fn_users_getbyusername(@pUserName);" +
                            "SELECT * FROM fn_person_getbyusername(@pUserName);" +
                            "SELECT * FROM fn_userroles_getbyusername(@pUserName);";

            using (var result = await DbConnection.QueryMultipleAsync(query, new DynamicParameters(new { pUserName })))
            {
                var user = await result.ReadFirstOrDefaultAsync<ApplicationUserDto>();
                if (user != null)
                {
                    user.Person = await result.ReadFirstOrDefaultAsync<PersonDto>();

                    user.UserRoles = (await result.ReadAsync<ApplicationUserRoleDto>())?.ToList();
                }
                return user;
            }
        }

        public Task<ApplicationUser> GetByIdAsync(Guid id, bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> GetDtoByIdAsync(int pId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUserIndexDto>> GetUsersForPaginationAsync(BaseSearchObject searchObj, int pageSize, int offeset)
        {
            throw new NotImplementedException();
        }
    }
}