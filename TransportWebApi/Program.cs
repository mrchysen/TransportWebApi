using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(conf =>
{
    conf.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Transport API",
        Description = "Api for KTM report application.",
    });

    conf.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, 
                            $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
