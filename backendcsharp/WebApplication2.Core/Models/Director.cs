namespace WebApplication2.Core.Models
{
    public class Director
    {
        public int Id { get; set; }
        public Guid PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
