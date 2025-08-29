namespace WebApplication2.Core.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Especialidad { get; set; }
        public Persona Persona { get; set; }
    }
}
