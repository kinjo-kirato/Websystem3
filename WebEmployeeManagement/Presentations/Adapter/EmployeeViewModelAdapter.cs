using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Presentations.ViewModels;

namespace WebEmployeeManagement.Presentations.Adapter;

public static class EmployeeViewModelAdapter
{
    public static Employee ToDomain(this EmployeeViewModel vm) => new() { EmployeeId = vm.EmployeeId, EmployeeName = vm.EmployeeName, DepartmentId = vm.DepartmentId, DepartmentName = vm.DepartmentName };
    public static EmployeeViewModel ToViewModel(this Employee e) => new() { EmployeeId = e.EmployeeId, EmployeeName = e.EmployeeName, DepartmentId = e.DepartmentId, DepartmentName = e.DepartmentName };
}
