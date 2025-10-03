namespace WebApplication2.Core.Models
{
    public class PlanEstudios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rvoe { get; set; }
        public int PermiteAdelantar { get; set; }
        public string Version { get; set; }
        public int ProgramaId { get; set; }
        public int DuracionMeses { get; set; }
        public int Periodicidad { get; set; }
        public Programa Programa { get; set; }
    }
}
