using Core.Domains.Cars.Models;
using Core.Domains.Cars.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection.Metadata;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<CarDayInfo> CarDayInfos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}

/// <summary>
/// Need for migrations
/// </summary>
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // ToDo make this depends on appsettings.json

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5438;Database=ktm_db;Username=postgres;Password=12345");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
