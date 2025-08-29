namespace WebApplication2.Core.Requests.Auth
{
    public class ProfesorSignupRequest : PersonaSignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Especialidad { get; set; }
    }
}
