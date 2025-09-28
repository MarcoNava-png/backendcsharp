using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Core.Common;
using WebApplication2.Core.DTOs;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Aspirante;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspiranteController : ControllerBase
    {
        private readonly IAspiranteService _aspiranteService;
        private readonly IMapper _mapper;

        public AspiranteController(IAspiranteService aspiranteService, IMapper mapper)
        {
            _aspiranteService = aspiranteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<AspiranteDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string filter = "")
        {
            var pagination = await _aspiranteService.GetAspirantes(page, pageSize, filter);

            var aspirantesDtos = _mapper.Map<IEnumerable<AspiranteDto>>(pagination.Items);

            var response = new PagedResult<AspiranteDto>
            {
                TotalItems = pagination.TotalItems,
                Items = [.. aspirantesDtos],
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AspiranteDto>> Post([FromBody] AspiranteSignupRequest request)
        {
            Direccion? direccion = null;
            
            if (request.Calle != null && request.NumeroExterior != null && request.CodigoPostalId != null)
            {
                direccion = new Direccion
                {
                    Calle = request.Calle,
                    NumeroExterior = request.NumeroExterior,
                    NumeroInterior = request.NumeroInterior,
                    CodigoPostalId = request.CodigoPostalId.Value
                };
            }

            var newAspirante = new Aspirante
            {
                IdPersonaNavigation = new Persona
                {
                    Nombre = request.Nombre,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    FechaNacimiento = request.FechaNacimiento,
                    IdGenero = request.GeneroId,
                    Curp = request.CURP,

                    Correo = request.Correo,
                    Telefono = request.Telefono,

                    IdDireccionNavigation = direccion,
                    IdEstadoCivil = request.IdEstadoCivil
                },
                IdPlan = request.PlanEstudiosId,
                IdMedioContacto = request.MedioContactoId,
                FechaRegistro = DateTime.UtcNow,
                Observaciones = request.Notas,
                TurnoId = request.HorarioId,
                IdAspiranteEstatus = request.AspiranteStatusId
            };

            try
            {
                var aspirante = await _aspiranteService.CrearAspirante(newAspirante);

                var aspiranteDto = _mapper.Map<AspiranteDto>(aspirante);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AspiranteUpdateRequest request)
        {
            Direccion? direccion = null;

            if (request.Calle != null && request.NumeroExterior != null && request.CodigoPostalId != null)
            {
                direccion = new Direccion
                {
                    Calle = request.Calle,
                    NumeroExterior = request.NumeroExterior,
                    NumeroInterior = request.NumeroInterior,
                    CodigoPostalId = request.CodigoPostalId.Value
                };
            }

            var newAspirante = new Aspirante
            {
                IdAspirante = request.AspiranteId,
                IdPersonaNavigation = new Persona
                {
                    Nombre = request.Nombre,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    FechaNacimiento = request.FechaNacimiento,
                    IdGenero = request.GeneroId,
                    Curp = request.CURP,

                    Correo = request.Correo,
                    Telefono = request.Telefono,

                    IdDireccionNavigation = direccion,
                },
                IdPlan = request.PlanEstudiosId,
                IdMedioContacto = request.MedioContactoId,
                FechaRegistro = DateTime.UtcNow,
                Observaciones = request.Notas,
                TurnoId = request.HorarioId,
                IdAspiranteEstatus = request.AspiranteStatusId
            };

            try
            {
                await _aspiranteService.ActualizarAspirante(newAspirante);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
