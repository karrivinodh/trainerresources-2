using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public class TokenController : ControllerBase
        {
            public IConfiguration _configuration;
            private readonly DBContext _context;

            public TokenController(IConfiguration config, DBContext context)
            {
                _configuration = config;
                _context = context;
            }

            [HttpPost]

            [AllowAnonymous]



            private string GenerateJSONWebToken(int userId, string userRole)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

                var token = new JwtSecurityToken(
                            issuer: "mySystem",
                            audience: "myUsers",
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(10),
                            signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            private async Task<User> GetUser(int UserId , string UserRole)
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.UserId == UserId && u.UserRole ==UserRole);
            }


        }
    }
}

