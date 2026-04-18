using MTStok.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTStok.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListDto>> GetAllProductsAsync();
        Task<ProductListDto?> GetProductByIdAsync(Guid id);
        Task CreateProductAsync(ProductCreateUpdateDto dto);
        Task CreateProductsBulkAsync(List<ProductCreateUpdateDto> dtos);
        Task UpdateProductAsync(Guid id, ProductCreateUpdateDto dto);
        Task DeleteProductAsync(Guid id);
    }
}