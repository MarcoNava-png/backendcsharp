namespace WebApplication2.Core.Models
{
    public class Profesor
    {
        public int Id { get; set; } 
        public Guid PersonaId { get; set; }         
        public Persona Persona { get; set; } = default!;
        public string? Especialidad { get; set; }
        public int? DepartamentoId { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
    }
}
