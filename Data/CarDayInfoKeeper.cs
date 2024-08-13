using Core;
using Core.Domains.Cars.Models;
using Core.Domains.Cars.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data;

public class CarDayInfoKeeper : ICarDayInfoKeeper
{
    private readonly ApplicationDbContext Context;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<CarDayInfoKeeper> Logger;
    private DbSet<CarDayInfo> CarDayInfos => Context.CarDayInfos;

    public CarDayInfoKeeper(ApplicationDbContext context, IUnitOfWork unitOfWork, ILogger<CarDayInfoKeeper> logger)
    {
        Context = context;
        UnitOfWork = unitOfWork;
        Logger = logger;
    }

    public async Task<CarDayInfo?> Get(Guid id)
        => await CarDayInfos.Include(el => el.Cars).Where(el => el.Id == id).AsNoTracking().FirstOrDefaultAsync();

    public async Task<IEnumerable<CarDayInfo>> Get(DateOnly date)
    {
        var collection = CarDayInfos.Include(el => el.Cars).Where(el => el.Date.Equals(date)).AsNoTracking();

        return await collection.ToListAsync();
    }
    public async Task<Dictionary<DateOnly, int>> GetGroupDateTimeCount()
    {
        var dic = await CarDayInfos.Include(el => el.Cars).GroupBy(el => el.Date)
            .Select(el => new { el.Key, Count = el.Count() })
            .ToDictionaryAsync(el => el.Key, el => el.Count);

        return dic;
    }

    public async Task<bool> Update(CarDayInfo carDayInfo)
    {
        try
        {
            await CarDayInfos.AddAsync(carDayInfo);

            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error from CarDayInfoKeeper.Update; ex.Message:{ex.Message}");

            return false;
        }

        return true;
    }
    public async Task<string> Delete(Guid id)
    {
        var entity = await CarDayInfos.Where(el => el.Id == id).Include(el => el.Cars).FirstOrDefaultAsync();

        if (entity == null)
            return "No such object";

        var cars = entity.Cars;
        
        try
        {
            CarDayInfos.Remove(entity);
            Context.RemoveRange(cars);

            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error from CarDayInfoKeeper.Delete; ex.Message:{ex.Message}");

            return "Removing error";
        }

        return "Removing completed";
    }
    public async Task<bool> Create(CarDayInfo carDayInfo)
    {
        try
        {
            await CarDayInfos.AddAsync(carDayInfo);

            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error from CarDayInfoKeeper.Create; ex.Message:{ex.Message}");

            return false;
        }

        return true;
    }
}
