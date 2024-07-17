using Domain;

namespace Web.Models.Departments;

public sealed record DepartmentModel(
    int Id,
    string Name,
    int Floor
)
{
    public static DepartmentModel From(Department department) => new(
        department.Id,
        department.Name,
        department.Floor
    );
}