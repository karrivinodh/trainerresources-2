using AutoMapper;
using EcommerceWebsite.Entities.DTO;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Business.Mappings
{
    public class FeatureMap:Profile
    {
        public FeatureMap()
        {
            CreateMap<Feature, DTOFeature>();
        }
    }
}
