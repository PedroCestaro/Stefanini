using Microsoft.EntityFrameworkCore;
using Stefanini.Data;
using AutoMapper;
using Stefanini.Application.AutoMapper;
using Stefanini.Application.Services;
using Stefanini.Application.Interfaces;
using Stefanini.Application.Interfaces.Repositories;
using Stefanini.Application.Repositories;
using MediatR;
using Stefanini.Application.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddMediatR(typeof(CreateCityCommand).Assembly);

builder.Services.AddDbContext<StefaniniContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))) ;

builder.Services.AddScoped<StefaniniContext>();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CirtyRepository>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();