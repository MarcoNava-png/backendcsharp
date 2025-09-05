using WebApplication2.Core.Common;

namespace WebApplication2.Core.DTOs
{
    public class GrupoDto
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public int Semestre { get; set; }
        public int Periodicidad { get; set; }
        public PlanEstudioDto PlanEstudios { get; set; }
        public StatusEnum Status { get; set; }
    }
}
