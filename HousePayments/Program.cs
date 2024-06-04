using HousePayments.Interfaces;
using HousePayments.Models;
using HousePayments.Repository;
using HousePayments.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//services

builder.Services.AddScoped<IServicesResidentes, ServicesResidente>();
builder.Services.AddDataProtection();

//repositories

builder.Services.AddScoped<IRepositoryResidente<Residente>, RepositoryResidente>();

//ENTITY FRAMEWORK 
builder.Services.AddDbContext<HousePaymentsContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("mysqlConnection"));
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
