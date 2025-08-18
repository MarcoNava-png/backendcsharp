using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Core/DTOs/Students/EstudianteCreateFromPersonaDto.cs

namespace WebApplication2.Core.DTOs.Students
{
    public class EstudianteCreateFromPersonaDto
    {
        public string Matricula { get; set; } = default!;
        public DateTime? FechaIngreso { get; set; }
        public int? EstatusAcademicoId { get; set; }
    }
}
