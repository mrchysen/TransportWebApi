using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;

namespace Web;

public static class Bootstraps
{
    public static IServiceCollection AddWeb(this IServiceCollection services)
    {
        services.AddControllers();

        return services.AddSwaggerGen(conf =>
        {
            conf.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Transport API",
                Description = "Api for KTM report application.",
            });

            conf.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"Web.xml"));
        });
    }
}
