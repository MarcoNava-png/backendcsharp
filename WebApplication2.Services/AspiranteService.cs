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

        public async Task<PagedResult<AspirantePrograma>> GetAspirantes(int page, int pageSize)
        {
            var totalItems = await _dbContext.Aspirantes
                .Where(d => d.Persona.Estatus == StatusEnum.Activo)
                .CountAsync();

            var aspirantes = await _dbContext.AspirantesProgramas
                .Include(d => d.Programa)
                .ThenInclude(d => d.Departamento)
                .Include(d => d.Aspirante)
                .ThenInclude(d => d.Persona)
                .ThenInclude(d => d.PersonaGenero)
                .Where(d => d.Aspirante.Persona.Estatus == StatusEnum.Activo)
                .OrderBy(d => d.Aspirante.Persona.ApellidoPaterno)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<AspirantePrograma>
            {
                TotalItems = totalItems,
                Items = aspirantes,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public async Task<AspirantePrograma> CrearAspirante(AspirantePrograma aspirantePrograma)
        {
            await _dbContext.AspirantesProgramas.AddAsync(aspirantePrograma);
            await _dbContext.SaveChangesAsync();

            return aspirantePrograma;
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
