using WebEmployeeManagement.Applications.Domains;

namespace WebEmployeeManagement.Applications.Repositories;

public interface IEmployeeRepository
{
    List<Employee> GetAll();
    void Add(Employee employee);
}
