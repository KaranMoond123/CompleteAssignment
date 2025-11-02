using System.ComponentModel.DataAnnotations;

namespace CompleteAssignment.Entities.Departments;

public class Department
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
