using Microsoft.AspNetCore.Mvc;
using WebApplication2.Core.Common;
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

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<Estudiante>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var profesores = await _estudianteService.GetEstudiantes(page, pageSize);

            return Ok(profesores);
        }

        [HttpPost]
        public async Task<IActionResult> Estudiante([FromBody] EstudianteSignupRequest request)
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

                var profesor = await _estudianteService.CrearEstudiante(newEstudiante);

                return Ok(profesor);
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
