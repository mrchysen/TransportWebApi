using Core.Domains.Cars.Models;

namespace Core.Domains.Cars.Services;

public interface ICarDayInfoRepository
{
    Task<CarDayInfo?> Get(Guid id);
    Task<IEnumerable<CarDayInfo>> Get(DateTime date);
    Task<Dictionary<DateTime, int>> GetGroupDateTimeCount();
    Task Update(CarDayInfo carDayInfo);
    Task Delete(Guid id);
    Task Create(CarDayInfo carDayInfo);
}
