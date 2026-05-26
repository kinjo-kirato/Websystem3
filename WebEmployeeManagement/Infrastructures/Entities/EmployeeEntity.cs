namespace WebEmployeeManagement.Infrastructures.Entities;

public class EmployeeEntity
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public DepartmentEntity? Department { get; set; }
}
