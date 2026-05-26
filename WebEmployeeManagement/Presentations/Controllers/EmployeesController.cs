using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebEmployeeManagement.Applications.Service;
using WebEmployeeManagement.Presentations.Adapter;
using WebEmployeeManagement.Presentations.ViewModels;

namespace WebEmployeeManagement.Presentations.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    public EmployeesController(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }

    public IActionResult Index()
    {
        var models = _employeeService.GetAll().Select(x => x.ToViewModel()).ToList();
        return View(models);
    }

    public IActionResult Create()
    {
        SetDepartmentOptions();
        return View(new EmployeeViewModel());
    }

    [HttpPost]
    public IActionResult Create(EmployeeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            SetDepartmentOptions();
            return View(model);
        }

        if (!_departmentService.ExistsById(model.DepartmentId))
        {
            ViewBag.ErrorMessage = "指定された部署IDは存在しません。";
            SetDepartmentOptions();
            return View(model);
        }

        _employeeService.Add(model.ToDomain());
        return RedirectToAction(nameof(Index));
    }

    private void SetDepartmentOptions()
    {
        ViewBag.Departments = _departmentService.GetAll().Select(d => new SelectListItem
        {
            Value = d.DepartmentId.ToString(),
            Text = d.DepartmentName
        }).ToList();
    }
}
