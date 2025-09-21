//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication2.Core.Common;
//using WebApplication2.Core.DTOs;
//using WebApplication2.Core.Requests.Auth;
//using WebApplication2.Services.Interfaces;

//namespace WebApplication2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PlanEstudiosController : ControllerBase
//    {
//        private readonly IPlanEstudioService _planEstudioService;
//        private readonly IMapper _mapper;

//        public PlanEstudiosController(IPlanEstudioService planEstudioService, IMapper mapper)
//        {
//            _planEstudioService = planEstudioService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<PagedResult<PlanEstudioDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
//        {
//            var pagination = await _planEstudioService.GetPlanesEstudios(page, pageSize);

//            var planesEstudiosDto = _mapper.Map<IEnumerable<PlanEstudioDto>>(pagination.Items);

//            var response = new PagedResult<PlanEstudioDto>
//            {
//                TotalItems = pagination.TotalItems,
//                Items = [.. planesEstudiosDto],
//                PageNumber = pagination.PageNumber,
//                PageSize = pagination.PageSize
//            };

//            return Ok(response);
//        }

//        [HttpPost]
//        public async Task<ActionResult<PlanEstudioDto>> Post([FromBody] DirectorSignupRequest request)
//        {
//            throw new NotImplementedException();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            try
//            {
//                await _planEstudioService.EliminarPlanEstudios(id);

//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }
//    }
//}
