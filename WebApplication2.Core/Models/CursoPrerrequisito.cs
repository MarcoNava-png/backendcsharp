namespace WebApplication2.Core.Models
{
    public class CursoPrerrequisito
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }

        public string PrerrequisitoClave { get; set; }
        public Curso Prerrequisito { get; set; }
    }
}
