using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Hogwarts.Domain.Entities;
using Hogwarts.Infrastructure.Data.Configurations;
using Hogwarts.Infrastructure.Data.Seed;

namespace Hogwarts.Infrastructure;

public class HogwartsDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Picture> Pictures { get; set; }

    public HogwartsDbContext(DbContextOptions<HogwartsDbContext> options) : base(options)
    {
    }

    // Constructor sin parámetros para las herramientas de migración
    public HogwartsDbContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=HogwartsDB; User Id=hogwarts; Password=HelloHorse789456*; Pooling=false; MinPoolSize=1; MaxPoolSize=100; Timeout=15; SslMode=Disable")
                          .LogTo(
                              Console.WriteLine,
                              new[] { DbLoggerCategory.Database.Command.Name },
                              LogLevel.Information)
                          .EnableSensitiveDataLogging();
        }
    }

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

        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new HouseConfiguration());
        modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        modelBuilder.ApplyConfiguration(new PictureConfiguration());

        var seed = new InitialSeed();
        seed.InitialSeedData();

        modelBuilder.Entity<House>().HasData([.. seed.Houses]);
        modelBuilder.Entity<Subject>().HasData([.. seed.Subjects]);
        modelBuilder.Entity<Picture>().HasData([.. seed.Pictures]);
        modelBuilder.Entity<Student>().HasData([.. seed.Students]);
        modelBuilder.Entity<Professor>().HasData([.. seed.Professors]);
    }
}

