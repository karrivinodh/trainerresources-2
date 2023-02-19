using EcommerceWebsite.Business.Services;
using EcommerceWebsite.DataAccess.Abstract;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Business.Concrete
{
    public class FeatureManager : FeatureService
    {
        IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }
        public Feature Get(int id)
        {
            return _featureDal.Get(m => m.Id == id);
        }
        public List<Feature> GetList()
        {
            return _featureDal.GetList();
        }
    }
}
