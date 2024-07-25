using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Hogwarts.Domain.Entities;

namespace Hogwarts.Infrastructure.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(s => s.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        builder.Property(s => s.Age)
            .IsRequired();

        builder.Property(s => s.DateOfBirth)
            .IsRequired();

        builder.Property(s => s.BloodStatus)
            .IsRequired();

        builder.HasOne(s => s.House)
            .WithMany(h => h.Students)
            .HasForeignKey(s => s.HouseId);

        builder.HasMany(s => s.StudentSubjects)
            .WithOne(ss => ss.Student)
            .HasForeignKey(ss => ss.StudentId);
    }
}
