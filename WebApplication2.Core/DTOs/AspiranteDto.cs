using WebApplication2.Core.Models;

namespace WebApplication2.Core.DTOs
{
    public class AspiranteDto
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estatus { get; set; }
        public PersonaDto Persona { get; set; }
    }
}
