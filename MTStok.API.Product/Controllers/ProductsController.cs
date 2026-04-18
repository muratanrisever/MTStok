using Microsoft.AspNetCore.Mvc;
using MTStok.Application.DTOs.Products;
using MTStok.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTStok.API.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _productService.GetAllProductsAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateUpdateDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return Ok(new { message = "Ürün eklendi" });
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<ProductCreateUpdateDto> dtos)
        {
            if (dtos == null || dtos.Count == 0) return BadRequest("Liste boş olamaz.");
            await _productService.CreateProductsBulkAsync(dtos);
            return Ok(new { message = $"{dtos.Count} ürün sisteme aktarıldı." });
        }
    }
}