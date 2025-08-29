namespace WebApplication2.Core.Requests.Auth
{
    public class AspiranteSignupRequest : PersonaSignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
