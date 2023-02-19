using EcommerceWebsite.Entities.DTO;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Business.Services
{
    public interface ProductService
    {
        Product Get(int id);
        List<DTOProduct> GetList();
        List<DTOProduct> GetList(int? categoryId);
    }
}
