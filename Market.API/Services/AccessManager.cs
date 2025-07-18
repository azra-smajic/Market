using Market.Core.Dtos;
using Market.Core.Entities.Identity;
using Market.Services.ApplicationUserService;
using Market.Shared.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Market.API.Services
{
    public class AccessManager : IAccessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserService _applicationUsersService;
        private readonly IConfiguration _configuration;

        public AccessManager(IApplicationUserService applicationUserService, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _applicationUsersService = applicationUserService;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<SuccessSignInData> SignInAsync(string username, string password)
        {
            var user = await _applicationUsersService.FindByUserNameAsync(username);
            if (user == null)
                throw new UserNotFoundException();

            if (!await _userManager.CheckPasswordAsync(new ApplicationUser() { PasswordHash = user.PasswordHash }, password))
                throw new WrongCredentialsException(user);

            var responseData = new SuccessSignInData()
            {
                Id = user.Id,
                Token = await CreateToken(user),
                PhotoUrl = user.Person.ProfilePhoto,
                FirstName = user.Person.FirstName,
                LastName = user.Person.LastName,
                ExpireTime = int.Parse(_configuration.GetSection(ConfigurationValues.TokenValidityInMinutes).Value),
                Roles = user.UserRoles?.ToList(),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return responseData;
        }

        private async Task<string> CreateToken(ApplicationUserDto user)
        {
            var claims = await ResetClaims(user);
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection(ConfigurationValues.TokenKey).Value));
            var signInCreds = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection(ConfigurationValues.TokenValidityInMinutes).Value)), signingCredentials: signInCreds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IEnumerable<Claim>> ResetClaims(ApplicationUserDto user)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Person.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.Person.LastName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            return identity.Claims;
        }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = null) : base(message)
        {
        }
    }

    public class WrongCredentialsException : Exception
    {
        public ApplicationUserDto User { get; set; }

        public WrongCredentialsException(ApplicationUserDto user, string message = null) : base(message)
        {
            User = user;
        }
    }
}