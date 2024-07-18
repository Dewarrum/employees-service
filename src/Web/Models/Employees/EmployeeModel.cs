using Domain;

namespace Web.Models.Employees;

public sealed record EmployeeModel(
    int Id,
    string FirstName,
    string LastName,
    int Age,
    Gender Gender,
    int DepartmentId,
    string DepartmentName,
    string? ProgrammingLanguageName
)
{
    public static EmployeeModel From(Employee employee) => new(
        employee.Id,
        employee.FirstName,
        employee.LastName,
        employee.Age,
        employee.Gender,
        employee.DepartmentId,
        employee.Department.Name,
        employee.WorkingExperiences.FirstOrDefault()?.ProgrammingLanguage.Name
    );
}