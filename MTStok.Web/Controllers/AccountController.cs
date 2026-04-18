using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MTStok.Application.DTOs.Auth;
using MTStok.Web.Services;
using System.Security.Claims;

namespace MTStok.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var loginDto = new LoginDto { EmailOrUserName = email, Password = password };

            var tokenResult = await _authService.LoginAsync(loginDto);

            if (tokenResult != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, tokenResult.UserName),
                    new Claim(ClaimTypes.Role, tokenResult.Role),
                    new Claim("Token", tokenResult.AccessToken)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            // Hata
            ModelState.AddModelError("", "E-posta veya şifre hatalı!");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}