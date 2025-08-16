using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Configuration.Constants;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Auth;
using WebApplication2.Services;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;
        private readonly IAuthService _authService;

        public ProfesorController(IProfesorService profesorService, IAuthService authService)
        {
            _profesorService = profesorService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profesores = await _profesorService.ListProfesor();

            return Ok(profesores);
        }

        [HttpPost]
        public async Task<IActionResult> Profesor([FromBody] ProfesorSignupRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            try
            {
                var signupResponse = await _authService.Signup(user, request.Password, [Rol.DOCENTE]);

                var newProfesor = new Profesor
                {
                    Especialidad = request.Especialidad,
                    Persona = new Persona
                    {
                        Nombre = request.Nombre,
                        ApellidoPaterno = request.ApellidoPaterno,
                        ApellidoMaterno = request.ApellidoMaterno,
                        FechaNacimiento = request.FechaNacimiento,
                        PersonaGeneroId = request.PersonaGeneroId,
                        UserId = signupResponse.Id,
                    }
                };

                var profesor = await _profesorService.CrearProfesor(newProfesor);

                return Ok(profesor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
