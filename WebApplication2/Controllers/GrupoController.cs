//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication2.Core.Common;
//using WebApplication2.Core.DTOs;
//using WebApplication2.Core.Models;
//using WebApplication2.Core.Requests.Grupo;
//using WebApplication2.Services.Interfaces;

//namespace WebApplication2.Controllers
//{
//    [Route("api/grupos")]
//    [ApiController]
//    public class GrupoController : ControllerBase
//    {
//        private readonly IGrupoService _grupoService;
//        private readonly IMapper _mapper;

//        public GrupoController(IGrupoService grupoService, IMapper mapper)
//        {
//            _grupoService = grupoService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<PagedResult<GrupoDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
//        {
//            var pagination = await _grupoService.GetGrupos(page, pageSize);

//            var gruposDto = _mapper.Map<IEnumerable<GrupoDto>>(pagination.Items);

//            var response = new PagedResult<GrupoDto>
//            {
//                TotalItems = pagination.TotalItems,
//                Items = [.. gruposDto],
//                PageNumber = pagination.PageNumber,
//                PageSize = pagination.PageSize
//            };

//            return Ok(response);
//        }

//        [HttpPost]
//        public async Task<ActionResult<GrupoDto>> Grupo([FromBody] GrupoRequest request)
//        {
//            try
//            {
//                var newGrupo = new Grupo
//                {
//                    Clave = request.Clave,
//                    PlanEstudiosId = request.PlanEstudiosId,
//                    Semestre = request.Semestre,
//                    Periodicidad = request.Periodicidad,
//                    Status = StatusEnum.Activo
//                };

//                var grupo = await _grupoService.CrearGrupo(newGrupo);

//                var grupoDto = _mapper.Map<GrupoDto>(grupo);

//                return Ok(grupoDto);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            try
//            {
//                await _grupoService.EliminarGrupo(id);

//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }
//    }
//}
