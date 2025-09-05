namespace WebApplication2.Core.Models
{
    public class AspirantePrograma
    {
        public int AspiranteId { get; set; }
        public Aspirante Aspirante { get; set; }
        public int ProgramaId { get; set; }
        public Programa Programa { get; set; }
        public DateTime FechaPostulacion { get; set; }
        public int AspiranteProgramaEstatusId { get; set; }
        public AspiranteProgramaEstatus AspiranteProgramaEstatus { get; set; }
    }
}
