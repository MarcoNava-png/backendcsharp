using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Core.Models
{
    public class Persona
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string ApellidoPaterno { get; set; } = default!;
        public string ApellidoMaterno { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }

        // NUEVOS
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public int PersonaGeneroId { get; set; }
        public PersonaGenero PersonaGenero { get; set; } = default!;

        // NUEVOS: FK a catálogos/transaccionales
        public int? PersonaEstadoCivilId { get; set; }
        public PersonaEstadoCivil? EstadoCivil { get; set; }

        public int? DireccionId { get; set; }
        public Direccion? Direccion { get; set; }

        public string UserId { get; set; } = default!;
        public IdentityUser User { get; set; } = default!;

    }
}