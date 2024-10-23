/* ---------------------------------------------------
 * Миграции БД skillin-db, схема ent, контекст SkillInContext
 * ---------------------------------------------------
 * Package Manager Console:
 *
 * Создать новую миграцию по измененному контексту:
 *   PM> EntityFrameworkCore\Add-Migration "НазваниеМиграции" -OutputDir History -Project SkillIn.Migrations -StartupProject SkillIn.Migrations
 *
 * Сгенерировать sql-скрипт для БД:
 *   PM> EntityFrameworkCore\Script-Migration -From "НазваниеПредМиграции" -Project SkillIn.Migrations -StartupProject SkillIn.Migrations
 *
 * Применить изменения в БД:
 *   PM> EntityFrameworkCore\Update-Database -Project SkillIn.Migrations -StartupProject SkillIn.Migrations
 */


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SkillIn.Entities;

namespace SkillIn.Migrations
{
    internal class SkillInContextFactory : IDesignTimeDbContextFactory<SkillInContext>
    {
        static SkillInContextFactory()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public SkillInContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SkillInContext>();

            const string connectionString =
                "Host=localhost;Port=5433;Database=skillin-db;Persist Security Info=True;User ID=postgres;Password=postgres";

            optionsBuilder
                .UseNpgsql(
                    connectionString,
                    options => options
                        .CommandTimeout(1000)
                        .MigrationsAssembly("SkillIn.Migrations")
                        .MigrationsHistoryTable("EntMigrations", "public"));

            return new SkillInContext(optionsBuilder.Options);
        }
    }
}
