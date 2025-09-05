using AutoMapper;
using WebApplication2.Core.DTOs;
using WebApplication2.Core.Models;

namespace WebApplication2.Configuration.Mapping.Profiles
{
    public class GrupoProfile : Profile
    {
        public GrupoProfile()
        {
            CreateMap<Grupo, GrupoDto>();
        }
    }
}
