using Microsoft.EntityFrameworkCore;
using SkillIn.Entities;

namespace SkillIn.Api
{
    public static class EmployersApi
    {
        public static RouteGroupBuilder MapEmployersApi(this RouteGroupBuilder api)
        {
            api.MapGet("/", async (SkillInContext db) =>
            {
                var employers = await db.Employers.Include(e => e.Vacancies).ToListAsync();
                return Results.Ok(employers);
            });

            api.MapGet("/{id}", async (Guid id, SkillInContext db) =>
            {
                var employer = await db.Employers
                    .Include(e => e.Vacancies)
                    .FirstOrDefaultAsync(e => e.Id == id);
                return employer is not null ? Results.Ok(employer) : Results.NotFound();
            });

            api.MapPost("/", async (Employer employer, SkillInContext db) =>
            {
                db.Employers.Add(employer);
                await db.SaveChangesAsync();
                return Results.Created($"/employers/{employer.Id}", employer);
            });

            api.MapPut("/{id}", async (Guid id, Employer updatedEmployer, SkillInContext db) =>
            {
                var employer = await db.Employers.FindAsync(id);
                if (employer is null) return Results.NotFound();

                employer.CompanyName = updatedEmployer.CompanyName;
                employer.CompanyInfo = updatedEmployer.CompanyInfo;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            api.MapDelete("/{id}", async (Guid id, SkillInContext db) =>
            {
                var employer = await db.Employers.FindAsync(id);
                if (employer is null) return Results.NotFound();

                db.Employers.Remove(employer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            return api;
        }
    }
}
