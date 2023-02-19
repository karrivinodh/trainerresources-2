using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Model;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
         public async Task<IEnumerable<IActionResult>>> GetAll()
        {
            var product = new  List <Product>()
            {
                new Product
                {
                    productId=1,
                    productName="kkkklkdj",
                },
                new Product
                {
                    productId=2,
                    productName="viojjdkd",
                }

            };
            return Ok(product);
        }
        
    }
}
