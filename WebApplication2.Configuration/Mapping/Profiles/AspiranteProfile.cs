using AutoMapper;
using WebApplication2.Core.DTOs;
using WebApplication2.Core.Models;

namespace WebApplication2.Configuration.Mapping.Profiles
{
    public class AspiranteProfile : Profile
    {
        public AspiranteProfile()
        {
            CreateMap<Aspirante, AspiranteDto>()
                .ForMember(dto => dto.Estatus, map => map.MapFrom(model => model.Estatus));
        }
    }
}
