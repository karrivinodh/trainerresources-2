using AutoMapper;
using EcommerceWebsite.Business.Services;
using EcommerceWebsite.DataAccess.Abstract;
using EcommerceWebsite.Entities.DTO;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Business.Concrete
{
    public class ProductManager : ProductService
    {
        IProductDal _productDal;
        IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public Product Get(int id)
        {
            return _productDal.Get(m => m.Id == id);
        }
        public List<DTOProduct> GetList()
        {
            return _mapper.Map<List<DTOProduct>>(_productDal.GetList());
        }
        public List<DTOProduct> GetList(int? categoryId)
        {
            return categoryId != null
               ? _mapper.Map<List<DTOProduct>>(_productDal.GetList(m => m.CategoryId == categoryId))
               : _mapper.Map<List<DTOProduct>>(_productDal.GetList());
        }
    }
}