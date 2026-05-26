using WebEmployeeManagement.Applications.Domains;

namespace WebEmployeeManagement.Applications.Repositories;

public interface IDepartmentRepository
{
    List<Department> GetAll();
    bool ExistsById(int departmentId);
    void Add(Department department);
}
