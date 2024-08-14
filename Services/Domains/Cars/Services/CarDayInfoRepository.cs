using Core.Domains.Cars.Models;

namespace Core.Domains.Cars.Services;

public class CarDayInfoRepository : ICarDayInfoRepository
{
    public ICarDayInfoKeeper CarDayInfoKeeper { get; set; }

    public CarDayInfoRepository(ICarDayInfoKeeper carDayInfoKeeper)
    {
        CarDayInfoKeeper = carDayInfoKeeper;
    }

    public async Task<CarDayInfo?> Get(Guid id)
    {
        return await CarDayInfoKeeper.Get(id);
    }
    public async Task<IEnumerable<CarDayInfo>> Get(DateOnly date)
    {
        var collection = await CarDayInfoKeeper.Get(date);

        return collection ?? Enumerable.Empty<CarDayInfo>();
    }
    public async Task<Dictionary<DateOnly, int>> GetGroupDateTimeCount()
    {
        var dic = await CarDayInfoKeeper.GetGroupDateTimeCount();

        return dic;
    }
    public async Task<bool> Update(CarDayInfo carDayInfo)
    {
        return await CarDayInfoKeeper.Update(carDayInfo);
    }
    public async Task<string> Delete(Guid id)
    {
        return await CarDayInfoKeeper.Delete(id); 
    }

    public async Task<CarDayInfo> Create(CarDayInfo carDayInfo)
    {
        carDayInfo.Id = Guid.NewGuid();

        carDayInfo.Description = string.IsNullOrEmpty(carDayInfo.Description) ? 
            "No discription" : 
            carDayInfo.Description;

        carDayInfo.Cars.ForEach(car => car.Id = Guid.NewGuid());

        await CarDayInfoKeeper.Create(carDayInfo);

        return carDayInfo;
    }
}
