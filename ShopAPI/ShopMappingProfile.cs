using AutoMapper;
using ShopAPI.Entities;
using ShopAPI.Models;

namespace ShopAPI
{
    public class ShopMappingProfile : Profile
    {
        private readonly IMapper _mapper;

        public ShopMappingProfile(IMapper mapper)
        {
            _mapper = mapper;

            CreateMap<Shop, ShopDto>()
                .ForMember(s => s.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(s => s.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(s => s.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Product, ProductDto>();
        }
        
       
        
    }
}
