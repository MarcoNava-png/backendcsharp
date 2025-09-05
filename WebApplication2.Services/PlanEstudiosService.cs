using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Common;
using WebApplication2.Core.Models;
using WebApplication2.Data.DbContexts;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class PlanEstudiosService : IPlanEstudioService
    {
        private readonly ApplicationDbContext _dbContext;

        public PlanEstudiosService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedResult<PlanEstudios>> GetPlanesEstudios(int page, int pageSize)
        {
            var totalItems = await _dbContext.PlanEstudios
                .CountAsync();

            var profesores = await _dbContext.PlanEstudios
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<PlanEstudios>
            {
                TotalItems = totalItems,
                Items = profesores,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public async Task<PlanEstudios> CrearPlanEstudios(PlanEstudios profesor)
        {
            await _dbContext.AddAsync(profesor);
            await _dbContext.SaveChangesAsync();

            return profesor;
        }

        public async Task<PlanEstudios> EliminarPlanEstudios(int id)
        {
            throw new NotImplementedException();
        }
    }
}
