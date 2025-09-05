using AutoMapper;
using WebApplication2.Core.Models;

namespace WebApplication2.Core.DTOs
{
    public class InscripcionProfile : Profile
    {
        public InscripcionProfile()
        {
            CreateMap<Inscripcion, InscripcionDto>();
        }
    }
}
