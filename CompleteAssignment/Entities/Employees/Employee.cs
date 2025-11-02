using CompleteAssignment.Entities.Departments;
using CompleteAssignment.Entities.Salaries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompleteAssignment.Entities.Employees;

public class Employee
{
    [Key]
    public int Id {  get; set; }
    public string Name { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public DateTime HireDate { get; set; }

    public Salary Salary { get; set; }
}
