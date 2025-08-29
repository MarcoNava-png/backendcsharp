using WebApplication2.Core.Models;

namespace WebApplication2.Core.Requests.Auth
{
    public class PersonaSignupRequest
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int PersonaGeneroId { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public int CodigoPostalId { get; set; }
    }
}
