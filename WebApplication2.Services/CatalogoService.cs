using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Models;
using WebApplication2.Data.DbContexts;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Genero>> GetGeneros()
        {
            return await _dbContext.Genero.ToListAsync();
        }

        public async Task<IEnumerable<Turno>> GetTurnos()
        {
            return await _dbContext.Turno.ToListAsync();
        }
    }
}
