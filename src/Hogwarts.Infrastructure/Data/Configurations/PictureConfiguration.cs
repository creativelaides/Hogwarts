using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Hogwarts.Domain;

namespace Hogwarts.Infrastructure.Data.Configurations;

public class PictureConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        builder.ToTable("Pictures");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Url)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasOne(p => p.Character)
            .WithOne(c => c.Picture)
            .HasForeignKey<Picture>(p => p.CharacterId)
            .OnDelete(DeleteBehavior.Cascade); // Eliminar en cascada
    }
}