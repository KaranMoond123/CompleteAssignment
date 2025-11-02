namespace CompleteAssignment.Dtos;

public class GetAllEmployeeDto
{
    public string DepartmentName { get; set; }
    public decimal HighestSalary { get; set; }
    public decimal LowestSalary {  get; set; }
    public int EmployeeCount {  get; set; }
}
