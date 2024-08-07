using Core.Domains.Cars.Models;

namespace Core.Domains.Cars.Services;

public class CarDayInfoRepository : ICarDayInfoRepository
{
    public ICarDayInfoKeeper DbContext { get; set; }

    public CarDayInfoRepository(ICarDayInfoKeeper dbContext)
    {
        DbContext = dbContext;
    }

    public CarDayInfo Get(int id)
    {
        return DbContext.Get(id);
    }
    public IEnumerable<CarDayInfo> Get(DateTime date)
    {
        return DbContext.Get(date);
    }
    public void Update(CarDayInfo carDayInfo)
    {
        DbContext.Update(carDayInfo);
    }
    public void Delete(int id)
    {
        DbContext.Delete(id); 
    }

    public void Create(CarDayInfo carDayInfo)
    {
        DbContext.Create(carDayInfo);
    }
}
