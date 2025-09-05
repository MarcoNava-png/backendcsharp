using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Core.Common;
using WebApplication2.Core.DTOs;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Inscripcion;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/inscripciones")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {
        private readonly IInscripcionService _inscripcionService;
        private readonly IMapper _mapper;

        public InscripcionController(IInscripcionService inscripcionService, IMapper mapper)
        {
            _inscripcionService = inscripcionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<InscripcionDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var pagination = await _inscripcionService.GetInscripciones(page, pageSize);

            var inscripcionsDto = _mapper.Map<IEnumerable<InscripcionDto>>(pagination.Items);

            var response = new PagedResult<InscripcionDto>
            {
                TotalItems = pagination.TotalItems,
                Items = [.. inscripcionsDto],
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<InscripcionDto>> Inscripcion([FromBody] InscripcionRequest request)
        {
            try
            {
                var newInscripcion = new Inscripcion
                {
                    EstudianteId = request.Matricula,
                    Fecha = DateTime.UtcNow,
                    PlanEstudiosId = request.PlanEstudiosId,
                };

                var inscripcion = await _inscripcionService.CrearInscripcion(newInscripcion);

                var inscripcionDto = _mapper.Map<InscripcionDto>(inscripcion);

                return Ok(inscripcion);
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
                await _inscripcionService.EliminarInscripcion(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
