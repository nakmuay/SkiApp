using SkiiApp.Services;
using SkiiApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ISkiiLengthService>(
    register => {
        var factorySelector = new SkiiLengthComputerFactorySelector(new ChildrensSkiiLengthComputerFactory(), new AdultsSkiiLengthComputerFactory());
        return new SkiiLengthService(factorySelector);
        });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
