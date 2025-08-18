using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Core.Models;

namespace WebApplication2.Data.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<
        IdentityUser, IdentityRole, string,
        IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; } = default!;
        public DbSet<PersonaGenero> PersonasGenero { get; set; } = default!;
        public DbSet<Profesor> Profesores { get; set; } = default!;
        public DbSet<PersonaEstadoCivil> PersonaEstadosCiviles { get; set; } = default!;
        public DbSet<Direccion> Direcciones { get; set; } = default!;
        public DbSet<Pais> Paises { get; set; } = default!;
        public DbSet<Estado> Estados { get; set; } = default!;
        public DbSet<Municipio> Municipios { get; set; } = default!;
        public DbSet<CodigoPostal> CodigosPostales { get; set; } = default!;
        public DbSet<Aspirante> Aspirantes { get; set; } = default!;
        public DbSet<AspiranteEstatus> AspiranteEstatuses { get; set; } = default!;
        public DbSet<Programa> Programas { get; set; } = default!;
        public DbSet<AspirantePrograma> AspiranteProgramas { get; set; } = default!;
        public DbSet<Estudiante> Estudiantes { get; set; } = default!;
        public DbSet<EstudianteEstatusAcademico> EstudianteEstatusAcademicos { get; set; } = default!;
        public DbSet<EstudianteEstatus> EstudianteEstatuses { get; set; } = default!;
        public DbSet<Departamento> Departamentos { get; set; } = default!;
        public DbSet<ProgramaEstudios> ProgramasEstudios { get; set; } = default!;
        public DbSet<PlanEstudios> PlanesEstudios { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            // Persona (igual que ya tienes)
            b.Entity<Persona>(e =>
            {
                e.ToTable("Personas");
                e.Property(p => p.Nombre).HasMaxLength(80).IsRequired();
                e.Property(p => p.ApellidoPaterno).HasMaxLength(80).IsRequired();
                e.Property(p => p.ApellidoMaterno).HasMaxLength(80).IsRequired();
                e.Property(p => p.CorreoElectronico).HasMaxLength(120);
                e.Property(p => p.Telefono).HasMaxLength(20);

                e.HasOne(p => p.PersonaGenero)
                    .WithMany()
                    .HasForeignKey(p => p.PersonaGeneroId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.EstadoCivil)
                    .WithMany(ec => ec.Personas)
                    .HasForeignKey(p => p.PersonaEstadoCivilId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(p => p.Direccion)
                    .WithMany(d => d.Personas)
                    .HasForeignKey(p => p.DireccionId)
                    .OnDelete(DeleteBehavior.SetNull);

                e.HasOne(p => p.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Catálogo: Estado civil (igual que ya tienes)
            b.Entity<PersonaEstadoCivil>(e =>
            {
                e.ToTable("lookup_persona_estado_civil");
                e.Property(x => x.EstadoCivil).HasMaxLength(50).IsRequired();
                e.HasData(
                    new PersonaEstadoCivil { Id = 1, EstadoCivil = "Soltero(a)" },
                    new PersonaEstadoCivil { Id = 2, EstadoCivil = "Casado(a)" },
                    new PersonaEstadoCivil { Id = 3, EstadoCivil = "Divorciado(a)" },
                    new PersonaEstadoCivil { Id = 4, EstadoCivil = "Viudo(a)" }
                );
            });

            // CodigoPostal
            b.Entity<CodigoPostal>(e =>
            {
                e.ToTable("codigo_postal");
                e.Property(x => x.Id).HasColumnName("id_codigo");
                e.Property(x => x.MunicipioId).HasColumnName("id_municipio");
                e.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(10).IsRequired();
                e.Property(x => x.Colonia).HasColumnName("colonia").HasMaxLength(100);
            });

            // Direccion (UN SOLO BLOQUE)
            b.Entity<Direccion>(e =>
            {
                e.ToTable("direccion");
                e.Property(x => x.Id).HasColumnName("id_direccion");
                e.Property(x => x.Calle).HasMaxLength(100);
                e.Property(x => x.Numero).HasMaxLength(10);

                // FK escalar -> columna id_codigo
                e.Property(x => x.CodigoPostalId).HasColumnName("id_codigo");

                e.HasOne(d => d.CodigoPostal)
                    .WithMany(cp => cp.Direcciones)
                    .HasForeignKey(d => d.CodigoPostalId)
                    .OnDelete(DeleteBehavior.SetNull);

                // ===== aspirante_estatus
                b.Entity<AspiranteEstatus>(e =>
                {
                    e.ToTable("aspirante_estatus");
                    e.Property(x => x.Id).HasColumnName("id");
                    e.Property(x => x.Estatus).HasColumnName("estatus").HasMaxLength(50).IsRequired();

                    // (Opcional) seed inicial
                    e.HasData(
                        new AspiranteEstatus { Id = 1, Estatus = "Pre-registrado" },
                        new AspiranteEstatus { Id = 2, Estatus = "En revisión" },
                        new AspiranteEstatus { Id = 3, Estatus = "Aceptado" },
                        new AspiranteEstatus { Id = 4, Estatus = "Rechazado" }
                    );
                });

                // ===== programa (catálogo mínimo)
                b.Entity<Programa>(e =>
                {
                    e.ToTable("programa");
                    e.Property(x => x.Id).HasColumnName("id_programa");
                    e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(120).IsRequired();
                });

                // ===== aspirante
                b.Entity<Aspirante>(e =>
                {
                    e.ToTable("aspirante");
                    e.Property(x => x.Id).HasColumnName("id_aspirante");
                    e.Property(x => x.PersonaId).HasColumnName("id_persona");               // uniqueidentifier
                    e.Property(x => x.FechaRegistro).HasColumnName("fecha_registro").HasColumnType("date");
                    e.Property(x => x.EstatusId).HasColumnName("estatus_id");

                    e.HasOne(x => x.Persona)
                     .WithMany() // o .WithOne() si decides 1:1
                     .HasForeignKey(x => x.PersonaId)
                     .OnDelete(DeleteBehavior.SetNull);

                    e.HasOne(x => x.Estatus)
                     .WithMany(s => s.Aspirantes)
                     .HasForeignKey(x => x.EstatusId)
                     .OnDelete(DeleteBehavior.SetNull);
                });

                // ===== aspirante_programa (composite key + payload)
                b.Entity<AspirantePrograma>(e =>
                {
                    e.ToTable("aspirante_programa");
                    e.HasKey(x => new { x.AspiranteId, x.ProgramaId });

                    e.Property(x => x.AspiranteId).HasColumnName("id_aspirante");
                    e.Property(x => x.ProgramaId).HasColumnName("id_programa");
                    e.Property(x => x.FechaPostulacion).HasColumnName("fecha_postulacion").HasColumnType("date");
                    e.Property(x => x.EstatusId).HasColumnName("estatus_id");

                    e.HasOne(x => x.Aspirante)
                     .WithMany(a => a.Programas)
                     .HasForeignKey(x => x.AspiranteId)
                     .OnDelete(DeleteBehavior.Cascade);

                    e.HasOne(x => x.Programa)
                     .WithMany(p => p.Aspirantes)
                     .HasForeignKey(x => x.ProgramaId)
                     .OnDelete(DeleteBehavior.Cascade);

                    e.HasOne(x => x.Estatus)
                     .WithMany(s => s.AspirantesPrograma)
                     .HasForeignKey(x => x.EstatusId)
                     .OnDelete(DeleteBehavior.SetNull);
                });

                // ===== estudiante
                b.Entity<Estudiante>(e =>
                {
                    e.ToTable("estudiante");
                    e.HasKey(x => x.Matricula);
                    e.Property(x => x.Matricula).HasColumnName("matricula").HasMaxLength(15);

                    e.Property(x => x.PersonaId).HasColumnName("id_persona"); // uniqueidentifier (Guid)
                    e.Property(x => x.FechaIngreso).HasColumnName("fecha_ingreso").HasColumnType("date");
                    e.Property(x => x.NivelEducativoId).HasColumnName("nivel_educativo_id");
                    e.Property(x => x.EstatusId).HasColumnName("estatus_id");
                    e.Property(x => x.EstatusAcademicoId).HasColumnName("estatus_academico_id");

                    e.HasOne(x => x.Persona)
                     .WithMany() // o .WithOne si defines 1:1
                     .HasForeignKey(x => x.PersonaId)
                     .OnDelete(DeleteBehavior.SetNull);

                    e.HasOne(x => x.EstatusAcademico)
                     .WithMany(s => s.Estudiantes)
                     .HasForeignKey(x => x.EstatusAcademicoId)
                     .OnDelete(DeleteBehavior.SetNull);
                });

                // ===== estudiante_estatus (histórico)
                b.Entity<EstudianteEstatus>(e =>
                {
                    e.ToTable("estudiante_estatus");
                    e.Property(x => x.Id).HasColumnName("id");
                    e.Property(x => x.Matricula).HasColumnName("matricula").HasMaxLength(15).IsRequired();
                    e.Property(x => x.FechaDesde).HasColumnName("fecha_desde").HasColumnType("datetime")
                                                 .HasDefaultValueSql("GETDATE()");
                    e.Property(x => x.Observaciones).HasColumnName("observaciones"); // text -> nvarchar(max)
                    e.Property(x => x.EstatusAcademicoId).HasColumnName("estatus_id");

                    e.HasOne(x => x.Estudiante)
                     .WithMany(s => s.HistorialEstatus)
                     .HasForeignKey(x => x.Matricula)
                     .HasPrincipalKey(s => s.Matricula)
                     .OnDelete(DeleteBehavior.Cascade);

                    e.HasOne(x => x.EstatusAcademico)
                     .WithMany(s => s.Historial)
                     .HasForeignKey(x => x.EstatusAcademicoId)
                     .OnDelete(DeleteBehavior.SetNull);
                });

                // ===== estudiante_estatus_academico
                b.Entity<EstudianteEstatusAcademico>(e =>
                {
                    e.ToTable("estudiante_estatus_academico");
                    e.Property(x => x.Id).HasColumnName("id");
                    e.Property(x => x.Estatus).HasColumnName("estatus").HasMaxLength(50).IsRequired();

                    // (opcional) seed
                    // e.HasData(
                    //     new EstudianteEstatusAcademico { Id = 1, Estatus = "Regular" },
                    //     new EstudianteEstatusAcademico { Id = 2, Estatus = "Condicionado" },
                    //     new EstudianteEstatusAcademico { Id = 3, Estatus = "Baja temporal" },
                    //     new EstudianteEstatusAcademico { Id = 4, Estatus = "Egresado" }
                    // );
                });

                // ===== departamento
                b.Entity<Departamento>(e =>
                {
                    e.ToTable("departamento");
                    e.Property(x => x.Id).HasColumnName("id_departamento");
                    e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
                });

                // ===== programa_estudios
                b.Entity<ProgramaEstudios>(e =>
                {
                    e.ToTable("programa_estudios");
                    e.Property(x => x.Id).HasColumnName("id_programa");
                    e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(100);
                    e.Property(x => x.DepartamentoId).HasColumnName("id_departamento");
                    e.Property(x => x.NivelId).HasColumnName("nivel_id");

                    e.HasOne(x => x.Departamento)
                     .WithMany(d => d.Programas)
                     .HasForeignKey(x => x.DepartamentoId)
                     .OnDelete(DeleteBehavior.SetNull);
                });

                // ===== plan_estudios
                b.Entity<PlanEstudios>(e =>
                {
                    e.ToTable("plan_estudios");
                    e.Property(x => x.Id).HasColumnName("id_plan");
                    e.Property(x => x.Nombre).HasColumnName("nombre").HasMaxLength(100);
                    e.Property(x => x.Rvoe).HasColumnName("rvoe").HasMaxLength(50);
                    e.Property(x => x.PermiteAdelantar).HasColumnName("permite_adelantar"); // bit
                    e.Property(x => x.Version).HasColumnName("version").HasMaxLength(10);
                    e.Property(x => x.ProgramaId).HasColumnName("id_programa");
                    e.Property(x => x.DuracionMeses).HasColumnName("duracion_meses").HasDefaultValue(48);
                    e.Property(x => x.PeriodicidadId).HasColumnName("periodicidad_id");

                    e.HasOne(x => x.Programa)
                     .WithMany(p => p.Planes)
                     .HasForeignKey(x => x.ProgramaId)
                     .OnDelete(DeleteBehavior.SetNull);
                });

                b.Entity<Profesor>(e =>
                {
                    e.ToTable("profesor");                      // o el nombre que uses
                    e.Property(x => x.Id).HasColumnName("id_profesor");
                    e.Property(x => x.PersonaId).HasColumnName("id_persona");

                    e.HasOne(x => x.Persona)
                     .WithMany()                                // o .WithOne(p => p.Profesor) si agregas nav en Persona
                     .HasForeignKey(x => x.PersonaId)
                     .OnDelete(DeleteBehavior.Cascade);

                    e.HasIndex(x => x.PersonaId).IsUnique();    // 1 persona -> 1 profesor (si así lo deseas)
                });


            });

        }
    }
}
