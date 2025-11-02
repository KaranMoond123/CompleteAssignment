using CompleteAssignment.Entities.Departments;
using CompleteAssignment.Entities.Employees;
using CompleteAssignment.Entities.Salaries;
using Microsoft.EntityFrameworkCore;

namespace CompleteAssignment.DbContexts;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {      
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Salary> Salaries { get; set; }
}
