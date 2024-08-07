using Core.Domains.Cars.Models;
using Core.Domains.Cars.Services;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationDbContext : DbContext, ICarDayInfoKeeper
{
    protected DbSet<CarDayInfo> CarDayInfos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public CarDayInfo Get(int id)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<CarDayInfo> Get(DateTime date)
    {
        throw new NotImplementedException();
    }
    public void Update(CarDayInfo carDayInfo)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
    public void Create(CarDayInfo carDayInfo)
    {
        throw new NotImplementedException();
    }
}
