using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Infrastructure;

public class HogwartsDbContext : DbContext
{
    public HogwartsDbContext(DbContextOptions<HogwartsDbContext> options) : base(options)
    {
    }
}
