using WebApplication2.Core.Enums;

namespace WebApplication2.Core.Models
{
    public class Aspirante
    {
        public Aspirante(string nombre)
        {
            
        }

        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public AspiranteStatusEnum Estatus { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
