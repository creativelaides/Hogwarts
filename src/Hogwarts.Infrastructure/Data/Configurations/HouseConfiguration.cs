using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Hogwarts.Domain.Entities;

namespace Hogwarts.Infrastructure.Data.Configurations;
/// <summary>
/// Configuration for the House entity.
/// </summary>
public class HouseConfiguration : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.ToTable("Houses");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(h => h.Founder)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(h => h.Animal)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(h => h.Element)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(h => h.Students)
            .WithOne(s => s.House)
            .HasForeignKey(s => s.HouseId);
    }
}