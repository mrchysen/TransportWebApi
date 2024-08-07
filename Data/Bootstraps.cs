using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Core.Domains.Cars.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Data;

public static class Bootstraps
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICarDayInfoKeeper, ApplicationDbContext>((fac) =>
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().
            UseNpgsql(configuration.GetConnectionString("PostrgeSql"));

            return new ApplicationDbContext(options.Options);
        });
        
        return services;
    }
}
