using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Business.Services
{
    public interface FeatureService
    {
        Feature Get(int id);
        List<Feature> GetList();
    }
}
