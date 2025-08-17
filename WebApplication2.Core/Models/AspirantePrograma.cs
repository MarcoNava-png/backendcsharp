using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Core.Models
{
    public class AspirantePrograma
    {
        public int AspiranteId { get; set; }              // -> id_aspirante
        public int ProgramaId { get; set; }               // -> id_programa
        public DateTime FechaPostulacion { get; set; }    // -> date
        public int? EstatusId { get; set; }               // -> estatus_id (opcional)

        public Aspirante Aspirante { get; set; } = default!;
        public Programa Programa { get; set; } = default!;
        public AspiranteEstatus? Estatus { get; set; }
    }
}
