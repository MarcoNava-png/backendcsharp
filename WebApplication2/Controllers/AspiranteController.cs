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
    public class AspiranteController : ControllerBase
    {
        private readonly IAspiranteService _aspiranteService;
        private readonly IAuthService _authService;

        public AspiranteController(IAspiranteService aspiranteService, IAuthService authService)
        {
            _aspiranteService = aspiranteService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<Aspirante>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var aspirantes = await _aspiranteService.GetAspirantes(page, pageSize);

            return Ok(aspirantes);
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
                var signupResponse = await _authService.Signup(user, request.Password, [Rol.ALUMNO]);

                var newAspirante = new Aspirante
                {
                    Persona = new Persona
                    {
                        Nombre = request.Nombre,
                        ApellidoPaterno = request.ApellidoPaterno,
                        ApellidoMaterno = request.ApellidoMaterno,
                        FechaNacimiento = request.FechaNacimiento,
                        PersonaGeneroId = request.PersonaGeneroId,
                        UserId = signupResponse.Id,
                        Estatus = StatusEnum.Activo,
                        Direccion = new Direccion
                        {
                            Calle = request.Calle,
                            Numero = request.Numero,
                            CodigoPostalId = request.CodigoPostalId,
                        }
                    },
                    Estatus = Core.Enums.AspiranteStatusEnum.Registrado,
                    FechaRegistro = DateTime.UtcNow
                };

                var aspirante = await _aspiranteService.CrearAspirante(newAspirante);

                return Ok(aspirante);
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
                await _aspiranteService.EliminarAspirante(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
