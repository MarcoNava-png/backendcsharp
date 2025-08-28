using WebApplication2.Core.Common;

namespace WebApplication2.Core.Models
{
    public class EstudianteStatus
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public DateTime FechaDesde { get; set; }
        public string Observaciones { get; set; }
        public StatusEnum Status { get; set; }
    }
}
