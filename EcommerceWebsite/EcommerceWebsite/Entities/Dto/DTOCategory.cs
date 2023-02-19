using EcommerceWebsite.Core.Entities;

namespace EcommerceWebsite.Entities.DTO
{
    public class DTOCategory:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public bool IsMain { get; set; }
        public int UpperCategoryId { get; set; }
        public List<DtoSubCategory> SubCategories { get; set; }
    }
    public class DtoSubCategory : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

