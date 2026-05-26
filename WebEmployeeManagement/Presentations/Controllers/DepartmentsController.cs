using Microsoft.AspNetCore.Mvc;
using WebEmployeeManagement.Applications.Service;
using WebEmployeeManagement.Presentations.Adapter;
using WebEmployeeManagement.Presentations.ViewModels;

namespace WebEmployeeManagement.Presentations.Controllers;

public class DepartmentsController : Controller
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public IActionResult Index()
    {
        var models = _departmentService.GetAll().Select(x => x.ToViewModel()).ToList();
        return View(models);
    }

    public IActionResult Create() => View(new DepartmentViewModel());

    [HttpPost]
    public IActionResult Create(DepartmentViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _departmentService.Add(model.ToDomain());
        return RedirectToAction(nameof(Index));
    }
}
