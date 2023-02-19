using MenuItemWebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OrderWebApi.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
  
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Cart>> AddToCart(int Id)
        {
            int id = 1;
            int userId = 1;

            Cart cart = new Cart
            {
                Id = id,
                userId = userId,
                menuItemId = Id
            };
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49986/api/");
                var response = await client.GetAsync($"MenuItem/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var menuItem = JsonConvert.DeserializeObject<MenuItem>(content);
                    cart.menuItemName = menuItem.Name;
                    cart.Id = Id;
                    cart.userId = Id;
                }
            }

            return cart;
        }
    }
}
