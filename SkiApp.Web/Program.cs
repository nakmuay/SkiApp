using SkiApp.Services;
using SkiApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ISkiLengthService>(
    register => {
        var factorySelector = new SkiLengthComputerFactorySelector(new ChildrensSkiLengthComputerFactory(), new AdultsSkiLengthComputerFactory());
        return new SkiLengthService(factorySelector);
        });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
