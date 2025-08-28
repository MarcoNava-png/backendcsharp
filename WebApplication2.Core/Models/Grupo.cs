namespace WebApplication2.Core.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public int PlanEstudiosId { get; set; }
        public int Semestre { get; set; }
        public int Periodicidad { get; set; }
        public PlanEstudios PlanEstudios { get; set; }
    }
}
