using EcommerceWebsite.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriesController : ControllerBase
    {
        CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult GetCategories(bool? isMain)
        {
            var categories = _categoryService.GetList(isMain: isMain);
            return Ok(categories);
        }
    }

}