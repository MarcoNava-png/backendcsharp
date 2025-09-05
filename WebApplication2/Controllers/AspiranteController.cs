using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Configuration.Constants;
using WebApplication2.Core.Common;
using WebApplication2.Core.DTOs;
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
        private readonly IMapper _mapper;

        public AspiranteController(IAspiranteService aspiranteService, IAuthService authService, IMapper mapper)
        {
            _aspiranteService = aspiranteService;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<AspiranteProgramaDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var pagination = await _aspiranteService.GetAspirantes(page, pageSize);

            var aspirantesDto = _mapper.Map<IEnumerable<AspiranteProgramaDto>>(pagination.Items);

            var response = new PagedResult<AspiranteProgramaDto>
            {
                TotalItems = pagination.TotalItems,
                Items = [.. aspirantesDto],
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AspiranteProgramaDto>> Post([FromBody] AspiranteSignupRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            try
            {
                var signupResponse = await _authService.Signup(user, request.Password, [Rol.ALUMNO]);

                var newAspirante = new AspirantePrograma
                {
                    Aspirante = new Aspirante
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
                    },
                    AspiranteProgramaEstatusId = 1,
                    FechaPostulacion = DateTime.UtcNow,
                    ProgramaId = request.ProgramaId,
                };

                var aspirante = await _aspiranteService.CrearAspirante(newAspirante);

                var aspiranteDto = _mapper.Map<AspiranteProgramaDto>(aspirante);

                return Ok(aspiranteDto);
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
