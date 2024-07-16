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

        builder.HasData(
            new ProgrammingLanguage
            {
                Id = 1,
                Name = "C#"
            },
            new ProgrammingLanguage
            {
                Id = 2,
                Name = "Java"
            },
            new ProgrammingLanguage
            {
                Id = 3,
                Name = "Python"
            },
            new ProgrammingLanguage
            {
                Id = 4,
                Name = "JavaScript"
            },
            new ProgrammingLanguage
            {
                Id = 5,
                Name = "Swift"
            },
            new ProgrammingLanguage
            {
                Id = 6,
                Name = "Kotlin"
            }
        );
    }
}