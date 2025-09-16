using E_Commerce.Core.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.DTO
{
    public record ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public ICollection<PhotoDTO> Photos { get; set; } 
        public List<OrderItemDTO> OrderItems { get; set; } 
    }
    public record PhotoDTO
    {
        public string IamgName { get; set; }
        public int ProductId { get; set; }
    }
    public record OrderItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
    public record AddProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public IFormFileCollection Photos { get; set; }
    }
    public record UpdateProductDTO : AddProductDTO
    {
        public int Id { get; set; }
    }
}
