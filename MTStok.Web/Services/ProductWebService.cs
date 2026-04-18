using MTStok.Application.DTOs.Category;
using MTStok.Application.DTOs.Products;

namespace MTStok.Web.Services
{
    public class ProductWebService
    {
        private readonly HttpClient _httpClient;

        public ProductWebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryListDto>> GetAllCategoriesAsync()
        {
            try { return await _httpClient.GetFromJsonAsync<List<CategoryListDto>>("api/categories") ?? new List<CategoryListDto>(); }
            catch { return new List<CategoryListDto>(); }
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/categories", dto);

            if (response.IsSuccessStatusCode)
                return true;

            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"API Hatası ({response.StatusCode}): {errorMessage}");
        }

        public async Task<List<ProductListDto>> GetAllAsync()
        {
            try { return await _httpClient.GetFromJsonAsync<List<ProductListDto>>("api/products") ?? new List<ProductListDto>(); }
            catch { return new List<ProductListDto>(); }
        }

        public async Task<bool> CreateAsync(ProductCreateUpdateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", dto);
            return response.IsSuccessStatusCode;
        }
    }
}