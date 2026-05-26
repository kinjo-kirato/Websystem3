using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Applications.Repositories;

namespace WebEmployeeManagement.Applications.Service;

public interface IDepartmentService
{
    List<Department> GetAll();
    bool ExistsById(int departmentId);
    void Add(Department department);
}

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public List<Department> GetAll() => _departmentRepository.GetAll();
    public bool ExistsById(int departmentId) => _departmentRepository.ExistsById(departmentId);
    public void Add(Department department) => _departmentRepository.Add(department);
}
