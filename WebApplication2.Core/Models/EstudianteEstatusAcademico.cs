using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Core/Models/EstudianteEstatusAcademico.cs
namespace WebApplication2.Core.Models
{
    public class EstudianteEstatusAcademico
    {
        public int Id { get; set; }                 // PK (IDENTITY)
        public string Estatus { get; set; } = default!;
        public List<Estudiante> Estudiantes { get; set; } = new();
        public List<EstudianteEstatus> Historial { get; set; } = new();
    }
}

