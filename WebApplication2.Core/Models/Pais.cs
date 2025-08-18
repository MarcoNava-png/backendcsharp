using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class Pais
    {
        public int Id { get; set; }                
        public string Nombre { get; set; } = null!;
        public string? CodigoIso { get; set; }
        public ICollection<Estado> Estados { get; set; } = new List<Estado>();
    }
}
