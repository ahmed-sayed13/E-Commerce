using AutoMapper;
using E_Commerce.Core.DTO;
using E_Commerce.Core.Entites;
using System.Collections.Specialized;

namespace E_Commerce.API.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();

        }
          
        


    }
}
