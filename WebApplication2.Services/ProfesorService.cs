using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Models;
using WebApplication2.Data.DbContexts;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfesorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Profesor> CrearProfesor(Profesor profesor)
        {
            await _dbContext.AddAsync(profesor);
            await _dbContext.SaveChangesAsync();

            return profesor;
        }

        public async Task<IEnumerable<Profesor>> ListProfesor()
        {
            return await _dbContext.Profesores.Include(p => p.Persona).ToListAsync();
        }
    }
}
