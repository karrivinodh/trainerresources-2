using AutoMapper;
using EcommerceWebsite.Business.Services;
using EcommerceWebsite.DataAccess.Abstract;
using EcommerceWebsite.Entities.DTO;
using EcommerceWebsite.Entities.Model;

namespace EcommerceWebsite.Business.Concrete
{
    public class CategoryManager : CategoryService
    {
        ICategoryDal _categoryDal;
        private IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        public Category Get(int id)
        {
            return _categoryDal.Get(m => m.Id == id);
        }
        public List<DTOCategory> GetList(bool? isMain = null)
        {
            return isMain == null
              ? _mapper.Map<List<DTOCategory>>(_categoryDal.GetList())
              : _mapper.Map<List<DTOCategory>>(_categoryDal.GetList(m => m.IsMain == isMain));
        }
    }
    }
