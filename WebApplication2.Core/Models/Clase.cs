namespace WebApplication2.Core.Models
{
    public class Clase
    {
        public int Id { get; set; }
        public int SeccionId { get; set; }
        public Seccion Seccion { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }
        public string HorarioDescripcion { get; set; }
    }
}
