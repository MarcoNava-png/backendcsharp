// Controllers/PersonasController.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.DTOs;               // PersonaCreate/Update/View, ProfesorCreate, AdministrativoCreate
using WebApplication2.Core.DTOs.Students;      // EstudianteCreateFromPersonaDto
using WebApplication2.Data.DbContexts;         // ApplicationDbContext
using WebApplication2.NewFolder;               // IPersonaService

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IPersonaService _svc;
        private readonly IMapper _mapper;

        public PersonasController(ApplicationDbContext db, IPersonaService svc, IMapper mapper)
        {
            _db = db;
            _svc = svc;
            _mapper = mapper;
        }

        // GET /api/personas?q=...&page=1&pageSize=20
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? q, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var list = await _svc.SearchAsync(q, page, pageSize);

            var result = new List<PersonaViewDto>();
            foreach (var p in list)
            {
                var dto = _mapper.Map<PersonaViewDto>(p);
                dto.EsProfesor = await _db.Profesores.AnyAsync(x => x.PersonaId == p.Id);
                dto.EsEstudiante = await _db.Estudiantes.AnyAsync(x => x.PersonaId == p.Id);
                // dto.EsAdministrativo = await _db.Administrativos.AnyAsync(x => x.PersonaId == p.Id);
                result.Add(dto);
            }

            return Ok(new { data = result, page, pageSize });
        }

        // GET /api/personas/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var p = await _svc.GetAsync(id);
            if (p == null) return NotFound();

            var dto = _mapper.Map<PersonaViewDto>(p);
            dto.EsProfesor = await _db.Profesores.AnyAsync(x => x.PersonaId == id);
            dto.EsEstudiante = await _db.Estudiantes.AnyAsync(x => x.PersonaId == id);
            // dto.EsAdministrativo = ...
            return Ok(new { data = dto });
        }

        // POST /api/personas
        [HttpPost]
        [Authorize(Roles = "admin,director")]
        public async Task<IActionResult> Create([FromBody] PersonaCreateDto dto)
        {
            var p = await _svc.CreateAsync(dto);
            var view = _mapper.Map<PersonaViewDto>(p);
            return CreatedAtAction(nameof(GetById), new { id = p.Id }, new { data = view });
        }

        // PUT /api/personas/{id}
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "admin,director")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PersonaUpdateDto dto)
        {
            await _svc.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE /api/personas/{id}
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _svc.DeleteAsync(id);
            return NoContent();
        }

        // POST /api/personas/{id}/roles/profesor
        [HttpPost("{id:guid}/roles/profesor")]
        [Authorize(Roles = "admin,director")]
        public async Task<IActionResult> AsignarProfesor(Guid id, [FromBody] ProfesorCreateDto dto)
        {
            await _svc.AsignarProfesorAsync(id, dto);
            return Ok();
        }

        // DELETE /api/personas/{id}/roles/profesor
        [HttpDelete("{id:guid}/roles/profesor")]
        [Authorize(Roles = "admin,director")]
        public async Task<IActionResult> QuitarProfesor(Guid id)
        {
            await _svc.QuitarProfesorAsync(id);
            return NoContent();
        }

        // POST /api/personas/{id}/roles/estudiante
        [HttpPost("{id:guid}/roles/estudiante")]
        [Authorize(Roles = "admin,director")]
        public async Task<IActionResult> AsignarEstudiante(Guid id, [FromBody] EstudianteCreateFromPersonaDto dto)
        {
            await _svc.AsignarEstudianteAsync(id, dto);
            return Ok();
        }

        // DELETE /api/personas/roles/estudiante/{matricula}
        [HttpDelete("roles/estudiante/{matricula}")]
        [Authorize(Roles = "admin,director")]
        public async Task<IActionResult> QuitarEstudiante(string matricula)
        {
            await _svc.QuitarEstudianteAsync(matricula);
            return NoContent();
        }
    }
}
