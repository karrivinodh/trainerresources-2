using EcommerceWebsite.Core.Entities;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Entities.DTO
{
    public class DTOProduct:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DTOCategory Category { get; set; }
        public int FeatureId { get; set; }
        public DTOFeature Feature { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
