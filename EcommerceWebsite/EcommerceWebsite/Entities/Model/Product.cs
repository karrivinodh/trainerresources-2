using EcommerceWebsite.Core.Entities;

namespace EcommerceWebsite.Entities.Model
{
    public class Product: IEntity
    {
        public Product()
        {
            ProductImages = new List<ProductImage>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
