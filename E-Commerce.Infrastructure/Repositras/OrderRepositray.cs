using E_Commerce.Core.DTO;
using E_Commerce.Core.Entites;
using E_Commerce.Core.Interfaces;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositras
{
    public class OrderRepositray : GenericRepositray<Order> , IOrderRepositray
    {
        private readonly ApplicationDbContext _context;

        public OrderRepositray(ApplicationDbContext context) : base(context)
        {

        }

        public  async Task AddAsyncOrder(AddOrderDto dto)
        {
            await _context.Set<AddOrderDto>().AddAsync(dto);
            await _context.SaveChangesAsync();
        }
    }
}
