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
                .ForMember(dto => dto.NombreCompleto, map => map.MapFrom(model => $"{model.IdPersonaNavigation!.ApellidoPaterno} {model.IdPersonaNavigation!.ApellidoMaterno} {model.IdPersonaNavigation!.Nombre}"))
                .ForMember(dto => dto.PersonaId, map => map.MapFrom(model => model.IdPersonaNavigation!.IdPersona))
                .ForMember(dto => dto.Email, map => map.MapFrom(model => model.IdPersonaNavigation!.Correo))
                .ForMember(dto => dto.AspiranteEstatus, map => map.MapFrom(model => model.IdAspiranteEstatusNavigation.DescEstatus))
                .ForMember(dto => dto.PlanEstudios, map => map.MapFrom(model => model.IdPlanNavigation.NombrePlanEstudios));
        }
    }
}
