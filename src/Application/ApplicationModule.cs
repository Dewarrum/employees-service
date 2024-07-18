using Application.Departments;
using Application.Employees;
using Application.ProgrammingLanguages;
using Application.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddScoped<IEmployeesService, EmployeesService>();
        services.AddScoped<IDepartmentsService, DepartmentsService>();
        services.AddScoped<IProgrammingLanguagesService, ProgrammingLanguagesService>();
        services.AddScoped<IPasswordHasher>(_ => CreatePasswordHasher(configuration));
        services.AddScoped<IUsersService, UsersService>();
    }

    private static PasswordHasher CreatePasswordHasher(IConfigurationManager configuration)
    {
        var salt = configuration.GetRequiredSection("Passwords:Salt").Value;
        if (string.IsNullOrWhiteSpace(salt))
        {
            throw new InvalidOperationException("Passwords:Salt is empty");
        }

        return new PasswordHasher(Convert.FromBase64String(salt));
    }
}