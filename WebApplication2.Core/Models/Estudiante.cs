using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Core/Models/Estudiante.cs
namespace WebApplication2.Core.Models
{
    public class Estudiante
    {
        // PK por matrícula (varchar(15))
        public string Matricula { get; set; } = default!;

        // FK opcional a Persona (Guid) -> columna id_persona
        public Guid? PersonaId { get; set; }
        public Persona? Persona { get; set; }

        public DateTime? FechaIngreso { get; set; }

        // Aún no definiste catálogos para estos, por ahora déjalos como int?
        public int? NivelEducativoId { get; set; }

        // Campo “estatus_id” (administrativo?) — lo dejamos como int? por ahora
        public int? EstatusId { get; set; }

        // Catálogo académico:
        public int? EstatusAcademicoId { get; set; }
        public EstudianteEstatusAcademico? EstatusAcademico { get; set; }

        public List<EstudianteEstatus> HistorialEstatus { get; set; } = new();
    }
}
