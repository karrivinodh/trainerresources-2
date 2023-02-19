using Microsoft.EntityFrameworkCore;

namespace Practice.Model
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions options):base(options) { }
       public DbSet<Product> Products { get; set; } 
    }
}
