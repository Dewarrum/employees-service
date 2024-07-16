using Domain;

namespace Application.Employees;

public sealed record CreateEmployeeRequest(
    string FirstName,
    string LastName,
    int Age,
    Gender Gender,
    int DepartmentId
);