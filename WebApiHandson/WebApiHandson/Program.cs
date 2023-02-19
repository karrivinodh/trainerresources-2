using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using WebApiHandson.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("Con");
builder.Services.AddDbContext<WebApiHandsonContext>(options => options.UseSqlServer(connection));
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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
