using CompleteAssignment.DbContexts;
using CompleteAssignment.Services.Employees;
using Microsoft.EntityFrameworkCore;

namespace CompleteAssignment.Services;

public static class ServiceCollectionExtension
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepository();
    }
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddTransient<IEmployeeService, EmployeeService>();
    }
}
