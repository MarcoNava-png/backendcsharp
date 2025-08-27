using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Configuration.Constants;
using WebApplication2.Core.Common;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Auth;
using WebApplication2.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/directores")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        private readonly IAuthService _authService;

        public DirectorController(IDirectorService directorService, IAuthService authService)
        {
            _directorService = directorService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<Director>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var directores = await _directorService.GetDirectores(page, pageSize);

            return Ok(directores);
        }

        [HttpPost]
        public async Task<ActionResult<Director>> Post([FromBody] DirectorSignupRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            try
            {
                var signupResponse = await _authService.Signup(user, request.Password, [Rol.DIRECTOR]);

                var newDirector = new Director
                {
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

                var director = await _directorService.CrearDirector(newDirector);

                return Ok(director);
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
                await _directorService.EliminarDirector(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
