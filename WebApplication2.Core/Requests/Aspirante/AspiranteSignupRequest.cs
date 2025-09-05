using WebApplication2.Core.Requests.Auth;

namespace WebApplication2.Core.Requests.Aspirante
{
    public class AspiranteSignupRequest : PersonaSignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
