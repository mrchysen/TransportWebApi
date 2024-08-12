using Web;
using Core;
using Data;
using Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWeb()
    .AddCore()
    .AddData(builder.Configuration);

var app = builder.Build();

app.ExecuteMigration();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();