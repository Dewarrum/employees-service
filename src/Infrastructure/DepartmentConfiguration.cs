using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).IsRequired();
        builder.Property(d => d.Floor).IsRequired();
        builder.HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired();

        builder.HasData(
            new Department
            {
                Id = 1,
                Name = "Frontend",
                Floor = 1
            },
            new Department
            {
                Id = 2,
                Name = "QA",
                Floor = 1
            },
            new Department
            {
                Id = 3,
                Name = "Backend",
                Floor = 1
            },
            new Department
            {
                Id = 4,
                Name = "DevOps",
                Floor = 2
            },
            new Department
            {
                Id = 5,
                Name = "Mobile",
                Floor = 3
            },
            new Department
            {
                Id = 6,
                Name = "Desktop",
                Floor = 2
            }
        );
    }
}