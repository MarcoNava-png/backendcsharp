using WebApplication2.Core.Common;
using WebApplication2.Core.Enums;

namespace WebApplication2.Core.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public Guid PersonaId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int NivelEducativoId { get; set; }
        public NivelEducativo NivelEducativo { get; set; }
        public EstudianteStatusAcademicoEnum StatusAcademico { get; set; }
        public StatusEnum Status { get; set; }
    }
}
