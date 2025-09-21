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
            var totalItems = await _dbContext.Aspirante
                .CountAsync();

            var aspirantes = await _dbContext.Aspirante
                .Include(a => a.IdPersonaNavigation)
                .Include(a => a.IdPlanNavigation)
                .Include(a => a.IdAspiranteEstatusNavigation)
                .OrderBy(d => d.IdPersonaNavigation.ApellidoPaterno)
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

        public async Task<Aspirante> CrearAspirante(Aspirante Aspirante)
        {
            await _dbContext.Aspirante.AddAsync(Aspirante);
            await _dbContext.SaveChangesAsync();

            return Aspirante;
        }

        public async Task<Aspirante> ActualizarAspirante(Aspirante newAspirante)
        {
            var aspirante = await _dbContext.Aspirante
                .Include(a => a.IdPersonaNavigation)
                .ThenInclude(p => p.IdDireccionNavigation)
                .SingleOrDefaultAsync(a => a.IdAspirante == newAspirante.IdAspirante);

            if (aspirante == null)
            {
                throw new Exception("No existe aspirante con el id ingresado");
            }

            if (newAspirante.IdPersonaNavigation != null)
            {
                var persona = await _dbContext.Persona.SingleOrDefaultAsync(p => p.IdPersona == aspirante.IdPersona);

                persona.Nombre = newAspirante.IdPersonaNavigation.Nombre;
                persona.ApellidoPaterno = newAspirante.IdPersonaNavigation.ApellidoPaterno;
                persona.ApellidoMaterno = newAspirante.IdPersonaNavigation.ApellidoMaterno;
                persona.FechaNacimiento = newAspirante.IdPersonaNavigation.FechaNacimiento;
                persona.IdGenero = newAspirante.IdPersonaNavigation.IdGenero;
                persona.Curp = newAspirante.IdPersonaNavigation.Curp;
                persona.Correo = newAspirante.IdPersonaNavigation.Correo;
                persona.Telefono = newAspirante.IdPersonaNavigation.Telefono;

                _dbContext.Persona.Update(persona);
            }

            if (newAspirante.IdPersonaNavigation.IdDireccionNavigation != null)
            {
                var direccion = await _dbContext.Direccion.SingleOrDefaultAsync(d => d.IdDireccion == aspirante.IdPersonaNavigation.IdDireccion);

                direccion.Calle = newAspirante.IdPersonaNavigation.IdDireccionNavigation.Calle;
                direccion.NumeroExterior = newAspirante.IdPersonaNavigation.IdDireccionNavigation.NumeroExterior;
                direccion.NumeroInterior = newAspirante.IdPersonaNavigation.IdDireccionNavigation.NumeroInterior;
                direccion.CodigoPostalId = newAspirante.IdPersonaNavigation.IdDireccionNavigation.CodigoPostalId;

                _dbContext.Direccion.Update(direccion);
            }

            aspirante.IdPlan = newAspirante.IdPlan;
            aspirante.IdMedioContacto = newAspirante.IdMedioContacto;
            aspirante.FechaRegistro = newAspirante.FechaRegistro;
            aspirante.Observaciones = newAspirante.Observaciones;
            aspirante.TurnoId = newAspirante.TurnoId;
            aspirante.IdAspiranteEstatus = newAspirante.IdAspiranteEstatus;

            _dbContext.Aspirante.Update(aspirante);

            await _dbContext.SaveChangesAsync();

            return aspirante;
        }
    }
}
