using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName).IsRequired();
        builder.Property(e => e.LastName).IsRequired();
        builder.Property(e => e.Age).IsRequired();
        builder.Property(e => e.Gender).IsRequired();
        builder.Property(e => e.DepartmentId).IsRequired();
        builder.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired();
    }
}