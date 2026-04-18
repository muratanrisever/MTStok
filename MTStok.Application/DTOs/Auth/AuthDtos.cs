namespace MTStok.Application.DTOs.Auth
{
    public class LoginDto
    {
        public string EmailOrUserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    // Başarılı
    public class TokenDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}