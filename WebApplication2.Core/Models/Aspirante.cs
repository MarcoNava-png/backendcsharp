using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class Aspirante
    {
        public int Id { get; set; }                       // -> id_aspirante (IDENTITY)
        public Guid? PersonaId { get; set; }              // -> id_persona (uniqueidentifier, opcional)
        public DateTime? FechaRegistro { get; set; }      // -> date
        public int? EstatusId { get; set; }               // -> estatus_id

        public Persona? Persona { get; set; }
        public AspiranteEstatus? Estatus { get; set; }
        public ICollection<AspirantePrograma> Programas { get; set; } = new List<AspirantePrograma>();
    }
}
