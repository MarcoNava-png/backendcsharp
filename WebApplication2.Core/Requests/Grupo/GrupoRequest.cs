namespace WebApplication2.Core.Requests.Grupo
{
    public class GrupoRequest
    {
        public string Clave { get; set; }
        public int PlanEstudiosId { get; set; }
        public int Semestre { get; set; }
        public int Periodicidad { get; set; }
    }
}
