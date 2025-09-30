namespace WebApplication2.Core.DTOs
{
    public class UserLoginInfoDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string CompleteName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
