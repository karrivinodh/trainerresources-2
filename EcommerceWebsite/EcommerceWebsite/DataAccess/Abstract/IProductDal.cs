using EcommerceWebsite.Core.DataAccess;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
    }
    public interface IProductPhotoDal : IRepository<ProductImage>
    {
    }
}
