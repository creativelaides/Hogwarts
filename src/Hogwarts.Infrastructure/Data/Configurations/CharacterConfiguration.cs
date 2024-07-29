using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Hogwarts.Domain.Entities;
using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Infrastructure.Data.Configurations;

/// <summary>
/// Configuration for the Character entity.
/// </summary>
public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        // Configure table name
        builder.ToTable("Characters");

        // Configure primary key
        builder.HasKey(c => c.Id);

        // Configure properties
        builder.Property(c => c.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.Property(c => c.Age)
            .IsRequired();

        builder.Property(c => c.DateOfBirth)
            .IsRequired();

        builder.Property(c => c.BloodStatus)
            .IsRequired();

        builder.Property(c => c.PictureId)
            .IsRequired();

        // Configure picture relationship
        builder.HasOne(c => c.Picture)
            .WithOne()
            .HasForeignKey<Character>(c => c.PictureId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure discriminador
        builder.HasDiscriminator<string>("Discriminator")
            .HasValue<Character>("Character")
            .HasValue<Student>("Student")
            .HasValue<Professor>("Professor");
    }
}