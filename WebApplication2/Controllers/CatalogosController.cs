using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Models;
using WebApplication2.Data.DbContexts;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogosController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("generos")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
            var generos = await _dbContext.Genero.ToListAsync();

            return Ok(generos);
        }

        [HttpGet("horarios")]
        public async Task<ActionResult<IEnumerable<Horario>>> GetHorarios()
        {
            var horarios = await _dbContext.Turno.ToListAsync();

            return Ok(horarios);
        }

        [HttpGet("dias-semana")]
        public async Task<ActionResult<IEnumerable<DiaSemana>>> GetDiasSemana()
        {
            var diasSemana = await _dbContext.DiaSemana.ToListAsync();

            return Ok(diasSemana);
        }

        [HttpGet("estado-civil")]
        public async Task<ActionResult<IEnumerable<EstadoCivil>>> GetEstadoCivil()
        {
            var estadoCivil = await _dbContext.EstadoCivil.ToListAsync();

            return Ok(estadoCivil);
        }

        [HttpGet("aspirante-status")]
        public async Task<ActionResult<IEnumerable<AspiranteEstatus>>> GetAspiranteStatus()
        {
            var aspiranteEstatus = await _dbContext.AspiranteEstatus.ToListAsync();

            return Ok(aspiranteEstatus);
        }

        [HttpGet("medios-contacto")]
        public async Task<ActionResult<IEnumerable<MedioContacto>>> GetMediosContacto()
        {
            var mediosContacto = await _dbContext.MedioContacto.ToListAsync();

            return Ok(mediosContacto);
        }

        [HttpGet("turnos")]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos()
        {
            var turnos = await _dbContext.Turno.ToListAsync();

            return Ok(turnos);
        }
    }
}
