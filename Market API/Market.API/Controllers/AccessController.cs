using Market.API.Services;
using Market.Core.Dtos;
using Market.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IAccessManager accessManager;

        public AccessController(IAccessManager accessManager)
        {
            this.accessManager = accessManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            try
            {
                if (!loginDto.Username.IsSet() || !loginDto.Password.IsSet())
                    return BadRequest();
                return Ok(await accessManager.SignInAsync(loginDto.Username, loginDto.Password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}