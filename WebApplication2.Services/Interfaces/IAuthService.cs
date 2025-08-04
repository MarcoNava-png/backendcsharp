using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Core.Models;
using WebApplication2.Core.DTOs;


namespace WebApplication2.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser> Signup(ApplicationUser user, string password, string role);
        Task<UserLoginInfoDto> Login(string username, string password);
        Task RequestPasswordReset(string email);
        Task ResetPassword(string email, string newPassword, string token);
    }
}
