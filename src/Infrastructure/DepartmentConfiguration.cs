using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name).IsRequired();
        builder.Property(d => d.Floor).IsRequired();
        builder.HasMany(d => d.Employees).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentId).IsRequired();
    }
}