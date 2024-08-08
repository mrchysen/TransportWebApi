using Core.Domains.Cars.Models;

namespace Core.Domains.Cars.Services;

public interface ICarDayInfoKeeper
{
    Task<CarDayInfo?> Get(Guid id);
    Task<IEnumerable<CarDayInfo>> Get(DateTime date);
    Task<bool> Update(CarDayInfo carDayInfo);
    Task<string> Delete(Guid id);
    Task<bool> Create(CarDayInfo carDayInfo);
}
