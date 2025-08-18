using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Core/Models/PlanEstudios.cs
namespace WebApplication2.Core.Models
{
    public class PlanEstudios
    {
        public int Id { get; set; }                 // id_plan
        public string? Nombre { get; set; }
        public string? Rvoe { get; set; }
        public bool PermiteAdelantar { get; set; }  // tinyint(1) -> bit
        public string? Version { get; set; }
        public int? ProgramaId { get; set; }
        public int? DuracionMeses { get; set; }     // default 48
        public int? PeriodicidadId { get; set; }    // sin catálogo por ahora

        public ProgramaEstudios? Programa { get; set; }
    }
}

