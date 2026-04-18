using MTStok.Application.DTOs.Category;
using MTStok.Application.Interfaces;
using MTStok.Domain.Entities;

namespace MTStok.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryListDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task CreateCategoryAsync(CategoryCreateDto dto)
        {
            var allCategories = await _categoryRepository.GetAllAsync();

            if (allCategories.Any(c => c.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception($"'{dto.Name}' adında bir kategori zaten mevcut!");
            }

            var newCategory = new Category { Name = dto.Name };
            await _categoryRepository.AddAsync(newCategory);
        }
    }
}