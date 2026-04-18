using Microsoft.AspNetCore.Mvc;

namespace MTStok.Web.Controllers
{
    public class LogController : Controller
    {
        // GET: /Log/Index
        public IActionResult Index()
        {
            ViewData["PageHeader"] = "Sistem Logları";
            return View();
        }
    }
}