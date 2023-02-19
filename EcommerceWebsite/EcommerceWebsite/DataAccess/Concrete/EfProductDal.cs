using EcommerceWebsite.Core.DataAccess;
using EcommerceWebsite.DataAccess.Abstract;
using EcommerceWebsite.DataAccess.Concrete.Context;
using EcommerceWebsite.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceWebsite.DataAccess.Concrete
{
    public class EfProductDal : EfRepository<DBContext, Product>, IProductDal
    {
        public override List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new DBContext())
            {
                return filter == null
                ? context.Set<Product>()
                .Include(x => x.ProductImages)
                .Include(x => x.Feature)
                .Include(x => x.Category)
                .Include(x => x.Category.UpperCategories).ToList()

                : context.Set<Product>().Where(filter)
                .Include(x => x.ProductImages)
                .Include(x => x.Feature)
                .Include(x => x.Category)
                .Include(x => x.Category.UpperCategories).ToList();
            }
        }
    }
    public class EfProductPhotoDal : EfRepository<DBContext, ProductImage>, IProductPhotoDal
    {
    }
}
