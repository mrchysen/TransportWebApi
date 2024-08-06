using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Infrastructure.BuilderExtensions;

public static class ConfiguredSwagger
{
    public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
    {
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
