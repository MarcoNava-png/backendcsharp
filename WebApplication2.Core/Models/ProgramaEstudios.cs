using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Core/Models/ProgramaEstudios.cs
namespace WebApplication2.Core.Models
{
    public class ProgramaEstudios
    {
        public int Id { get; set; }                 // id_programa
        public string? Nombre { get; set; }
        public int? DepartamentoId { get; set; }
        public int? NivelId { get; set; }           // sin catálogo por ahora

        public Departamento? Departamento { get; set; }
        public List<PlanEstudios> Planes { get; set; } = new();
    }
}

