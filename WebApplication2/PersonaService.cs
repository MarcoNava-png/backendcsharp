// Services/PersonaService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.DTOs;               // PersonaCreate/Update/View, ProfesorCreate, AdministrativoCreate
using WebApplication2.Core.DTOs.Students;      // EstudianteCreateFromPersonaDto
using WebApplication2.Core.Models;             // Entidades: Persona, Estudiante, Profesor...
using WebApplication2.Data.DbContexts;         // ApplicationDbContext
using WebApplication2.NewFolder;               // IPersonaService

namespace WebApplication2
{
    public class PersonaService : IPersonaService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private const string ROLE_TEACHER = "teacher";
        private const string ROLE_STUDENT = "student";
        private const string ROLE_ADMIN_STAFF = "adminstaff";

        public PersonaService(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Persona> CreateAsync(PersonaCreateDto dto)
        {
            var p = new Persona
            {
                Id = Guid.NewGuid(),
                Nombre = dto.Nombre,
                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno,
                FechaNacimiento = dto.FechaNacimiento,
                CorreoElectronico = dto.CorreoElectronico,
                Telefono = dto.Telefono,
                PersonaGeneroId = dto.PersonaGeneroId,
                UserId = dto.UserId ?? string.Empty,
                PersonaEstadoCivilId = dto.PersonaEstadoCivilId,
                DireccionId = dto.DireccionId
            };

            _db.Personas.Add(p);
            await _db.SaveChangesAsync();
            return p;
        }

        public Task<Persona?> GetAsync(Guid id)
            => _db.Personas.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Persona>> SearchAsync(string? q, int page, int pageSize)
        {
            var query = _db.Personas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                var s = q.Trim().ToLower();
                query = query.Where(x =>
                    (x.Nombre + " " + x.ApellidoPaterno + " " + x.ApellidoMaterno).ToLower().Contains(s) ||
                    (x.CorreoElectronico ?? "").ToLower().Contains(s) ||
                    (x.Telefono ?? "").ToLower().Contains(s));
            }

            return await query
                .OrderBy(x => x.ApellidoPaterno).ThenBy(x => x.ApellidoMaterno).ThenBy(x => x.Nombre)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task UpdateAsync(Guid id, PersonaUpdateDto dto)
        {
            var p = await _db.Personas.FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new KeyNotFoundException("Persona no encontrada.");

            // Map “solo si viene valor”
            if (dto.Nombre != null) p.Nombre = dto.Nombre;
            if (dto.ApellidoPaterno != null) p.ApellidoPaterno = dto.ApellidoPaterno;
            if (dto.ApellidoMaterno != null) p.ApellidoMaterno = dto.ApellidoMaterno;
            if (dto.CorreoElectronico != null) p.CorreoElectronico = dto.CorreoElectronico;
            if (dto.Telefono != null) p.Telefono = dto.Telefono;
            if (dto.PersonaEstadoCivilId.HasValue) p.PersonaEstadoCivilId = dto.PersonaEstadoCivilId;
            if (dto.DireccionId.HasValue) p.DireccionId = dto.DireccionId;
            if (dto.PersonaGeneroId.HasValue) p.PersonaGeneroId = dto.PersonaGeneroId.Value;
            if (dto.FechaNacimiento.HasValue) p.FechaNacimiento = dto.FechaNacimiento.Value;

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var p = await _db.Personas.FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new KeyNotFoundException("Persona no encontrada.");

            _db.Personas.Remove(p);
            await _db.SaveChangesAsync();
        }

        // ===== Roles / Relaciones hijas =====

        public async Task AsignarProfesorAsync(Guid personaId, ProfesorCreateDto dto)
        {
            // ¿ya es profesor?
            if (await _db.Profesores.AnyAsync(x => x.PersonaId == personaId))
                throw new InvalidOperationException("La persona ya es profesor.");

            // Crear registro de profesor
            var nuevo = new Profesor
            {
                PersonaId = personaId,
                // DepartamentoId = dto.DepartamentoId, // si lo tienes en el modelo
                FechaAlta = DateTime.UtcNow
            };
            _db.Profesores.Add(nuevo);
            await _db.SaveChangesAsync();

            await AsegurarIdentityRole(personaId, ROLE_TEACHER, add: true);
        }

        public async Task AsignarEstudianteAsync(Guid personaId, EstudianteCreateFromPersonaDto dto)
        {
            if (await _db.Estudiantes.AnyAsync(x => x.Matricula == dto.Matricula))
                throw new InvalidOperationException("La matrícula ya existe.");

            var e = new Estudiante
            {
                Matricula = dto.Matricula,
                PersonaId = personaId,
                FechaIngreso = dto.FechaIngreso,
                EstatusAcademicoId = dto.EstatusAcademicoId
            };

            _db.Estudiantes.Add(e);
            await _db.SaveChangesAsync();

            await AsegurarIdentityRole(personaId, ROLE_STUDENT, add: true);
        }

        public async Task AsignarAdministrativoAsync(Guid personaId, AdministrativoCreateDto dto)
        {
            // Si agregas tabla Administrativo, crea el registro aquí (similar a Profesor).
            await AsegurarIdentityRole(personaId, ROLE_ADMIN_STAFF, add: true);
        }

        public async Task QuitarProfesorAsync(Guid personaId)
        {
            var prof = await _db.Profesores.FirstOrDefaultAsync(x => x.PersonaId == personaId);
            if (prof != null)
            {
                _db.Profesores.Remove(prof);
                await _db.SaveChangesAsync();
            }
            await AsegurarIdentityRole(personaId, ROLE_TEACHER, add: false);
        }

        public async Task QuitarEstudianteAsync(string matricula)
        {
            var est = await _db.Estudiantes.FirstOrDefaultAsync(x => x.Matricula == matricula);
            if (est != null)
            {
                var pid = est.PersonaId;
                _db.Estudiantes.Remove(est);
                await _db.SaveChangesAsync();

                if (pid.HasValue)
                    await AsegurarIdentityRole(pid.Value, ROLE_STUDENT, add: false);
            }
        }

        public async Task QuitarAdministrativoAsync(Guid personaId)
        {
            // Si tienes tabla Administrativo, bórrala aquí.
            await AsegurarIdentityRole(personaId, ROLE_ADMIN_STAFF, add: false);
        }

        private async Task AsegurarIdentityRole(Guid personaId, string role, bool add)
        {
            // Solo si Persona está ligada a un IdentityUser
            var p = await _db.Personas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == personaId);
            if (p == null || string.IsNullOrWhiteSpace(p.UserId)) return;

            var user = await _userManager.FindByIdAsync(p.UserId);
            if (user == null) return;

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            if (add)
            {
                if (!await _userManager.IsInRoleAsync(user, role))
                    await _userManager.AddToRoleAsync(user, role);
            }
            else
            {
                if (await _userManager.IsInRoleAsync(user, role))
                    await _userManager.RemoveFromRoleAsync(user, role);
            }
        }
    }
}
