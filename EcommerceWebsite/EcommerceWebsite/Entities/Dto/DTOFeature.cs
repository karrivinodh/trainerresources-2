using EcommerceWebsite.Core.Entities;

namespace EcommerceWebsite.Entities.DTO
{
    public class DTOFeature:IDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string ColorName { get; set; }
        public int UnitsInStock { get; set; }
        public string PaymentOptions { get; set; }
    }
}
