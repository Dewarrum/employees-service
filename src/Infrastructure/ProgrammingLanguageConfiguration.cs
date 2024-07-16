using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public sealed class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Name).IsRequired();
    }
}