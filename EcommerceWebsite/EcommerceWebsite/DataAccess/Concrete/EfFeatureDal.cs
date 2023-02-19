using EcommerceWebsite.Core.DataAccess;
using EcommerceWebsite.DataAccess.Abstract;
using EcommerceWebsite.DataAccess.Concrete.Context;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.DataAccess.Concrete
{
    public class EfFeatureDal : EfRepository<DBContext, Feature>, IFeatureDal
    {
    }
}
