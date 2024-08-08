using Core.Domains.Cars.Models;
using Core.Domains.Cars.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data;

public class ApplicationDbContext : DbContext, ICarDayInfoKeeper
{
    protected DbSet<CarDayInfo> CarDayInfos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public async Task<CarDayInfo?> Get(Guid id)
        => await CarDayInfos.Where(el => el.Id == id).AsNoTracking().FirstOrDefaultAsync();
    
    public async Task<IEnumerable<CarDayInfo>> Get(DateTime date)
    {
        var collection = CarDayInfos.Where(el => el.Date.Equals(date)).AsNoTracking();

        return await collection.ToListAsync();
    }
    public async Task<Dictionary<DateTime, int>> GetGroupDateTimeCount()
    {
        var dic = await CarDayInfos.GroupBy(el => el.Date)
            .Select(el => new { el.Key, Count = el.Count() })
            .ToDictionaryAsync(el => el.Key, el => el.Count);

        return dic;
    }

    public async Task<bool> Update(CarDayInfo carDayInfo)
    {
        try
        {
            await CarDayInfos.AddAsync(carDayInfo);

            await SaveChangesAsync();
        }
        catch(Exception ex)
        {
            // ToDo make log ex.Message here

            return false;
        }

        return true;
    }
    public async Task<string> Delete(Guid id)
    {
        var entity = await CarDayInfos.Where(el => el.Id == id).FirstOrDefaultAsync();

        if (entity == null)
            return "No such object";

        try
        {
            CarDayInfos.Remove(entity);

            await SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // ToDo make log ex.Message here

            return "Removing error";
        }

        return "Removing completed";
    }
    public async Task<bool> Create(CarDayInfo carDayInfo)
    {
        try
        {
            await CarDayInfos.AddAsync(carDayInfo);

            await SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // ToDo make log ex.Message here

            return false;
        }

        return true;
    }
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
        optionsBuilder.UseNpgsql("Host=localhost;Port=5438;Database=KTMdb;Username=postgres;Password=12345");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
