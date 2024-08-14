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
    public async Task<IEnumerable<CarDayInfo>> Get(DateOnly date)
    {
        var collection = await DbContext.Get(date);

        return collection ?? Enumerable.Empty<CarDayInfo>();
    }
    public async Task<Dictionary<DateOnly, int>> GetGroupDateTimeCount()
    {
        var dic = await DbContext.GetGroupDateTimeCount();

        return dic;
    }
    public async Task<bool> Update(CarDayInfo carDayInfo)
    {
        return await DbContext.Update(carDayInfo);
    }
    public async Task<string> Delete(Guid id)
    {
        return await DbContext.Delete(id); 
    }

    public async Task<CarDayInfo> Create(CarDayInfo carDayInfo)
    {
        carDayInfo.Id = Guid.NewGuid();

        carDayInfo.Description = string.IsNullOrEmpty(carDayInfo.Description) ? 
            "No discription" : 
            carDayInfo.Description;

        carDayInfo.Cars.ForEach(car => car.Id = Guid.NewGuid());

        await DbContext.Create(carDayInfo);

        return carDayInfo;
    }
}
