using Web;
using Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWeb()
    .AddCore();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();