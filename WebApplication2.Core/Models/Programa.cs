using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class Programa
    {
        public int Id { get; set; }                       // -> id_programa (IDENTITY)
        public string Nombre { get; set; } = default!;    // cat. mínimo
        public ICollection<AspirantePrograma> Aspirantes { get; set; } = new List<AspirantePrograma>();
    }
}
