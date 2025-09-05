using WebApplication2.Core.Common;
using WebApplication2.Core.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface IAspiranteService
    {
        Task<PagedResult<AspirantePrograma>> GetAspirantes(int page, int pageSize);
        Task<AspirantePrograma> CrearAspirante(AspirantePrograma aspirantePrograma);
        Task<Aspirante> EliminarAspirante(int id);
    }
}
