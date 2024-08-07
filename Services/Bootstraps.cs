using Core.Domains.Cars.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class Bootstraps
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services.AddTransient<ICarDayInfoRepository, CarDayInfoRepository>();
    }
}
