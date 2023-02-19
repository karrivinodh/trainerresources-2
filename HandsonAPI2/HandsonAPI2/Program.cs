using HandsonAPI2.Model;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c =>
{
    c.SwaggerDoc("v1", new Info
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "TBD",
        TermsOfService = "None",
        Contact = new Contact() { Name = "John Doe", Email = "john@xyzmail.com", Url = "www.example.com" },
        License = new License() { Name = "License Terms", Url = "www.example.com" }
    });
}));



var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            // specifying the Swagger JSON endpoint.
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
        });
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
