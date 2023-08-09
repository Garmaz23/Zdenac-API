global using Zdenac_API.Models;
global using Zdenac_API.Data;
global using Microsoft.EntityFrameworkCore;
global using Zdenac_API.Services;
using Zdenac_API;
using Microsoft.Exchange.WebServices.Data;
using Zdenac_API.Repositories.Interfaces;
using Zdenac_API.Repositories;
using Zdenac_API.Services.Interfaces;
using Serilog;
using Log = Serilog.Log;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


IServiceCollection serviceCollection = builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IChildRepository, ChildRepository>();
builder.Services.AddScoped<IChildService, ChildService>();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
