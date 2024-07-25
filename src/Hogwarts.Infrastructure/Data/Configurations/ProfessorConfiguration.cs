using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Hogwarts.Domain.Entities;

namespace Hogwarts.Infrastructure.Data.Configurations;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.ToTable("Professors");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(500);

        builder.Property(p => p.Age)
            .IsRequired();

        builder.Property(p => p.DateOfBirth)
            .IsRequired();

        builder.Property(p => p.BloodStatus)
            .IsRequired();

        builder.HasOne(p => p.Subject)
            .WithOne(s => s.Professor)
            .HasForeignKey<Professor>(p => p.SubjectId);
    }
}