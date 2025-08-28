using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string PaternalSurname { get; set; }
        public string MaternalSurname { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
