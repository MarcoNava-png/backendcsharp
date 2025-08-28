namespace WebApplication2.Core.Models
{
    public class AspirantesProgramas
    {
        public int AspiranteId { get; set; }
        public int ProgramaId { get; set; }
        public DateTime FechaPostulacion { get; set; }

        public Aspirante Aspirante { get; set; }
        public Programa Programa { get; set; }
    }
}
