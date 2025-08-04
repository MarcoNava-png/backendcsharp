using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Core.Models;
using WebApplication2.Core.Requests.Auth;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace WebApplication2.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignupRequest, ApplicationUser>();
        }
    }
}
}
