using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class AspiranteEstatus
    {
        public int Id { get; set; }                       // -> id (IDENTITY)
        public string Estatus { get; set; } = default!;   // -> varchar(50)
        public ICollection<Aspirante> Aspirantes { get; set; } = new List<Aspirante>();
        public ICollection<AspirantePrograma> AspirantesPrograma { get; set; } = new List<AspirantePrograma>();
    }
}