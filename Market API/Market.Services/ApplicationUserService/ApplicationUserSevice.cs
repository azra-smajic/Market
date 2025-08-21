using Market.Core.Dtos;
using Market.Core.Entities.Identity;
using Market.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Services.ApplicationUserService
{
    public class ApplicationUserSevice : IApplicationUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserSevice(IUnitOfWork unitOfWork,
          IPasswordHasher<ApplicationUser> passwordHasher, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
            _passwordHasher = passwordHasher;
            _userManager = userManager;
        }

        public Task<ApplicationUserDto> AddAsync(ApplicationUserDto entityDto)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> FindByUserNameAsync(string pUserName)
        {
            return _unitOfWork.ApplicationUserRepository.FindByUserNameAsync(pUserName);
        }

        public Task<List<ApplicationUserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByIdAsync(Guid id, bool isSoft = true)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}