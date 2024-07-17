using Domain;
using Infrastructure;

namespace Application.Departments;

internal sealed class DepartmentsService(AppDbContext dbContext) : IDepartmentsService
{
    public IQueryable<Department> GetAll() => dbContext.Departments.AsQueryable();
}