using Hogwarts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hogwarts.Infrastructure.Data.Configurations;

/// <summary>
/// Configuration for the Professor entity.
/// </summary>
public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        // Configure table name
        builder.ToTable("Professors");

        // Configure properties specific to Professor
        builder.Property(p => p.CourseId)
            .IsRequired(false); // CourseId is optional

        // Configure relationships
        builder.HasOne(p => p.Course)
            .WithMany()
            .HasForeignKey(p => p.CourseId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure picture relationship if needed
        builder.HasOne(p => p.Picture)
            .WithOne()
            .HasForeignKey<Professor>(p => p.PictureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

