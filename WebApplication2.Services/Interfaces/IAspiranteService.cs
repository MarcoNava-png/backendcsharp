using WebApplication2.Core.Common;
using WebApplication2.Core.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface IAspiranteService
    {
        Task<PagedResult<Aspirante>> GetAspirantes(int page, int pageSize);
        Task<Aspirante> CrearAspirante(Aspirante aspirante);
        Task<Aspirante> ActualizarAspirante(Aspirante aspirante);
    }
}
