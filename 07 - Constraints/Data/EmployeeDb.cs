using Microsoft.EntityFrameworkCore;

namespace DataManager
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public EmployeeDb(DbContextOptions<EmployeeDb> options)
        : base(options)
        { }
    }
}
