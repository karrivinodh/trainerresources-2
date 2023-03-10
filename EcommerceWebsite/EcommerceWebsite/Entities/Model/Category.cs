using EcommerceWebsite.Core.Entities;

namespace EcommerceWebsite.Entities.Model
{
    public class Category: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int UpperCategoryId { get; set; }
        public string Photo { get; set; }
        public virtual Category UpperCategory { get; set; }
        public List<Category> UpperCategories { get; set; }


    }
}
