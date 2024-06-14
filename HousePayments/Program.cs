using HousePayments.Interfaces;
using HousePayments.Models;
using HousePayments.Repository;
using HousePayments.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//services

builder.Services.AddScoped<IServicesResidentes, ServicesResidente>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddDataProtection();

//repositories

builder.Services.AddScoped<IRepositoryResidente<Residente>, RepositoryResidente>();

//ENTITY FRAMEWORK 
builder.Services.AddDbContext<HousePaymentsContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("mysqlConnection"));
});
//auth with jwt


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
