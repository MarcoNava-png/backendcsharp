using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Configuration.Constants;
using WebApplication2.Core.Common;
using WebApplication2.Core.DTOs;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Estudiante;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public EstudianteController(IEstudianteService estudianteService, IMapper mapper, IAuthService authService)
        {
            _estudianteService = estudianteService;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<EstudianteDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var pagination = await _estudianteService.GetEstudiantes(page, pageSize);

            var estudiantesDto = _mapper.Map<IEnumerable<EstudianteDto>>(pagination.Items);

            var response = new PagedResult<EstudianteDto>
            {
                TotalItems = pagination.TotalItems,
                Items = [.. estudiantesDto],
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteDetalleDto>> Get(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteDetalle(id);

            var estudianteDto = _mapper.Map<EstudianteDetalleDto>(estudiante);

            return Ok(estudianteDto);
        }

        [HttpPost]
        public async Task<ActionResult<EstudianteDto>> Estudiante([FromBody] EstudianteRequest request)
        {
            var user = new IdentityUser
            {
                UserName = $"{request.Matricula}@uni.mx",
                Email = $"{request.Matricula}@uni.mx",
            };

            try
            {
                await _authService.Signup(user, request.Matricula, [Rol.ALUMNO]);

                var usuario = await _authService.GetUserByEmail(user.Email);

                var newEstudiante = new Estudiante
                {
                    Matricula = request.Matricula,
                    IdPersona = request.IdPersona,
                    Email = $"{request.Matricula}@uni.mx",
                    FechaIngreso = DateOnly.FromDateTime(DateTime.Now),
                    IdPlanActual = request.IdPlanActual,
                    Activo = true,
                    UsuarioId = usuario.Id
                };

                var estudiante = await _estudianteService.CrearEstudiante(newEstudiante);

                var estudianteDto = _mapper.Map<EstudianteDto>(estudiante);

                return Ok(estudianteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string matricula)
        //{
        //    try
        //    {
        //        await _estudianteService.EliminarEstudiante(matricula);

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
