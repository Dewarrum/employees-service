using Application.Departments;
using Application.Employees;
using Application.ProgrammingLanguages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Models.Departments;
using Web.Models.Employees;
using Web.Models.ProgrammingLanguages;

namespace Web.Controllers;

public sealed class EmployeesController(
    IEmployeesService employeesService,
    IDepartmentsService departmentsService,
    IProgrammingLanguagesService programmingLanguagesService)
    : Controller
{
    private static readonly IReadOnlyList<string> FirstNames =
    [
        "Иван", "Петр", "Николай", "Василий", "Максим", "Александр", "Евгений", "Дмитрий", "Игорь", "Олег", "Павел",
        "Сергей", "Юрий"
    ];

    private static readonly IReadOnlyList<string> LastNames =
    [
        "Иванов", "Петров", "Николаев", "Васильев", "Максимов", "Александров", "Евгеньев", "Дмитриев", "Игорев",
        "Олегов", "Павлов", "Сергеев", "Юрьев"
    ];

    public async Task<IActionResult> Index()
    {
        var employees = await employeesService
            .GetAll()
            .AsNoTracking()
            .Include(e => e.Department)
            .Select(e => EmployeeModel.From(e))
            .ToListAsync();

        return View(new EmployeesIndexModel(employees));
    }

    public async Task<IActionResult> Add()
    {
        var departments = await departmentsService
            .GetAll()
            .AsNoTracking()
            .Select(d => DepartmentModel.From(d))
            .ToListAsync();

        var programmingLanguages = await programmingLanguagesService
            .GetAll()
            .AsNoTracking()
            .Select(pl => ProgrammingLanguageModel.From(pl))
            .ToListAsync();

        ViewBag.Departments = new SelectList(
            departments,
            nameof(DepartmentModel.Id),
            nameof(DepartmentModel.Name)
        );
        ViewBag.ProgrammingLanguages = new SelectList(
            programmingLanguages,
            nameof(ProgrammingLanguageModel.Id),
            nameof(ProgrammingLanguageModel.Name)
        );
        ViewBag.FirstNames = FirstNames;
        ViewBag.LastNames = LastNames;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(EmployeesCreateModel model)
    {
        await employeesService.Create(new CreateEmployeeRequest(
            model.FirstName,
            model.LastName,
            model.Age,
            model.Gender,
            model.DepartmentId,
            model.ProgrammingLanguageId
        ));

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var employee = await employeesService
            .GetById(id)
            .AsNoTracking()
            .Select(e => EmployeesEditModel.From(e))
            .FirstOrDefaultAsync();

        if (employee == null)
            return NotFound();

        var departments = await departmentsService
            .GetAll()
            .AsNoTracking()
            .Select(d => DepartmentModel.From(d))
            .ToListAsync();

        var programmingLanguages = await programmingLanguagesService
            .GetAll()
            .AsNoTracking()
            .Select(pl => ProgrammingLanguageModel.From(pl))
            .ToListAsync();

        ViewBag.Departments = new SelectList(
            departments,
            nameof(DepartmentModel.Id),
            nameof(DepartmentModel.Name)
        );
        ViewBag.ProgrammingLanguages = new SelectList(
            programmingLanguages,
            nameof(ProgrammingLanguageModel.Id),
            nameof(ProgrammingLanguageModel.Name)
        );

        ViewBag.FirstNames = FirstNames;
        ViewBag.LastNames = LastNames;

        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EmployeesEditModel model)
    {
        await employeesService.Edit(new EditEmployeeRequest(
            id,
            model.FirstName,
            model.LastName,
            model.Age,
            model.Gender,
            model.DepartmentId
        ));

        return RedirectToAction("Edit", new { id });
    }
}