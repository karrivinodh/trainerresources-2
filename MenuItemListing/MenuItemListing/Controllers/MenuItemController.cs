using MenuItemListing.Model;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuItemListing.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class MenuItemController : ControllerBase
    {
        // GET: api/<MenuItemController>
        [HttpGet]
        public List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuitems = new List<MenuItem> { new MenuItem{
                Id=1,Name="Redmi Mobile", freeDelivery=true, Active=true, dateOfLaunch=DateTime.Parse("12/01/2023"), Price=10000} ,
             new MenuItem{
                Id=2,Name="Redmi EarPhones", freeDelivery=false, Active=true, dateOfLaunch=DateTime.Parse("21/01/2023"), Price=1000} };
            return menuitems;
        }


        //GET api/<MenuItemController>/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {

            var menuitem = new MenuItem();
            if (id == 1)
            {
                menuitem.Id = 1;

                menuitem.Name = "Redmi Mobile";
                menuitem.Active = true;
                menuitem.freeDelivery = true;
                menuitem.dateOfLaunch = DateTime.Parse("12/01/2023");
                menuitem.Price = 10000;

            }
            else if (id == 2)  
            {
                menuitem.Id = 2;
                menuitem.Name = "Redmi EarPhones";
                menuitem.freeDelivery = false;
                menuitem.Active = true;
                menuitem.dateOfLaunch = DateTime.Parse("21/01/2023");
                menuitem.Price = 1000;
            }
            else
            {
                throw new Exception();
            }
            return menuitem;
        }
    }



        }

    

