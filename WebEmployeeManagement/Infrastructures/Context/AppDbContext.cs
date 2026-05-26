using Microsoft.EntityFrameworkCore;
using WebEmployeeManagement.Infrastructures.Entities;

namespace WebEmployeeManagement.Infrastructures.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<EmployeeEntity> Employees => Set<EmployeeEntity>();
    public DbSet<DepartmentEntity> Departments => Set<DepartmentEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentEntity>().ToTable("departments").HasKey(x => x.DepartmentId);
        modelBuilder.Entity<DepartmentEntity>().Property(x => x.DepartmentId).HasColumnName("department_id");
        modelBuilder.Entity<DepartmentEntity>().Property(x => x.DepartmentName).HasColumnName("department_name");

        modelBuilder.Entity<EmployeeEntity>().ToTable("employees").HasKey(x => x.EmployeeId);
        modelBuilder.Entity<EmployeeEntity>().Property(x => x.EmployeeId).HasColumnName("employee_id");
        modelBuilder.Entity<EmployeeEntity>().Property(x => x.EmployeeName).HasColumnName("employee_name");
        modelBuilder.Entity<EmployeeEntity>().Property(x => x.DepartmentId).HasColumnName("department_id");
        modelBuilder.Entity<EmployeeEntity>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.DepartmentId);
    }
}
