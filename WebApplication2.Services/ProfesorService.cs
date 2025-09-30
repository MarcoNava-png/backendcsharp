using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Common;
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

        public async Task<PagedResult<Profesor>> GetProfesores(int page, int pageSize)
        {
            var totalItems = await _dbContext.Profesores
                .Where(d => d.Persona.Estatus == StatusEnum.Activo)
                .CountAsync();

            var profesores = await _dbContext.Profesores
                .Include(d => d.Persona)
                .Where(d => d.Persona.Estatus == StatusEnum.Activo)
                .OrderBy(d => d.Persona.ApellidoPaterno)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Profesor>
            {
                TotalItems = totalItems,
                Items = profesores,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public async Task<Profesor> CrearProfesor(Profesor profesor)
        {
            await _dbContext.AddAsync(profesor);
            await _dbContext.SaveChangesAsync();

            return profesor;
        }

        public async Task<Profesor> EliminarProfesor(int id)
        {
            var profesor = await _dbContext.Profesores
                .Include(d => d.Persona)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (profesor == null)
            {
                throw new Exception("No existe persona con el id ingresado");
            }

            profesor.Persona.Estatus = StatusEnum.Inactivo;

            _dbContext.Profesores.Update(profesor);

            await _dbContext.SaveChangesAsync();

            return profesor;
        }
    }
}
