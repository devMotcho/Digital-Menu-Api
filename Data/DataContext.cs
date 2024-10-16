using System.Reflection;
using DigitalMenuApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenuApi.Data;

public class DataContext : 
    DbContext, IDataContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<DishOfTheDay> DishesOfTheDay {get; set;}
    private readonly IConfiguration _config;

    public DataContext(
        DbContextOptions<DataContext> options,
        IConfiguration config
    ) : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
    )
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Change to UseSqlServer for sql server
            optionsBuilder.UseNpgsql(
                _config.GetConnectionString("DefaultConnection"),
                optionsBuilder => optionsBuilder
                    .EnableRetryOnFailure()
            );
        }
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder
    )
    {
        modelBuilder.HasDefaultSchema("dishes");

        // Implements Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly()
        );
        base.OnModelCreating(modelBuilder);
    }
}