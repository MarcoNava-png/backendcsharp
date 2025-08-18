using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class PersonaEstadoCivil
    {
        public int Id { get; set; }                          
        public string EstadoCivil { get; set; } = default!;
        public ICollection<Persona> Personas { get; set; } = new List<Persona>();
    }
}
