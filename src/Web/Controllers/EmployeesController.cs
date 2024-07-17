﻿using Application.Departments;
using Application.Employees;
using Application.ProgrammingLanguages;
using Domain;
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

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(EmployeesCreateModel dto)
    {
        await employeesService.Create(new CreateEmployeeRequest(
            dto.FirstName,
            dto.LastName,
            dto.Age,
            dto.Gender,
            dto.DepartmentId,
            dto.ProgrammingLanguageId
        ));

        return RedirectToAction("Index");
    }
}