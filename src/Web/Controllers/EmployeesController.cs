using Application.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models.Employees;

namespace Web.Controllers;

public sealed class EmployeesController : Controller
{
    private readonly IEmployeesService _employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        _employeesService = employeesService;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _employeesService
            .GetAll()
            .AsNoTracking()
            .Select(e => EmployeeModel.From(e))
            .ToListAsync();

        return View(new EmployeesIndexModel(employees));
    }
}