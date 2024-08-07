using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;

namespace Data;

public static class Bootstraps
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<ApplicationDbContext>(configuration.GetConnectionString("PostrgeSql"));
        
        return services;
    }
}
