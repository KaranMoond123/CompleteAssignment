using CompleteAssignment.DbContexts;
using CompleteAssignment.Services.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompleteAssignment.Controllers.Employees;

[Route("api/analytics/")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public AnalyticsController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
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

}
