using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Models;

namespace WebApplication2.Data.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserClaim<string>,
        IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<PersonaGenero> PersonasGenero { get; set; }
    }
}
