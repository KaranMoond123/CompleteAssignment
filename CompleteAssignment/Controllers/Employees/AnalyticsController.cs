using CompleteAssignment.DbContexts;
using CompleteAssignment.Dtos;
using CompleteAssignment.Entities.Employees;
using CompleteAssignment.Services.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompleteAssignment.Controllers.Employees;

[Route("api/analytics/")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly DataContext _context;

    public AnalyticsController(IEmployeeService employeeService, DataContext context = null)
    {
        _employeeService = employeeService;
        _context = context;
    }

    [HttpGet("salary-extremes")]
    public async Task<ActionResult> GetMinAndMaxSalary()
    {
        var data=await _employeeService.GetMinAndMaxSalary();
        return Ok(data);
    }

    [HttpGet("average-salary")]
    public async Task<ActionResult> GetAverageSalary()
    {
        var data=await _employeeService.GetAverageSalary();
        return Ok(data);
    }

    [HttpGet("top-department")]
    public async Task<ActionResult> GetDepartmentWithEmpCount()
    {
        var data = await _employeeService.GetDepartmentWithEmpCount();
        return Ok(data);
    }
    [HttpGet]
    public async Task<PageResult<Employee>> GetEmployeesPaged(
    int pageNumber, int pageSize)
    {
        var query = _context.Employees.AsQueryable();

        var totalCount = await query.CountAsync();

        var data = await query
            .OrderBy(x => x.Id)
            .Include(x => x.Department).Include(x => x.Salary)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

        return new PageResult<Employee>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = totalCount,
            Data = data
        };
    }

}
