using EcommerceWebsite.Core.Entities;

namespace EcommerceWebsite.Entities.Model
{
    public class ProductImage: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
    }
}
