using CompleteAssignment.DbContexts;
using CompleteAssignment.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CompleteAssignment.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public async Task<GetAverageSalaryDto> GetAverageSalary()
    {
        var result = await _context.Salaries.AsNoTracking().AverageAsync(x=>x.Amount);

        var averageSalary = new GetAverageSalaryDto
        {
            Salary = result
        };

        return averageSalary;
    }

    public async Task<GetDepartmentWithEmpCountDto> GetDepartmentWithEmpCount()
    {
        var result = await _context.Employees.AsNoTracking().GroupBy(x => x.DepartmentId).Select(x => new GetDepartmentWithEmpCountDto
        {
            DepartmentName = x.Select(x => x.Department.Name).FirstOrDefault(),
            EmployeeCount = x.Count()
        }).OrderByDescending(x=>x.EmployeeCount).FirstOrDefaultAsync();

        return result;
    }

    public async Task<IEnumerable<GetAllEmployeeDto>> GetMinAndMaxSalary()
    {
        var result = await _context.Employees.AsNoTracking().GroupBy(x => x.DepartmentId).Select(x => new GetAllEmployeeDto
        {
            DepartmentName = x.Select(y => y.Department.Name).FirstOrDefault(),
            HighestSalary = x.Max(y => y.Salary.Amount),
            LowestSalary = x.Min(y => y.Salary.Amount),
            EmployeeCount = x.Count()
        }).ToListAsync();

        return result;
    }
}
