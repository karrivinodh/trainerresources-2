using EmployeeHandson_29.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System;

var builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

