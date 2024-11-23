using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using SkillIn.Entities;
using SkillIn.API;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Подключение к БД
services.AddDbContext<SkillInContext>(opt =>
    opt.UseNpgsql(configuration.GetConnectionString("SkillInDb"))); // <-- DefaultConnection

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

services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5173",
            "http://localhost:5174",
            "http://localhost:5175")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});


var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();


// Проверка подключения к БД
try
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<SkillInContext>();
        db.Database.EnsureCreated();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Database connection error: {ex.Message}");
}

app.MapGet("/", () => "SkillIn Service");  // <-- Входящий GET запрос по корневому адресному пути возвращает SkillIn Service


app.MapGroup("/users").MapUsersApi().RequireAuthorization();
//app.MapGroup("/roles").MapRolesApi().RequireAuthorization(a => a.RequireRole("Admin"));

// Маршрут для логина с проверкой пароля в отдельной таблице
app.MapPost("/login/{login}", async (string login, [FromBody] string password, SkillInContext db) =>
{
    // 1. Находим пользователя по Login
    var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);
    if (user is null) return Results.Unauthorized();

    // 2. Находим запись пароля по UserId
    var passwordEntry = await db.UserPasswords.FirstOrDefaultAsync(p => p.UserId == user.Id);
    if (passwordEntry is null) return Results.Unauthorized();

    // 3. Хешируем введённый пароль и сравниваем с сохранённым хешем
    byte[] hash = SHA512.HashData(Encoding.UTF8.GetBytes(password));
    string hexPassword = BitConverter.ToString(hash).Replace("-", "");

    if (hexPassword != passwordEntry.PasswordHash)
        return Results.Unauthorized();

    // 4. Что входит в токен
    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, login),
        new("id", user.Id.ToString()),
        new(ClaimTypes.Role, user.Role.ToString()) // <-- не нужна проверка if !=, так как Required
    };

    // 5. Создание JWT-токена
    var jwt = new JwtSecurityToken(
        claims: claims,
        issuer: configuration["Jwt:Issuer"],
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(5)), // Время "жизни" токена
        signingCredentials:
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                SecurityAlgorithms.HmacSha256));

    return Results.Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
});


app.Run();