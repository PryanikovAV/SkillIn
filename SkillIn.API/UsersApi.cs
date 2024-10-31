using Microsoft.EntityFrameworkCore;
using SkillIn.Entities;

namespace SkillIn.API
{
    /// <summary>
    /// API /users
    /// </summary>
    public static class UsersApi
    {
        public static RouteGroupBuilder MapUsersApi(this RouteGroupBuilder api)
        {
            // Получение всех пользователей [GET]
            api.MapGet("/", async (SkillInContext db) =>
            {
                var users = await db.Users
                    .Select(u => new UserDto(u))
                    .ToListAsync();

                return Results.Ok(users);
            });

            // Получение пользователя по логину [GET]
            api.MapGet("/{login}", async (string login, SkillInContext db) =>
            {
                var user = await db.Users
                    .FirstOrDefaultAsync(u => u.Login == login);

                if (user is null)
                    return Results.NotFound();

                return Results.Ok(new UserDto(user));
            });

            // Добавление нового пользователя [POST]
            api.MapPost("/", async (UserDto userDto, SkillInContext db) =>
            {
                ArgumentNullException.ThrowIfNull(userDto?.Login);

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Login = userDto.Login,
                    Email = userDto.Email,
                    Role = userDto.Role
                };

                db.Users.Add(user);
                await db.SaveChangesAsync();

                return Results.Ok();
            });

            // Обновление данных пользователя по логину [PUT]
            api.MapPut("/{login}", async (string login, UserDto userDto, SkillInContext db) =>
            {
                ArgumentNullException.ThrowIfNull(userDto);

                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);

                if (user is null)
                    return Results.BadRequest($"User '{login}' not found");

                user.Email = userDto.Email;
                user.Role = userDto.Role;

                await db.SaveChangesAsync();

                return Results.Ok();
            });

            // Удаление пользователя по логину [DELETE]
            api.MapDelete("/{login}", async (string login, SkillInContext db) =>
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);

                if (user is null)
                    return Results.BadRequest($"User '{login}' not found");

                db.Users.Remove(user);
                await db.SaveChangesAsync();

                return Results.Ok();
            });

            // Получение информации о текущем пользователе по токену [GET]
            api.MapGet("/current", (HttpContext context) =>
            {
                var username = context.User.Identity?.Name;
                var userId = context.User.FindFirst("id")?.Value;

                if (username is null || userId is null)
                    return Results.Unauthorized();

                return Results.Ok(new { Login = username, Id = Guid.Parse(userId) });
            });

            return api;
        }
    }
}
