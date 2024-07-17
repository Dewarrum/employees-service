using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Employees;

internal sealed class EmployeesService(AppDbContext dbContext, ILogger<EmployeesService> logger) : IEmployeesService
{
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
            DateTime.Now,
            DateTime.Now
        );

        await dbContext.WorkingExperiences.AddAsync(workingExperience);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Employee '{Id}' successfully created", employee.Id);

        return employee;
    }
}