using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Core/Models/EstudianteEstatus.cs  (histórico por matrícula)
namespace WebApplication2.Core.Models
{
    public class EstudianteEstatus
    {
        public int Id { get; set; }                 // PK (IDENTITY)
        public string Matricula { get; set; } = default!; // FK a Estudiante
        public DateTime FechaDesde { get; set; }    // default GETDATE()
        public string? Observaciones { get; set; }
        public int? EstatusAcademicoId { get; set; }

        public Estudiante Estudiante { get; set; } = default!;
        public EstudianteEstatusAcademico? EstatusAcademico { get; set; }
    }
}
