using Hogwarts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hogwarts.Infrastructure.Data.Configurations;

/// <summary>
/// Configuration for the Student entity.
/// </summary>
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // Configure table name
        builder.ToTable("Students");

        // Configure properties specific to Student
        builder.Property(s => s.HouseId)
            .IsRequired(false);

        // Configure relationships
        builder.HasOne(s => s.House)
            .WithMany(h => h.Students)
            .HasForeignKey(s => s.HouseId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(s => s.Subjects)
            .WithMany(sub => sub.Students)
            .UsingEntity<StudentSubject>(
                j => j
                    .HasOne(ss => ss.Subject)
                    .WithMany(s => s.StudentSubjects)
                    .HasForeignKey(ss => ss.SubjectId),
                j => j
                    .HasOne(ss => ss.Student)
                    .WithMany(s => s.StudentSubjects)
                    .HasForeignKey(ss => ss.StudentId),
                j =>
                {
                    j.HasKey(t => new { t.StudentId, t.SubjectId });
                });

        // Configure picture relationship if needed
        builder.HasOne(s => s.Picture)
            .WithOne()
            .HasForeignKey<Student>(s => s.PictureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

