// Command to migrate: dotnet ef migrations add InitialCreate
// Command to update DB: dotnet ef database update

global using netcorewebapi.Models;
global using netcorewebapi.Services.CharacterService;
global using netcorewebapi.Dtos.Character;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using netcorewebapi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices()
{
    RegisterInterfaces();
}

void RegisterInterfaces()
{
    builder.Services.AddScoped<ICharacterService, CharacterService>();
}