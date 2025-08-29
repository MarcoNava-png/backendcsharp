namespace WebApplication2.Core.Models
{
    public class Curso
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        // Navegación a los cursos que este curso necesita
        public ICollection<Prerrequisito> Prerrequisitos { get; set; }

        // Navegación a los cursos que requieren este curso
        public ICollection<Prerrequisito> EsPrerrequisitoDe { get; set; }
    }
}
