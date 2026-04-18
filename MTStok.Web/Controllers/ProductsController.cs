using Microsoft.AspNetCore.Mvc;
using MTStok.Web.Services;

namespace MTStok.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductWebService _productService;

        public ProductsController(ProductWebService productService)
        {
            _productService = productService;
        }

        // GET: /Product/Index
        public async Task<IActionResult> Index()
        {
            ViewData["PageHeader"] = "Ürün Yönetimi";

            var products = await _productService.GetAllAsync();

            return View(products);
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            ViewData["PageHeader"] = "Yeni Ürün Ekle";
            return View();
        }
    }
}