using Microsoft.EntityFrameworkCore;
using WebEmployeeManagement.Applications.Domains;
using WebEmployeeManagement.Applications.Repositories;
using WebEmployeeManagement.Infrastructures.Adapters;
using WebEmployeeManagement.Infrastructures.Context;

namespace WebEmployeeManagement.Infrastructures.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _dbContext;

    public DepartmentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Department> GetAll() => _dbContext.Departments.AsNoTracking().OrderBy(x => x.DepartmentId).ToList().Select(x => x.ToDomain()).ToList();

    public bool ExistsById(int departmentId) => _dbContext.Departments.Any(x => x.DepartmentId == departmentId);

    public void Add(Department department)
    {
        var nextId = (_dbContext.Departments.Max(x => (int?)x.DepartmentId) ?? 0) + 1;
        department.DepartmentId = nextId;
        _dbContext.Departments.Add(department.ToEntity());
        _dbContext.SaveChanges();
    }
}
