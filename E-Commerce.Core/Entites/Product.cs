using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites
{
    public class Product: BaseEntity<int>
    {
      
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
       
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
