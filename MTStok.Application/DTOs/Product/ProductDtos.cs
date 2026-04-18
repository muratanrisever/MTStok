using System;

namespace MTStok.Application.DTOs.Products
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductCreateUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public string? CategoryName { get; set; }
    }
}