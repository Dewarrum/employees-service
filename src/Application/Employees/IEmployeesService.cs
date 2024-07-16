using Domain;

namespace Application.Employees;

public interface IEmployeesService
{
    IQueryable<Employee> GetAll();
    Task<Employee> Create(CreateEmployeeRequest request);
}