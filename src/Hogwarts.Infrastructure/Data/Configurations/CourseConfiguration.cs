using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hogwarts.Domain.Entities;

namespace Hogwarts.Infrastructure.Data.Configurations;
/// <summary>
/// Configuration for the Course entity.
/// </summary>
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        // Configure table name
        builder.ToTable("Courses");

        // Configure primary key
        builder.HasKey(c => c.Id);

        // Configure properties
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        // Configure relationships
        builder.HasOne(c => c.Professor)
            .WithOne(p => p.Course)
            .HasForeignKey<Course>(c => c.ProfessorId);

        builder.HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity<StudentCourse>(
                j => j
                    .HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentCourses)
                    .HasForeignKey(sc => sc.StudentId),
                j => j
                    .HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentCourses)
                    .HasForeignKey(sc => sc.CourseId),
                j =>
                {
                    j
                    .HasKey(t => new { t.StudentId, t.CourseId });
                }
                );
    }
}

