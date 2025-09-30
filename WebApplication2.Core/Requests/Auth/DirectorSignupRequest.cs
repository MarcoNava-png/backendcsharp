namespace WebApplication2.Core.Requests.Auth
{
    public class DirectorSignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int PersonaGeneroId { get; set; }
    }
}
