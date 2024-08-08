using Core.Domains.Cars.Models;

namespace Core.Domains.Cars.Services;

public class CarDayInfoRepository : ICarDayInfoRepository
{
    public ICarDayInfoKeeper DbContext { get; set; }

    public CarDayInfoRepository(ICarDayInfoKeeper dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<CarDayInfo?> Get(Guid id)
    {
        return await DbContext.Get(id);
    }
    public async Task<IEnumerable<CarDayInfo>> Get(DateTime date)
    {
        var collection = await DbContext.Get(date);

        return collection ?? Enumerable.Empty<CarDayInfo>();
    }
    public async Task<Dictionary<DateTime, int>> GetGroupDateTimeCount()
    {
        var dic = await DbContext.GetGroupDateTimeCount();

        return dic;
    }
    public async Task Update(CarDayInfo carDayInfo)
    {
        await DbContext.Update(carDayInfo);
    }
    public async Task Delete(Guid id)
    {
        await DbContext.Delete(id); 
    }

    public async Task Create(CarDayInfo carDayInfo)
    {
        carDayInfo.Id = Guid.NewGuid();

        carDayInfo.Description = string.IsNullOrEmpty(carDayInfo.Description) ? 
            "No discription" : 
            carDayInfo.Description;

        await DbContext.Create(carDayInfo);
    }
}
