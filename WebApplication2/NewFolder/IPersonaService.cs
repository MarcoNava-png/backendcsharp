using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Core.DTOs;             // PersonaCreateDto, etc.
using WebApplication2.Core.DTOs.Students;    // <<--- IMPORTANTE
using WebApplication2.Core.Models;

namespace WebApplication2.NewFolder          // usa el namespace real de tu interfaz
{
    public interface IPersonaService
    {
        Task<Persona> CreateAsync(PersonaCreateDto dto);
        Task<Persona?> GetAsync(Guid id);
        Task<List<Persona>> SearchAsync(string? q, int page, int pageSize);
        Task UpdateAsync(Guid id, PersonaUpdateDto dto);
        Task DeleteAsync(Guid id);

        Task AsignarProfesorAsync(Guid personaId, ProfesorCreateDto dto);
        Task AsignarEstudianteAsync(Guid personaId, EstudianteCreateFromPersonaDto dto); // <<-- nombre EXACTO: Async
        Task AsignarAdministrativoAsync(Guid personaId, AdministrativoCreateDto dto);

        Task QuitarProfesorAsync(Guid personaId);
        Task QuitarEstudianteAsync(string matricula);
        Task QuitarAdministrativoAsync(Guid personaId);
    }
}
