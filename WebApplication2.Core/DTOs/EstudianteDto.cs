namespace WebApplication2.Core.DTOs
{
    public class EstudianteDto
    {
        public string Id { get; set; }
        public PersonaDto Persona { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NivelEducativo { get; set; }
        public string StatusAcademico { get; set; }
        public string Status { get; set; }
    }
}
