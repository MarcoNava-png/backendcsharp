using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public EstudianteController(IEstudianteService estudianteService, IMapper mapper)
        {
            _estudianteService = estudianteService;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<ActionResult<EstudianteDto>> Estudiante([FromBody] EstudianteSignupRequest request)
        {
            try
            {
                var newEstudiante = new Estudiante
                {
                    Id = request.Matricula,
                    PersonaId = request.PersonaId,
                    FechaIngreso = DateTime.UtcNow,
                    NivelEducativoId = request.NivelEducativoId,
                    StatusAcademico = Core.Enums.EstudianteStatusAcademicoEnum.Regular,
                    Status = StatusEnum.Activo
                };

                var estudiante = await _estudianteService.CrearEstudiante(newEstudiante);

                var estudianteDto = _mapper.Map<EstudianteDto>(estudiante);

                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string matricula)
        {
            try
            {
                await _estudianteService.EliminarEstudiante(matricula);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
