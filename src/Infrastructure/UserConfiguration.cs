using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.LastActiveAt).IsRequired();
        builder.HasIndex(u => u.Name).IsUnique();
    }
}