using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Infrastructures.Entities;

namespace WebEmployeeManagement.Infrastructures.Adapters;

public static class DomainEntityAdapter
{
    public static Department ToDomain(this DepartmentEntity e) => new() { DepartmentId = e.DepartmentId, DepartmentName = e.DepartmentName };
    public static DepartmentEntity ToEntity(this Department d) => new() { DepartmentId = d.DepartmentId, DepartmentName = d.DepartmentName };
    public static Employee ToDomain(this EmployeeEntity e) => new() { EmployeeId = e.EmployeeId, EmployeeName = e.EmployeeName, DepartmentId = e.DepartmentId, DepartmentName = e.Department?.DepartmentName ?? string.Empty };
    public static EmployeeEntity ToEntity(this Employee d) => new() { EmployeeId = d.EmployeeId, EmployeeName = d.EmployeeName, DepartmentId = d.DepartmentId };
}
