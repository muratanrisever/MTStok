using MTStok.Application.DTOs.Category;

namespace MTStok.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CategoryCreateDto dto);
    }
}