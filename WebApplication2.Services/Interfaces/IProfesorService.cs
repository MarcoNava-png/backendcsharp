using WebApplication2.Core.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface IProfesorService
    {
        public Task<Profesor> CrearProfesor(Profesor profesor);
        public Task<IEnumerable<Profesor>> ListProfesor();
    }
}
