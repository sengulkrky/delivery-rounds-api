using DeliveryRoundsApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DeliveryRoundsApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Round> Rounds { get; set; }
    public DbSet<Stop> Stops { get; set; }
    public DbSet<User> Users { get; set; } 
}