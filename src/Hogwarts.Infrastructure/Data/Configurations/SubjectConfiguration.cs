using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hogwarts.Domain.Entities;
using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Infrastructure.Data.Configurations;
/// <summary>
/// Configuration for the Subject entity.
/// </summary>
public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        // Configure table name
        builder.ToTable("Subject");

        // Configure primary key
        builder.HasKey(s => s.Id);

        // Configure properties
        builder.Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        // Configure relationships
        builder.HasOne(s => s.Professor)
            .WithOne(p => p.Subject)
            .HasForeignKey<Subject>(s => s.ProfessorId);

        builder.HasMany(s => s.Students)
            .WithMany(st => st.Subjects)
            .UsingEntity<StudentSubject>(
                j => j
                    .HasOne(ss => ss.Student)
                    .WithMany(s => s.StudentSubjects)
                    .HasForeignKey(ss => ss.StudentId),
                j => j
                    .HasOne(ss => ss.Subject)
                    .WithMany(s => s.StudentSubjects)
                    .HasForeignKey(ss => ss.SubjectId),
                j =>
                {
                    j.HasKey(t => new { t.StudentId, t.SubjectId });
                });
    }
}

