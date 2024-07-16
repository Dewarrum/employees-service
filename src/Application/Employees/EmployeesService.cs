using Domain;
using Infrastructure;
using Microsoft.Extensions.Logging;

namespace Application.Employees;

internal sealed class EmployeesService : IEmployeesService
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<EmployeesService> _logger;

    public EmployeesService(AppDbContext dbContext, ILogger<EmployeesService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IQueryable<Employee> GetAll() => _dbContext.Employees.AsQueryable();

    public async Task<Employee> Create(CreateEmployeeRequest request)
    {
        var employee = new Employee(
            request.FirstName,
            request.LastName,
            request.Age,
            request.Gender,
            request.DepartmentId
        );

        _dbContext.Employees.Add(employee);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Employee '{Id}' successfully created", employee.Id);

        return employee;
    }
}