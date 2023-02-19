using EcommerceWebsite.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            ProductService _productService;
            public ProductsController(ProductService productService)
            {
                _productService = productService;
            }
        [HttpGet]   
            public ActionResult GetProducts(int? categoryId)
            {
                var products = _productService.GetList(categoryId);
                return Ok(products);
            }
        
    }
}
