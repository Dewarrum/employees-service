using Application.Employees;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmployeesService, EmployeesService>();
    }
}