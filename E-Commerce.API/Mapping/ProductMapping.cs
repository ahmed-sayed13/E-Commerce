using AutoMapper;
using E_Commerce.Core.DTO;
using E_Commerce.Core.Entites;

namespace E_Commerce.API.Mapping
{
    public class ProductMapping: Profile
    {
        public ProductMapping()
        {
                CreateMap<Product,ProductDto>().ReverseMap();
                CreateMap<Photo,PhotoDTO>().ReverseMap();
                CreateMap<Photo,PhotoDTO>().ReverseMap();
            CreateMap<AddProductDTO, Product>().ForMember(m => m.Photos, opt => opt.Ignore()).ReverseMap();
        }
    }
}
