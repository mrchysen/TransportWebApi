using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Core.Domains.Cars.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Core;

namespace Data;

public static class Bootstraps
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((opt) =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("PostrgeSql"));
        });
        
        services.AddTransient<ICarDayInfoKeeper,  CarDayInfoKeeper>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
