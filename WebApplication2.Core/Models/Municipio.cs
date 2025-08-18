using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class Municipio
    {
        public int Id { get; set; }                // -> id_municipio
        public int EstadoId { get; set; }          // -> id_estado
        public string Nombre { get; set; } = null!;
        public Estado Estado { get; set; } = null!;
        public ICollection<CodigoPostal> CodigosPostales { get; set; } = new List<CodigoPostal>();
    }
}
