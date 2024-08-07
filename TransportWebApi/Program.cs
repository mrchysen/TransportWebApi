using Web;
using Core;
using Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWeb()
    .AddCore()
    .AddData(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();