using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Core.Models
{
    public class Persona
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int PersonaGeneroId { get; set; }
        public string UserId { get; set; }
        public PersonaGenero PersonaGenero { get; set; }
        public IdentityUser User { get; set; }
    }
}