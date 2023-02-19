using EcommerceWebsite.Entities.DTO;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Business.Services
{
    public interface CategoryService
    {
        Category Get(int id);
        List<DTOCategory> GetList(bool? isMain = null);
    }
}
