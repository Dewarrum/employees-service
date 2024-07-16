using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Employees = Set<Employee>();
        Departments = Set<Department>();
        WorkingExperiences = Set<WorkingExperience>();
        ProgrammingLanguages = Set<ProgrammingLanguage>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new WorkingExperienceConfiguration());
        modelBuilder.ApplyConfiguration(new ProgrammingLanguageConfiguration());
    }

    public DbSet<Employee> Employees { get; private set; }
    public DbSet<Department> Departments { get; private set; }
    public DbSet<WorkingExperience> WorkingExperiences { get; private set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; private set; }
}