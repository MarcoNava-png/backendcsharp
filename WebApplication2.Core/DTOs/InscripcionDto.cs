namespace WebApplication2.Core.DTOs
{
    public class InscripcionDto
    {
        public int Id { get; set; }
        public EstudianteDto Estudiante { get; set; }
        public DateTime Fecha { get; set; }
        public int PlanEstudiosId { get; set; }
        public PlanEstudioDto PlanEstudios { get; set; }
    }
}
