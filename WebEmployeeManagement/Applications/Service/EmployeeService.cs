using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Applications.Repositories;

namespace WebEmployeeManagement.Applications.Service;

public interface IEmployeeService
{
    List<Employee> GetAll();
    void Add(Employee employee);
}

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public List<Employee> GetAll() => _employeeRepository.GetAll();
    public void Add(Employee employee) => _employeeRepository.Add(employee);
}
