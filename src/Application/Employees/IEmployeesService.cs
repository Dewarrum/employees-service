using Domain;

namespace Application.Employees;

public interface IEmployeesService
{
    IQueryable<Employee> GetById(int id);
    IQueryable<Employee> GetAll();
    Task<Employee> Create(CreateEmployeeRequest request);
    Task<Employee> Edit(EditEmployeeRequest request);
}