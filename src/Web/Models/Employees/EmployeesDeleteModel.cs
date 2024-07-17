using Domain;

namespace Web.Models.Employees;

public sealed record EmployeesDeleteModel(int Id, string FirstName, string LastName)
{
    public static EmployeesDeleteModel From(Employee employee) =>
        new(employee.Id, employee.FirstName, employee.LastName);
}