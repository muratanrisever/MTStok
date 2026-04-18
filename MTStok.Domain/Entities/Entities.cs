using System;
using System.Collections.Generic;

namespace MTStok.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }

    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}