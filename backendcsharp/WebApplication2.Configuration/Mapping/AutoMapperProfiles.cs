using AutoMapper;
using WebApplication2.Configuration.Mapping.Profiles;

namespace WebApplication2.Configuration.Mapping
{
    public static class AutoMapperProfiles
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new UserProfile()
            };
        }
    }
}
