using Hogwarts.Domain;
using Hogwarts.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hogwarts.Infrastructure;

public class HogwartsDbContext : DbContext
{
    public HogwartsDbContext(DbContextOptions<HogwartsDbContext> options) :base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Picture> Pictures { get; set; }

    // public DbSet<StudentSubject> StudentSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseNpgsql(@"
            Server=localhost;
            Port=5432;
            Database=HogwartsDB;
            User Id=hogwarts;
            Password=HelloHorse789456*;
            Pooling=false;
            MinPoolSize=1; MaxPoolSize=100;
            Timeout=15;
            SslMode=Disable")
        .LogTo(
            Console.WriteLine,
            new[] { DbLoggerCategory.Database.Command.Name },
            LogLevel.Information)
        .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
        modelBuilder.ApplyConfiguration(new HouseConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        modelBuilder.ApplyConfiguration(new PictureConfiguration());
        modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}

