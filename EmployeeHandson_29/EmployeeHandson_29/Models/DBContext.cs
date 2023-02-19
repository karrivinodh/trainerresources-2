using Microsoft.EntityFrameworkCore;

namespace EmployeeHandson_29.Models
{
    public class DBContext:DbContext
    {
         public DBContext(DbContextOptions<DBContext>options):base(options) { }
        public DbSet<Employee> Employees { get; set; }
        
    }
}
