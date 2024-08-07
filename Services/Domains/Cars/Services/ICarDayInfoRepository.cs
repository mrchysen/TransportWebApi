using Core.Domains.Cars.Models;

namespace Core.Domains.Cars.Services;

public interface ICarDayInfoRepository
{
    CarDayInfo Get(int id);
    IEnumerable<CarDayInfo> Get(DateTime date);
    void Update(CarDayInfo carDayInfo);
    void Delete(int id);
    void Create(CarDayInfo carDayInfo);
}
