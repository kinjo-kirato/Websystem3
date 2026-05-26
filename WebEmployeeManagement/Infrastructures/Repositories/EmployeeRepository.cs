using Microsoft.EntityFrameworkCore;
using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Applications.Repositories;
using WebEmployeeManagement.Infrastructures.Adapters;
using WebEmployeeManagement.Infrastructures.Context;

namespace WebEmployeeManagement.Infrastructures.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _dbContext;

    public EmployeeRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Employee> GetAll() => _dbContext.Employees.Include(x => x.Department).AsNoTracking().OrderBy(x => x.EmployeeId).ToList().Select(x => x.ToDomain()).ToList();

    public void Add(Employee employee)
    {
        var nextId = (_dbContext.Employees.Max(x => (int?)x.EmployeeId) ?? 0) + 1;
        employee.EmployeeId = nextId;
        _dbContext.Employees.Add(employee.ToEntity());
        _dbContext.SaveChanges();
    }
}
