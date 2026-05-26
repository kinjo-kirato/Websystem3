namespace WebEmployeeManagement.Infrastructures.Entities;

public class DepartmentEntity
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public List<EmployeeEntity> Employees { get; set; } = new();
}
