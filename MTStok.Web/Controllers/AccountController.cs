using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MTStok.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var inputEmail = email?.ToLower().Trim();

            // --- SYSTEM ADMIN (MURAT) GİRİŞİ ---
            // System Admin tüm yetkilere sahip "Root" kullanıcısıdır.
            if ((inputEmail == "admin@mtstok.com" || inputEmail == "admin") && password == "Admin123!")
            {
                // Kullanıcı kimlik bilgileri
                TempData["UserName"] = "System Admin (Murat)";
                TempData["UserRole"] = "SystemAdmin";

                // Rol Ayarları: Admin her şeyi görebilir (Full Access)
                // Bu liste ileride veritabanındaki yetki matrisinden gelecek.
                var adminPermissions = new List<string> { "Dashboard", "Products", "Logs", "Users", "Roles", "Maintenance" };
                TempData["Permissions"] = adminPermissions;

                return RedirectToAction("Index", "Home");
            }

            // --- USER (SUAD) GİRİŞİ ---
            // Suad kısıtlı yetkiye sahip standart bir kullanıcıdır.
            if ((inputEmail == "suad@mtstok.com" || inputEmail == "suad") && password == "Suad123!")
            {
                TempData["UserName"] = "Suad";
                TempData["UserRole"] = "User";

                // Rol Ayarları: Suad sadece temel ekranları görebilir.
                var userPermissions = new List<string> { "Dashboard", "Products" };
                TempData["Permissions"] = userPermissions;

                return RedirectToAction("Index", "Home");
            }

            // Hata Durumu
            ModelState.AddModelError("", "E-posta veya şifre geçersiz. Lütfen tekrar deneyin.");
            return View();
        }

        // Oturumu kapatır ve tüm yetki verilerini temizler
        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Login");
        }

        /* SENIOR NOTU: 
           Burada 'TempData' kullanarak yetkileri (Permissions) dizi olarak saklıyoruz. 
           Layout tarafında "@if (TempData.Peek("Permissions") is List<string> p && p.Contains("Logs"))" 
           şeklinde bir kontrol yaparak ekranların görünürlüğünü dinamik olarak yönetebilirsin.
        */
    }
}