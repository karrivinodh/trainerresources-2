using EcommerceWebsite.Business.Mappings;
using EcommerceWebsite.DataAccess.Concrete.Mappings;
using EcommerceWebsite.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;
using EcommerceWebsite.DataAccess.Concrete.Mappings;
using Microsoft.Extensions.Options;

//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;

namespace EcommerceWebsite.DataAccess.Concrete.Context
{
    public class DBContext : DbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Product> Products { get; set; }
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-FN225GT7\\SQLEXPRESS; DataBase=EcommerceWebsite;Integrated Security=true; TrustServerCertificate=true;");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Mappings.CategoryMap());
            modelBuilder.ApplyConfiguration(new Mappings.FeatureMap());
            modelBuilder.ApplyConfiguration(new Mappings.ProductMap());
            modelBuilder.ApplyConfiguration(new ProductImageMap());
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
      
       
        
    }
}
