using Microsoft.EntityFrameworkCore;
using SkillIn.Entities;

namespace SkillIn.Api
{
    public static class StudentsApi
    {
        public static RouteGroupBuilder MapStudentsApi(this RouteGroupBuilder api)
        {
            api.MapGet("/", async (SkillInContext db) =>
            {
                var students = await db.Students.Include(s => s.Project).ToListAsync();
                return Results.Ok(students);
            });

            api.MapGet("/{id}", async (Guid id, SkillInContext db) =>
            {
                var student = await db.Students
                    .Include(s => s.Project)
                    .Include(s => s.StudentHardSkills)
                    .Include(s => s.StudentSoftSkills)
                    .FirstOrDefaultAsync(s => s.Id == id);
                return student is not null ? Results.Ok(student) : Results.NotFound();
            });

            api.MapPost("/", async (Student student, SkillInContext db) =>
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return Results.Created($"/students/{student.Id}", student);
            });

            api.MapPut("/{id}", async (Guid id, Student updatedStudent, SkillInContext db) =>
            {
                var student = await db.Students.FindAsync(id);
                if (student is null) return Results.NotFound();

                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.Faculty = updatedStudent.Faculty;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            api.MapDelete("/{id}", async (Guid id, SkillInContext db) =>
            {
                var student = await db.Students.FindAsync(id);
                if (student is null) return Results.NotFound();

                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            return api;
        }
    }
}
