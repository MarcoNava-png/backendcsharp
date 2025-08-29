namespace WebApplication2.Core.Models
{
    public class HistorialAcademico
    {
        public int Id { get; set; }
        public string EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public int ClaseId { get; set; }
        public Clase Clase { get; set; }
        public string Periodo { get; set; }
        public decimal CalificacionFinal { get; set; }
        public int EstadoId { get; set; }
    }
}
