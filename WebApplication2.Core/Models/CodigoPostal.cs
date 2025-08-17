using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class CodigoPostal
    {
        public int Id { get; set; }                 // PK INT
        public int MunicipioId { get; set; }
        public string Codigo { get; set; } = null!; // <- NO la llames "CodigoPostal"
        public string? Colonia { get; set; }
        public Municipio Municipio { get; set; } = null!;
        public ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
    }
}
