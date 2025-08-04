using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
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
    }
}
