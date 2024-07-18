using Application.Departments;
using Application.Employees;
using Application.ProgrammingLanguages;
using Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmployeesService, EmployeesService>();
        services.AddScoped<IDepartmentsService, DepartmentsService>();
        services.AddScoped<IProgrammingLanguagesService, ProgrammingLanguagesService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUsersService, UsersService>();
    }
}