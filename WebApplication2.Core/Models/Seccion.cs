namespace WebApplication2.Core.Models
{
    public class Seccion
    {
        public int Id { get; set; }
        public int PlanEstudiosId { get; set; }
        public PlanEstudios PlanEstudios { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }
        public int CupoMaximo { get; set; }
    }
}
