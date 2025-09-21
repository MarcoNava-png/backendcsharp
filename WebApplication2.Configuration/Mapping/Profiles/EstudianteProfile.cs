using AutoMapper;
using WebApplication2.Core.DTOs;
using WebApplication2.Core.Models;

namespace WebApplication2.Configuration.Mapping.Profiles
{
    public class EstudianteProfile : Profile
    {
        public EstudianteProfile()
        {
            //CreateMap<Estudiante, EstudianteDto>()
            //    .ForMember(dto => dto.NivelEducativo, map => map.MapFrom(model => model.NivelEducativo.Nombre));
        }
    }
}
