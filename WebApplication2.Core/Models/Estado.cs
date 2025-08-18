using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class Estado
    {
        public int Id { get; set; }                // -> id_estado
        public int PaisId { get; set; }            // -> id_pais
        public string Nombre { get; set; } = null!;
        public Pais Pais { get; set; } = null!;
        public ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
    }
}
