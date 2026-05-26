using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Presentations.ViewModels;

namespace WebEmployeeManagement.Presentations.Adapter;

public static class DepartmentViewModelAdapter
{
    public static Department ToDomain(this DepartmentViewModel vm) => new() { DepartmentId = vm.DepartmentId, DepartmentName = vm.DepartmentName };
    public static DepartmentViewModel ToViewModel(this Department d) => new() { DepartmentId = d.DepartmentId, DepartmentName = d.DepartmentName };
}
