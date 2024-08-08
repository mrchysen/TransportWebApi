using Core.Domains.Cars.Models;

namespace Core.Domains.Cars.Services;

public interface ICarDayInfoRepository
{
    CarDayInfo Get(Guid id);
    IEnumerable<CarDayInfo> Get(DateTime date);
    void Update(CarDayInfo carDayInfo);
    void Delete(Guid id);
    void Create(CarDayInfo carDayInfo);
}
