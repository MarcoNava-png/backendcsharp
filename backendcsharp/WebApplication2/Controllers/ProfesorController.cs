using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Configuration.Constants;
using WebApplication2.Core.Common;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Auth;
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
        public async Task<ActionResult<PagedResult<Profesor>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var profesores = await _profesorService.GetProfesores(page, pageSize);

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
                        Estatus = StatusEnum.Activo
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _profesorService.EliminarProfesor(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
