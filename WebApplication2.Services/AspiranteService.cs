using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Common;
using WebApplication2.Core.Models;
using WebApplication2.Data.DbContexts;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class AspiranteService : IAspiranteService
    {
        private readonly ApplicationDbContext _dbContext;

        public AspiranteService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedResult<Aspirante>> GetAspirantes(int page, int pageSize)
        {
            var totalItems = await _dbContext.Aspirantes
                .Where(d => d.Persona.Estatus == StatusEnum.Activo)
                .CountAsync();

            var aspirantes = await _dbContext.Aspirantes
                .Include(d => d.Persona)
                .Include(d => d.Persona.PersonaGenero)
                .Where(d => d.Persona.Estatus == StatusEnum.Activo)
                .OrderBy(d => d.Persona.ApellidoPaterno)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Aspirante>
            {
                TotalItems = totalItems,
                Items = aspirantes,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public async Task<Aspirante> CrearAspirante(Aspirante aspirante)
        {
            await _dbContext.Aspirantes.AddAsync(aspirante);
            await _dbContext.SaveChangesAsync();

            return aspirante;
        }

        public async Task<Aspirante> EliminarAspirante(int id)
        {
            var aspirante = await _dbContext.Aspirantes
                .Include(d => d.Persona)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (aspirante == null)
            {
                throw new Exception("No existe persona con el id ingresado");
            }

            aspirante.Persona.Estatus = StatusEnum.Inactivo;

            _dbContext.Aspirantes.Update(aspirante);

            await _dbContext.SaveChangesAsync();

            return aspirante;
        }
    }
}
