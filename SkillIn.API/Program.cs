using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkillIn.Entities;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Подключение к базе данных
services.AddDbContext<SkillInContext>(opt =>
    opt.UseNpgsql(configuration.GetConnectionString("SkillInDb"))); //   DefaultConnection

// Настройка аутентификации с JWT
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),

            ValidateAudience = false
        };
    });

services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "SkillIn Service");

// ДОБАВИТЬ МАРШУТЫ КОНТРОЛЛЕРОВ
//app.MapGroup("/students").MapStudentsApi().RequireAuthorization();
//app.MapGroup("/skills").MapSkillsApi().RequireAuthorization();

app.Run();
