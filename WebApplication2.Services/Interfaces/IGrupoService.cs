using WebApplication2.Core.Common;
using WebApplication2.Core.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface IGrupoService
    {
        Task<PagedResult<Grupo>> GetGrupos(int page, int pageSize);
        Task<Grupo> CrearGrupo(Grupo grupo);
        Task<Grupo> EliminarGrupo(int id);
    }
}
