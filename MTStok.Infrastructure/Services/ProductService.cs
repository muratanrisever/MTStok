using MTStok.Application.DTOs.Category;
using MTStok.Application.DTOs.Products;
using MTStok.Application.Interfaces;
using MTStok.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTStok.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ProductListDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();

            return products.Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                ProductCode = p.ProductCode,
                StockQuantity = p.StockQuantity,
                Price = p.Price,
                CategoryName = categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name ?? "Kategorisiz"
            });
        }

        public async Task CreateProductAsync(ProductCreateUpdateDto dto)
        {
            var categoryExists = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            if (categoryExists == null)
                throw new Exception("Seçilen kategori sistemde bulunamadı. Lütfen önce kategoriyi oluşturun.");

            var product = new Product
            {
                Name = dto.Name,
                ProductCode = dto.ProductCode,
                CategoryId = dto.CategoryId,
                StockQuantity = dto.StockQuantity,
                Price = dto.Price
            };
            await _productRepository.AddAsync(product);
        }

        public async Task CreateProductsBulkAsync(List<ProductCreateUpdateDto> dtos)
        {
            var allCategories = await _categoryRepository.GetAllAsync();

            foreach (var dto in dtos)
            {
                var category = allCategories.FirstOrDefault(c => c.Name.Equals(dto.CategoryName, StringComparison.OrdinalIgnoreCase));

                if (category == null)
                    throw new Exception($"'{dto.Name}' isimli ürün eklenemedi. '{dto.CategoryName}' isimli kategori sistemde bulunamadı. Lütfen önce kategoriyi oluşturun.");

                var product = new Product
                {
                    Name = dto.Name,
                    ProductCode = dto.ProductCode,
                    CategoryId = category.Id,
                    StockQuantity = dto.StockQuantity,
                    Price = dto.Price
                };
                await _productRepository.AddAsync(product);
            }
        }

        public Task<ProductListDto?> GetProductByIdAsync(Guid id) => throw new NotImplementedException();
        public Task UpdateProductAsync(Guid id, ProductCreateUpdateDto dto) => throw new NotImplementedException();
        public Task DeleteProductAsync(Guid id) => throw new NotImplementedException();
    }
}