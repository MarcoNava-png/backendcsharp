using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Core/Models/Departamento.cs
namespace WebApplication2.Core.Models
{
    public class Departamento
    {
        public int Id { get; set; }                 // id_departamento
        public string Nombre { get; set; } = default!;
        public List<ProgramaEstudios> Programas { get; set; } = new();
    }
}
