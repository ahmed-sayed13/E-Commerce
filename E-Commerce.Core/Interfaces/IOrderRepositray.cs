using E_Commerce.Core.DTO;
using E_Commerce.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Interfaces
{
    public interface IOrderRepositray: IGenericRepositray<Order>
    {
        Task AddAsyncOrder(AddOrderDto dto);
    }
}
