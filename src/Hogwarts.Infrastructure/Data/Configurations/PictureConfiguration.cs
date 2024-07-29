using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Hogwarts.Domain.Entities;
using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Infrastructure.Data.Configurations;

/// <summary>
/// Configuration for the Picture entity.
/// </summary>
public class PictureConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        // Configure table name
        builder.ToTable("Pictures");

        // Configure primary key
        builder.HasKey(p => p.Id);

        // Configure properties
        builder.Property(p => p.Url)
            .HasMaxLength(500) // Adjust length based on expected URL size
            .IsRequired();

        // Configure properties inherited from EntityBase
        builder.Property(p => p.Id)
            .ValueGeneratedNever(); // Ensure Id is not auto-generated

        // Configure relationships
        builder.HasOne(p => p.Character)
            .WithOne(c => c.Picture)
            .HasForeignKey<Character>(p => p.PictureId);
    }
}

