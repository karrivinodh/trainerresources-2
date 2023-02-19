using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeWebApi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
