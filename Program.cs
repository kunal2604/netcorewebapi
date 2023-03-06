global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Data.SqlClient;
global using Microsoft.EntityFrameworkCore;
global using netcorewebapi.Data;
global using netcorewebapi.Data.DAO;
global using netcorewebapi.Data.DAO.Interface;
global using netcorewebapi.Dtos.Character;
global using netcorewebapi.Models;
global using netcorewebapi.Services.CharacterService;
global using Newtonsoft.Json.Linq;
global using System.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers().AddNewtonsoftJson();
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
    builder.Services.AddScoped<ICharacterDAO, CharacterDAO>();
}