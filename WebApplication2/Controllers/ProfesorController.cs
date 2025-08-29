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
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public ProfesorController(IProfesorService profesorService, IAuthService authService, IMapper mapper)
        {
            _profesorService = profesorService;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<ProfesorDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var pagination = await _profesorService.GetProfesores(page, pageSize);

            var profesoresDto = _mapper.Map<IEnumerable<ProfesorDto>>(pagination.Items);

            var response = new PagedResult<ProfesorDto>
            {
                TotalItems = pagination.TotalItems,
                Items = [.. profesoresDto],
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ProfesorDto>> Profesor([FromBody] ProfesorSignupRequest request)
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
                        Estatus = StatusEnum.Activo,
                        Direccion = new Direccion
                        {
                            Calle = request.Calle,
                            Numero = request.Numero,
                            CodigoPostalId = request.CodigoPostalId,
                        }
                    }
                };

                var profesor = await _profesorService.CrearProfesor(newProfesor);

                var profesorDto = _mapper.Map<ProfesorDto>(profesor);

                return Ok(profesorDto);
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
