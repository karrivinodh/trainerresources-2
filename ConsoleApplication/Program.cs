using Microsoft.IdentityModel.Tokens;
using NewtonSoftjson;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNet.WebApi.Core;




namespace ConsoleApplication
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49986/");
                var response = await client.GetAsync("api/MenuItem");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var menuItems = JsonConvert.DeserializeObject<MenuItem>(content);

                    Console.WriteLine("Menu Items:");
                    foreach (var item in menuItems)
                    {
                        Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Error retrieving menu items.");
                }
            }

            Console.WriteLine("Enter the Id of the menu item you want to order:");
            var selectedId = Console.ReadLine();
            // Code to order the selected menu item



            // Code to retrieve the menu items

            Console.WriteLine("Enter the Id of the menu item you want to order:");
            var selectedId = Console.ReadLine();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44305/");
                var content = new StringContent(JsonConvert.SerializeObject(selectedId), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Order", content);
                if (response.IsSuccessStatusCode)
                {
                    //var content = await response.Content.ReadAsStringAsync();
                    var cartItem = JsonConvert.DeserializeObject<Cart>(content);
                    
                    Console.WriteLine($"Order placed. Item: {cartItem.menuItemName}");
                }
                else
                {
                    Console.WriteLine("Error placing order.");
                }
            }
        }
    }

    private string GenerateJSONWebToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



        var token = new JwtSecurityToken(
                    issuer: "mySystem",
                    audience: "myUsers",
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
    

