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
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Director> Directores { get; set; }
        public DbSet<Coordinador> Coordinadores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Programa> Programas { get; set; }
        public DbSet<PlanEstudios> PlanEstudios { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<NivelEducativo> NivelesEducativos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<CodigoPostal> CodigosPostales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Estado -> Municipio (1:N)
            modelBuilder.Entity<Municipio>()
                .HasOne(m => m.Estado)
                .WithMany(e => e.Municipios)
                .HasForeignKey(m => m.EstadoId)
                .IsRequired();

            // Índice para búsquedas por EstadoId
            modelBuilder.Entity<Municipio>()
                .HasIndex(m => m.EstadoId);

            // Relación Municipio -> CodigoPostal (1:N)
            modelBuilder.Entity<CodigoPostal>()
                .HasOne(cp => cp.Municipio)
                .WithMany(m => m.CodigosPostales)
                .HasForeignKey(cp => cp.MunicipioId)
                .IsRequired();

            // Índice para búsquedas por MunicipioId
            modelBuilder.Entity<CodigoPostal>()
                .HasIndex(cp => cp.MunicipioId);
        }
    }
}
