using Microsoft.AspNetCore.Mvc;
using MTStok.Web.Services;
using MTStok.Application.DTOs.Category;

namespace MTStok.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductWebService _productService;

        public CategoryController(ProductWebService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["PageHeader"] = "Kategori Yönetimi";
            var categories = await _productService.GetAllCategoriesAsync();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                TempData["Error"] = "Kategori adı boş bırakılamaz.";
                return RedirectToAction("Index");
            }

            try
            {
                var success = await _productService.CreateCategoryAsync(dto);
                if (success) TempData["Success"] = $"'{dto.Name}' kategorisi başarıyla eklendi.";
                else TempData["Error"] = "Kategori eklenirken bir hata oluştu.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message; // Çift kayıt hatası
            }

            return RedirectToAction("Index");
        }
    }
}