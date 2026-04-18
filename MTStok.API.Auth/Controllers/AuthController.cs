using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MTStok.Application.DTOs.Auth;
using MTStok.Application.Interfaces;
using MTStok.Domain.Entities;

namespace MTStok.API.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.EmailOrUserName)
                       ?? await _userManager.FindByNameAsync(loginDto.EmailOrUserName);

            if (user == null) return Unauthorized(new { message = "Kullanıcı bulunamadı!" });

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid) return Unauthorized(new { message = "Hatalı şifre!" });

            var tokenResult = await _tokenService.CreateTokenAsync(user);
            return Ok(tokenResult);
        }
    }
}