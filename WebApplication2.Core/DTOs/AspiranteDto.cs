using WebApplication2.Core.Models;

namespace WebApplication2.Core.DTOs
{
    public class AspiranteDto
    {
        public int IdAspirante { get; set; }

        public int PersonaId { get; set; }

        public string NombreCompleto { get; set; }

        public string Email { get; set; }

        public string AspiranteEstatus { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string PlanEstudios { get; set; }
    }
}
