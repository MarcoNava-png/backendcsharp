using Microsoft.AspNetCore.Identity;
using WebApplication2.Core.DTOs;


namespace WebApplication2.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityUser> Signup(IdentityUser user, string password, List<string> roles);
        Task<UserLoginInfoDto> Login(string username, string password);
        Task RequestPasswordReset(string email);
        Task ResetPassword(string email, string newPassword, string token);
        Task DeleteUser(string email);
    }
}
