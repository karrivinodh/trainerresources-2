using AutoMapper;
using EcommerceWebsite.Entities.DTO;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Business.Mappings
{
    public class ProductMap:Profile
    {
        public ProductMap()
        {
            CreateMap<Product, DTOProduct>()
                .ForMember(dest => dest.Id, f => f.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, f => f.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, f => f.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProductImages, f => f.MapFrom(src => src.ProductImages))
                .ForMember(dest => dest.Feature, f => f.MapFrom(src => src.Feature))
                .ForMember(dest => dest.Category, f => f.MapFrom(src => src.Category));
        }
    }
}
