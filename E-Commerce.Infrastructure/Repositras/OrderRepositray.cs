using E_Commerce.Core.Entites;
using E_Commerce.Core.Interfaces;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositras
{
    public class OrderRepositray : GenericRepositray<Order> , IOrderRepositray
    {
        public OrderRepositray(ApplicationDbContext context) : base(context)
        {

        }
    }
}
