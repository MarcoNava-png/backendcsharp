using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Common;
using WebApplication2.Core.Models;
using WebApplication2.Data.DbContexts;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class GrupoService: IGrupoService
    {
        private readonly ApplicationDbContext _dbContext;

        public GrupoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedResult<Grupo>> GetGrupos(int page, int pageSize)
        {
            var totalItems = await _dbContext.Grupos
                .Where(d => d.Status == StatusEnum.Activo)
                .CountAsync();

            var items = await _dbContext.Grupos
                .Where(d => d.Status == StatusEnum.Activo)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Grupo>
            {
                TotalItems = totalItems,
                Items = items,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public async Task<Grupo> CrearGrupo(Grupo grupo)
        {
            await _dbContext.Grupos.AddAsync(grupo);
            await _dbContext.SaveChangesAsync();

            return grupo;
        }

        public async Task<Grupo> EliminarGrupo(int id)
        {
            var item = await _dbContext.Grupos
                .SingleOrDefaultAsync(p => p.Id == id);

            if (item == null)
            {
                throw new Exception("No existe grupo con el id ingresado");
            }

            item.Status = StatusEnum.Inactivo;

            _dbContext.Grupos.Update(item);

            await _dbContext.SaveChangesAsync();

            return item;
        }
    }
}
