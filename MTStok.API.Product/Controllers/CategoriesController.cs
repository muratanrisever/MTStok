using Microsoft.AspNetCore.Mvc;
using MTStok.Application.DTOs.Category;
using MTStok.Application.Interfaces;

namespace MTStok.API.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
            => Ok(await _categoryService.GetAllCategoriesAsync());

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(dto);
                return Ok(new { message = "Kategori başarıyla oluşturuldu." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}