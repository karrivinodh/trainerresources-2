using EcommerceWebsite.Core.DataAccess;
using EcommerceWebsite.DataAccess.Abstract;
using EcommerceWebsite.DataAccess.Concrete.Context;
using EcommerceWebsite.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceWebsite.DataAccess.Concrete
{
    public class EfCategoryDal : EfRepository<DBContext, Category>, ICategoryDal
    {
        public override List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            using (var context = new DBContext())
            {
                return filter == null
                ? context.Set<Category>().Include(x => x.UpperCategories).ToList()
                : context.Set<Category>().Where(filter).Include(x => x.UpperCategories).ToList();
            }
        }
    }
}
