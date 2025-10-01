using Microsoft.AspNetCore.Mvc;
using WebApplication2.Core.DTOs;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Auth;
using WebApplication2.Services.Interfaces;

namespace WebApplication2
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var userLoginInfoDto = await _authService.Login(request.Email, request.Password);

            var response = new Response<UserLoginInfoDto>
            {
                Data = userLoginInfoDto
            };

            return Ok(response);
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            var userLoginInfoDto = await _authService.Signup(user, request.Password, request.Roles);

            return NoContent();
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileRequest request)
        {
            var newUser = new ApplicationUser
            {
                Email = request.Email,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                Telefono = request.Telefono,
                Biografia = request.Biografia
            };

            await _authService.UpdateUserProfile(newUser);

            return NoContent();
        }
    }
}
