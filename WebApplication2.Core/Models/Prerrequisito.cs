namespace WebApplication2.Core.Models
{
    public class Prerrequisito
    {
        public string CursoId { get; set; }
        public string PrerrequisitoId { get; set; }

        public Curso Curso { get; set; }
        public Curso CursoPrerrequisito { get; set; }
    }
}
