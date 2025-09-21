using WebApplication2.Core.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface ICatalogoService
    {
        Task<IEnumerable<Genero>> GetGeneros();
        Task<IEnumerable<Turno>> GetTurnos();
    }
}
