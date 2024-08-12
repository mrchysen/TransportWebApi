using Core;
using Core.Domains.Cars.Models;
using Core.Domains.Cars.Services;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class CarDayInfoKeeper : ICarDayInfoKeeper
{
    private readonly ApplicationDbContext Context;
    private readonly IUnitOfWork UnitOfWork;
    private DbSet<CarDayInfo> CarDayInfos => Context.CarDayInfos;

    public CarDayInfoKeeper(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        Context = context;
        UnitOfWork = unitOfWork;
    }

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

            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
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

            await UnitOfWork.SaveAsync();
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

            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            // ToDo make log ex.Message here

            return false;
        }

        return true;
    }
}
