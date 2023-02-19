using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;
using Microsoft.OpenApi;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conStr = builder.Configuration.GetConnectionString("Con");
builder.Services.AddDbContext<DBContext>(con => con.UseSqlServer(conStr));



// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

////Addition3 - JSON Serializer
builder.Services.AddControllersWithViews()
 .AddNewtonsoftJson(options =>
 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
 .Json.ReferenceLoopHandling.Ignore)
 .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
 = new DefaultContractResolver());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string securityKey = "mysuperdupersecret";
var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
  builder.Services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           x.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    })
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        //what to validate
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //setup validate data
        ValidIssuer = "mySystem",
        ValidAudience = "myUsers",
        IssuerSigningKey = symmetricSecurityKey
    };
});
builder.Services.AddAuthorization();
var app = builder.Build();
app.UseHttpsRedirection();
app.MapGet("/security/getMessage", () => "Hello World!").RequireAuthorization();
app.MapPost("/security/createToken",
              [AllowAnonymous] (User user) =>
              {
                  if (user.UserRole == "Admin" && user.UserId != null)
                  {
                      var issuer = builder.Configuration["Jwt:Issuer"];
                      var audience = builder.Configuration["Jwt:Audience"];
                      var key = Encoding.ASCII.GetBytes
                       (builder.Configuration["Jwt:Key"]);
                      var tokenDescriptor = new SecurityTokenDescriptor
                      {
                          Subject = new ClaimsIdentity(new[]
                           {
                            //  new Claim("Id", Guid.NewGuid().ToString()),
                              new Claim("UserId",user.UserId.ToString()),
                              new Claim("UserName",user.UserRole),
                             // new Claim(JwtRegisteredClaimNames.NameId, user.UserId),
                             // new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                     //new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),


                             // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                          }),
                          Expires = DateTime.UtcNow.AddMinutes(10),
                          Issuer = issuer,
                          Audience = audience,
                          SigningCredentials = new SigningCredentials
                           (new SymmetricSecurityKey(key),
                           SecurityAlgorithms.HmacSha512Signature)
                      };
                      var tokenHandler = new JwtSecurityTokenHandler();
                      var token = tokenHandler.CreateToken(tokenDescriptor);
                      var jwtToken = tokenHandler.WriteToken(token);
                      var stringToken = tokenHandler.WriteToken(token);
                      return Results.Ok(stringToken);
                  }
                  return Results.Unauthorized();
              });


//var app = builder.Build();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
