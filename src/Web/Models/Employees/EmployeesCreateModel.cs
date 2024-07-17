using Domain;

namespace Web.Models.Employees;

public sealed record EmployeesCreateModel(
    string FirstName,
    string LastName,
    int Age,
    Gender Gender,
    int DepartmentId,
    int ProgrammingLanguageId
);