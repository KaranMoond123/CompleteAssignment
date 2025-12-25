using CompleteAssignment.Entities.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompleteAssignment.Entities.Salaries;

public class Salary
{
    [Key]
    public int Id { get; set; }
    public decimal Amount { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
   // public Employee Employee { get; set; }
}
