using EcommerceWebsite.Business.Concrete;
using EcommerceWebsite.Business.Mappings;
using EcommerceWebsite.Business.Services;
using EcommerceWebsite.DataAccess.Abstract;
using EcommerceWebsite.DataAccess.Concrete;
using EcommerceWebsite.DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;

namespace EcommerceWebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(CategoryMap));
            services.AddAutoMapper(typeof(FeatureMap));
            services.AddAutoMapper(typeof(ProductMap));
            services.AddDbContext<DBContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Con")), ServiceLifetime.Transient);
    
            services.AddSingleton<IProductDal, EfProductDal>();
            services.AddSingleton<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<IFeatureDal, EfFeatureDal>();
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddLogging(loggingBuilder => {
                loggingBuilder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                loggingBuilder.AddDebug();
            });

            services.AddSingleton<ProductService, ProductManager>();
            services.AddSingleton<CategoryService, CategoryManager>();
            services.AddSingleton<FeatureService, FeatureManager>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcommerceWebsite", Version = "v1" });
            });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceWebsite"));

            }
            app.UseCors("CorsPolicy");


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
