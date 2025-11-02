using CompleteAssignment.Dtos;

namespace CompleteAssignment.Services.Employees;

public interface IEmployeeService
{
    Task<IEnumerable<GetAllEmployeeDto>> GetMinAndMaxSalary();
    Task<GetAverageSalaryDto> GetAverageSalary();
    Task<GetDepartmentWithEmpCountDto> GetDepartmentWithEmpCount();

}
