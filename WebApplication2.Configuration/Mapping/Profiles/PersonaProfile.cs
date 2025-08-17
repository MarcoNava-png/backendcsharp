// Configuration/Mapping/Profiles/PersonaProfile.cs
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Core.DTOs;
using WebApplication2.Core.Models;

public class PersonaProfile : Profile
{
    public PersonaProfile()
    {
        CreateMap<PersonaCreateDto, Persona>();
        CreateMap<PersonaUpdateDto, Persona>()
          .ForAllMembers(cfg => cfg.Condition((_, __, v) => v != null));

        CreateMap<Persona, PersonaViewDto>()
          .ForMember(d => d.NombreCompleto,
            m => m.MapFrom(s => $"{s.Nombre} {s.ApellidoPaterno} {s.ApellidoMaterno}".Trim()))
          .ForMember(d => d.Email, m => m.MapFrom(s => s.CorreoElectronico))
          .ForMember(d => d.EsProfesor, m => m.Ignore())
          .ForMember(d => d.EsEstudiante, m => m.Ignore())
          .ForMember(d => d.EsAdministrativo, m => m.Ignore());
    }
}
