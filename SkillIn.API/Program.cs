using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using SkillIn.Entities;
using SkillIn.Api;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// ����������� � ��
services.AddDbContext<SkillInContext>(opt =>
    opt.UseNpgsql(configuration.GetConnectionString("SkillInDb")));

// ��������� �������������� � JWT
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
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

// �������� ����������� � ��
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SkillInContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/", () => "SkillIn Service");

// ����������� API ��� �������������
app.MapGroup("/users").MapUsersApi().RequireAuthorization();

// ����������� (�����)
app.MapPost("/login/{login}", async (string login, [FromBody] string password, SkillInContext db) =>
{
    var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);
    if (user is null) return Results.Unauthorized();

    var passwordEntry = await db.UserPasswords.FirstOrDefaultAsync(p => p.UserId == user.Id);
    if (passwordEntry is null) return Results.Unauthorized();

    var hash = SHA512.HashData(Encoding.UTF8.GetBytes(password));
    var hexPassword = BitConverter.ToString(hash).Replace("-", "");

    if (hexPassword != passwordEntry.PasswordHash) return Results.Unauthorized();

    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, login),
        new("id", user.Id.ToString()),
        new(ClaimTypes.Role, user.Role.ToString())
    };

    var jwt = new JwtSecurityToken(
        claims: claims,
        issuer: configuration["Jwt:Issuer"],
        expires: DateTime.UtcNow.AddMinutes(5),
        signingCredentials: new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
            SecurityAlgorithms.HmacSha256));

    return Results.Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
});

// �����������
app.MapPost("/register", async (RegisterDto registerDto, SkillInContext db) =>
{
    Console.WriteLine($"Register attempt: {registerDto.Login}, {registerDto.Email}"); // �������

    if (await db.Users.AnyAsync(u => u.Login == registerDto.Login || u.Email == registerDto.Email))
    {
        return Results.BadRequest("����� ��� email ��� ������������.");
    }

    var user = new User
    {
        Id = Guid.NewGuid(),
        Login = registerDto.Login,
        Email = registerDto.Email,
        Role = UserRole.Student
    };

    var hash = SHA512.HashData(Encoding.UTF8.GetBytes(registerDto.Password));
    var hexPassword = BitConverter.ToString(hash).Replace("-", "");

    var passwordEntry = new UserPassword
    {
        Id = Guid.NewGuid(),
        UserId = user.Id,
        PasswordHash = hexPassword
    };

    db.Users.Add(user);
    db.UserPasswords.Add(passwordEntry);
    await db.SaveChangesAsync();

    return Results.Ok("������������ ������� ���������������.");
});

app.Run();
