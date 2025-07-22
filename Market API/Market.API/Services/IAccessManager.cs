using Market.Core.Dtos;

namespace Market.API.Services
{
    public interface IAccessManager
    {
        Task<SuccessSignInData> SignInAsync(string email, string password);
    }
}