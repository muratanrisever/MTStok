using Microsoft.AspNetCore.Mvc;

namespace MTStok.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Users()
        {
            ViewData["PageHeader"] = "Kullanıcı Yönetimi";
            return View();
        }

        // Rol ve Yetki Matrisi Sayfası
        public IActionResult Roles()
        {
            ViewData["PageHeader"] = "Rol & Yetki Yönetimi";
            return View();
        }

        // GET: /Admin/Maintenance
        // Sistem Admin'in sistemi durdurup başlatabildiği ekran
        public IActionResult Maintenance()
        {
            ViewData["PageHeader"] = "Sistem Durumu & Bakım";
            return View();
        }

        // Yetki Güncelleme İşlemi (Backend bağlandığında API'ye RoleId ve PermissionList gönderecek)
        [HttpPost]
        public IActionResult UpdatePermissions(string roleId, List<string> permissions)
        {
            // Senior Tip: Burada gelen veriler API üzerinden veritabanındaki Role-Permission tablosuna yazılacak.
            return Json(new { success = true, message = "Yetkiler başarıyla güncellendi." });
        }
    }
}