using AutoMapper;
using ShopAPI.Entities;
using ShopAPI.Models;

namespace ShopAPI
{
    public class ShopMappingProfile : Profile
    {
        public ShopMappingProfile()
        {
            CreateMap<Shop, ShopDto>()
                .ForMember(s => s.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(s => s.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(s => s.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Product, ProductDto>();
        }



    }
}
