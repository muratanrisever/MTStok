using MTStok.Application.DTOs.Auth;
using MTStok.Domain.Entities;

namespace MTStok.Application.Interfaces
{
    public interface ITokenService
    {
        Task<TokenDto> CreateTokenAsync(AppUser user);
    }
}