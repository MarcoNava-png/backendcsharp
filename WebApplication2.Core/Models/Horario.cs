using WebApplication2.Core.Enums;

namespace WebApplication2.Core.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public int AulaId { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public DiaSemanaEnum DiaSemana { get; set; }
    }
}
