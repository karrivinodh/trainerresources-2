using Microsoft.EntityFrameworkCore;

namespace EmployeesHandson.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

    }
}
