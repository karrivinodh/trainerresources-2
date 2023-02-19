using EcommerceWebsiteDemo.Extensions;
using EcommerceWebsiteDemo.Helpers;
using EcommerceWebsiteDemo.Infrastructure.Data;
using EcommerceWebsiteDemo.Infrastructure.Identity;
using EcommerceWebsiteDemo.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using StackExchange.Redis;

namespace EcommerceWebsiteDemo
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(x =>
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>(x =>
            {
                x.UseSqlite(_config.GetConnectionString("IdentityConnection"));
            });

            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(x =>
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>(x =>
            {
                x.UseSqlite(_config.GetConnectionString("IdentityConnection"));
            });

            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfiles));
           
            services.AddControllers();

            services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(_config
                    .GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddApplicationServices();
            services.AddIdentityServices(_config);
           services.AddEndpointsApiExplorer();
          services.AddSwaggerGen();

            services.AddSwaggerDocumentation();
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
             {
                 FileProvider = new PhysicalFileProvider(
                     Path.Combine(Directory.GetCurrentDirectory(), "Content")
                 ),
                 RequestPath = "/content"
             });
           
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceWebsiteDemo"));
            }
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerDocumention();
           
         


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
