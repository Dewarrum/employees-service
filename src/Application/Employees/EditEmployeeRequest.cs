using Domain;

namespace Application.Employees;

public sealed record EditEmployeeRequest(
    int Id,
    string FirstName,
    string LastName,
    int Age,
    Gender Gender,
    int DepartmentId
);