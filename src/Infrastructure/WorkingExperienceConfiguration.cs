using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public sealed class WorkingExperienceConfiguration : IEntityTypeConfiguration<WorkingExperience>
{
    public void Configure(EntityTypeBuilder<WorkingExperience> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.StartDate).IsRequired();
        builder.Property(w => w.EndDate);
        builder.HasOne(w => w.ProgrammingLanguage)
            .WithMany(l => l.WorkingExperiences)
            .HasForeignKey(w => w.ProgrammingLanguageId)
            .IsRequired();
    }
}