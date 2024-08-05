using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Hogwarts.Domain.Entities;
using Hogwarts.Infrastructure.Data.Configurations;
using Hogwarts.Infrastructure.Data.Seed;
using Hogwarts.Infrastructure.Identities.Models;
using Hogwarts.Infrastructure.Identities.Security;

namespace Hogwarts.Infrastructure;

public class HogwartsDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Picture> Pictures { get; set; }

    public HogwartsDbContext(DbContextOptions<HogwartsDbContext> options) : base(options)
    {
    }

    // Constructor without parameters for migrations tools
    public HogwartsDbContext() : base(){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configura el tipo de datos para los campos DateTime
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetColumnType("timestamptz");
                }
            }
        }

        // Configura las entidades en la base de datos
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new HouseConfiguration());
        modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new PictureConfiguration());

        // Agrega los datos de la semilla
        var seed = new InitialSeed();
        seed.InitialSeedData();

        modelBuilder.Entity<House>().HasData([.. seed.Houses]);
        modelBuilder.Entity<Course>().HasData([.. seed.Courses]);
        modelBuilder.Entity<Picture>().HasData([.. seed.Pictures]);
        modelBuilder.Entity<Student>().HasData([.. seed.Students]);
        modelBuilder.Entity<Professor>().HasData([.. seed.Professors]);

        // Perfiles de identities
        SecurityProfiles.UploadSecurityProfiles(modelBuilder);
    }

}
