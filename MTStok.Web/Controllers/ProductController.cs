using Microsoft.AspNetCore.Mvc;

namespace MTStok.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product/Index
        public IActionResult Index()
        {
            ViewData["PageHeader"] = "Ürün Yönetimi";
            return View();
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            ViewData["PageHeader"] = "Yeni Ürün Ekle";
            return View();
        }
    }
}