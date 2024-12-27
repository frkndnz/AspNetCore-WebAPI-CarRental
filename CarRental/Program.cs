using CarRental.Data.Abstract;
using CarRental.Data.Concrete;
using CarRental.Data.Repository;
using CarRental.Models;
using CarRental.Services.Abstract;
using CarRental.Services.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof( GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>),typeof( GenericService<>));
builder.Services.AddScoped(typeof(ICarService),typeof(CarService));
builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
