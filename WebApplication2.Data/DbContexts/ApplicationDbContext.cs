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
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Prerrequisito> Prerrequisitos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Aspirante> Aspirantes { get; set; }
        public DbSet<AspirantePrograma> AspirantesProgramas { get; set; }
        public DbSet<AspiranteProgramaEstatus> AspirantesProgramasEstatus { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<HistorialAcademico> HistorialAcademico { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }

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

            modelBuilder.Entity<Prerrequisito>()
                .HasKey(p => new { p.CursoId, p.PrerrequisitoId });

            modelBuilder.Entity<Prerrequisito>()
                .HasOne(p => p.Curso)
                .WithMany(c => c.Prerrequisitos)
                .HasForeignKey(p => p.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prerrequisito>()
                .HasOne(p => p.CursoPrerrequisito)
                .WithMany(c => c.EsPrerrequisitoDe)
                .HasForeignKey(p => p.PrerrequisitoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AspirantePrograma>()
                .HasKey(p => new { p.AspiranteId, p.ProgramaId });

            modelBuilder.Entity<HistorialAcademico>()
                .Property(p => p.CalificacionFinal)
                .HasPrecision(4, 2);
        }
    }
}
