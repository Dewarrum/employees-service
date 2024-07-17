using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Employees;

internal sealed class EmployeesService(AppDbContext dbContext, ILogger<EmployeesService> logger) : IEmployeesService
{
    public IQueryable<Employee> GetById(int id) => dbContext.Employees.Where(e => e.Id == id);

    public IQueryable<Employee> GetAll() => dbContext.Employees.AsQueryable();

    public async Task<Employee> Create(CreateEmployeeRequest request)
    {
        var department = await dbContext
            .Departments
            .FirstOrDefaultAsync(d => d.Id == request.DepartmentId);

        if (department == null)
            throw new ResourceNotFoundException<Department, int>(request.DepartmentId);

        var programmingLanguage = await dbContext
            .ProgrammingLanguages
            .FirstOrDefaultAsync(pl => pl.Id == request.ProgrammingLanguageId);

        if (programmingLanguage == null)
            throw new ResourceNotFoundException<ProgrammingLanguage, int>(request.ProgrammingLanguageId);

        var employee = new Employee(
            request.FirstName,
            request.LastName,
            request.Age,
            request.Gender,
            request.DepartmentId
        );

        var employeeEntry = await dbContext.Employees.AddAsync(employee);
        var workingExperience = new WorkingExperience(
            employeeEntry.Entity.Id,
            employeeEntry.Entity,
            request.ProgrammingLanguageId,
            programmingLanguage,
            DateTime.UtcNow
        );

        await dbContext.WorkingExperiences.AddAsync(workingExperience);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Employee '{Id}' successfully created", employee.Id);

        return employee;
    }

    public async Task<Employee> Edit(EditEmployeeRequest request)
    {
        var employee = await dbContext
            .Employees
            .FirstOrDefaultAsync(e => e.Id == request.Id);
        
        if (employee == null)
            throw new ResourceNotFoundException<Employee, int>(request.Id);

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Age = request.Age;
        employee.Gender = request.Gender;
        employee.DepartmentId = request.DepartmentId;

        await dbContext.SaveChangesAsync();

        logger.LogInformation("Employee '{Id}' successfully edited", employee.Id);
        
        return employee;
    }
}