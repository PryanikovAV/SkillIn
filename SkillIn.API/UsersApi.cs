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
                var users = await db.Users.ToListAsync();
                return Results.Ok(users);
            });

            api.MapGet("/{login}", async (string login, SkillInContext db) =>
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);
                return user is not null ? Results.Ok(user) : Results.NotFound();
            });

            api.MapPost("/", async (User user, SkillInContext db) =>
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return Results.Created($"/users/{user.Id}", user);
            });

            api.MapPut("/{login}", async (string login, User updatedUser, SkillInContext db) =>
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);
                if (user is null) return Results.NotFound();

                user.Email = updatedUser.Email;
                user.Role = updatedUser.Role;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            api.MapDelete("/{login}", async (string login, SkillInContext db) =>
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);
                if (user is null) return Results.NotFound();

                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            return api;
        }
    }
}
