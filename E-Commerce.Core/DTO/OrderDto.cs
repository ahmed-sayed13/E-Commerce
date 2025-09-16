using E_Commerce.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.DTO
{
    public record OrderDto
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending";
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }

    public record AddOrderDto
    {
        public int UserId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    }
    public record AddOrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public record OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
    public record UpdateOrderDto : AddOrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = "Pending";
    }
}

