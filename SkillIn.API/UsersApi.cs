using Microsoft.EntityFrameworkCore;
using SkillIn.Entities;

namespace SkillIn.Api
{
    public static class UsersApi
    {
        public static RouteGroupBuilder MapUsersApi(this RouteGroupBuilder api)
        {
            api.MapGet("/", async (SkillInContext db) =>
            {
                var users = await db.Users
                    .Select(u => new DtoData(u))
                    .ToListAsync();
                return Results.Ok(users);
            });

            api.MapGet("/{login}", async (string login, SkillInContext db) =>
            {
                var user = await db.Users
                    .FirstOrDefaultAsync(u => u.Login == login);

                return user is null ? Results.NotFound() : Results.Ok(new DtoData(user));
            });

            api.MapPost("/", async (DtoData userDto, SkillInContext db) =>
            {
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

            api.MapPut("/{login}", async (string login, DtoData userDto, SkillInContext db) =>
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);

                if (user is null) return Results.BadRequest($"User '{login}' not found");

                user.Email = userDto.Email;
                user.Role = userDto.Role;
                await db.SaveChangesAsync();

                return Results.Ok();
            });

            api.MapDelete("/{login}", async (string login, SkillInContext db) =>
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);

                if (user is null) return Results.BadRequest($"User '{login}' not found");

                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            api.MapGet("/current", (HttpContext context) =>
            {
                var username = context.User.Identity?.Name;
                var userId = context.User.FindFirst("id")?.Value;

                return username is null || userId is null
                    ? Results.Unauthorized()
                    : Results.Ok(new { Login = username, Id = Guid.Parse(userId) });
            });

            return api;
        }
    }
}
