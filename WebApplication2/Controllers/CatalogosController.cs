using Microsoft.AspNetCore.Mvc;
using WebApplication2.Core.Models;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogosController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet("generos")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
            var generos = await _catalogoService.GetGeneros();

            return Ok(generos);
        }

        [HttpGet("horarios")]
        public async Task<ActionResult<IEnumerable<Horario>>> GetHorarios()
        {
            var horarios = await _catalogoService.GetTurnos();

            return Ok(horarios);
        }
    }
}
