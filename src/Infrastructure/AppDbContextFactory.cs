using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure;

public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=localhost,1433;Database=Employees;User Id=sa;Password=RootRoot!;TrustServerCertificate=True;")
            .Options
        );
    }
}