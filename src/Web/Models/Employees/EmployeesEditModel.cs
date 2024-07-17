using Domain;

namespace Web.Models.Employees;

public sealed record EmployeesEditModel(
    string FirstName,
    string LastName,
    int Age,
    Gender Gender,
    int DepartmentId
)
{
    public static EmployeesEditModel From(Employee employee) =>
        new(
            employee.FirstName,
            employee.LastName,
            employee.Age,
            employee.Gender,
            employee.DepartmentId
        );
}