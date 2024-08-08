using Core.Domains.Cars.Models;
using Core.Domains.Cars.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data;

public class ApplicationDbContext : DbContext, ICarDayInfoKeeper
{
    protected DbSet<CarDayInfo> CarDayInfos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public CarDayInfo Get(int id)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<CarDayInfo> Get(DateTime date)
    {
        throw new NotImplementedException();
    }
    public void Update(CarDayInfo carDayInfo)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
    public void Create(CarDayInfo carDayInfo)
    {
        throw new NotImplementedException();
    }
}

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5438;Database=KTMdb;Username=postgres;Password=12345");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
