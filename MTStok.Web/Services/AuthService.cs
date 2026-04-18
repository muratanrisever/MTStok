using MTStok.Application.DTOs.Auth;
using System.Net.Http.Json;

namespace MTStok.Web.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TokenDto?> LoginAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı
                return await response.Content.ReadFromJsonAsync<TokenDto>();
            }

            return null;
        }
    }
}