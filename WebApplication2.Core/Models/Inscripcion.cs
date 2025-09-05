namespace WebApplication2.Core.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public string EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public DateTime Fecha { get; set; }
        public int PlanEstudiosId { get; set; }
        public PlanEstudios PlanEstudios { get; set; }
    }
}
