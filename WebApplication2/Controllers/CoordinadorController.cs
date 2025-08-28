using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Configuration.Constants;
using WebApplication2.Core.Common;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Auth;
using WebApplication2.Services;
using WebApplication2.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/coordinadores")]
    [ApiController]
    public class CoordinadorController : ControllerBase
    {
        private readonly ICoordinadorService _coordinadorService;
        private readonly IAuthService _authService;

        public CoordinadorController(ICoordinadorService coordinadorService, IAuthService authService)
        {
            _coordinadorService = coordinadorService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<Coordinador>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var coordinadores = await _coordinadorService.GetCoordinadores(page, pageSize);

            return Ok(coordinadores);
        }

        [HttpPost]
        public async Task<ActionResult<Director>> Post([FromBody] CoordinadorSignupRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            try
            {
                var signupResponse = await _authService.Signup(user, request.Password, [Rol.COORDINADOR]);

                var newCoordinador = new Coordinador
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

                var coordinador = await _coordinadorService.CrearCoordinador(newCoordinador);

                return Ok(coordinador);
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
                await _coordinadorService.EliminarCoordinador(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
