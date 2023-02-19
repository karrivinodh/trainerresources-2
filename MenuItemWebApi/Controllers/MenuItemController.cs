using MenuItemWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace MenuItemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class MenuItemController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            // Hard-coded list of MenuItem objects
            return new List<MenuItem>
        {
            new MenuItem { Id = 1, Name = "Pizza", freeDelivery = true, Price = 12.99, dateOfLaunch = new DateTime(2020, 1, 1), Active = true },
            new MenuItem { Id = 2, Name = "Burger", freeDelivery = false, Price = 9.99, dateOfLaunch = new DateTime(2020, 2, 1), Active = true },
            new MenuItem { Id = 3, Name = "Pasta", freeDelivery = true, Price = 15.99, dateOfLaunch = new DateTime(2020, 3, 1), Active = true },
        };
        }

        [HttpGet("{id}")]
        public ActionResult<MenuItem> Get(int id)
        {
            var menuItems = new List<MenuItem>
        {
            new MenuItem { Id = 1, Name = "Pizza", freeDelivery = true, Price = 12.99, dateOfLaunch = new DateTime(2020, 1, 1), Active = true },
            new MenuItem { Id = 2, Name = "Burger", freeDelivery = false, Price = 9.99, dateOfLaunch = new DateTime(2020, 2, 1), Active = true },
            new MenuItem { Id = 3, Name = "Pasta", freeDelivery = true, Price = 15.99, dateOfLaunch = new DateTime(2020, 3, 1), Active = true },
        };
            var menuitem = menuItems.Find(x => x.Id == id);
            if (menuitem == null)
            {
                return NotFound();
            }

            return menuitem;
        }
    }


}