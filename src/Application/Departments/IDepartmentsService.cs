using Domain;

namespace Application.Departments;

public interface IDepartmentsService
{
    IQueryable<Department> GetAll();
}