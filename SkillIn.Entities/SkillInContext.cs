using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace SkillIn.Entities
{
    public class SkillInContext: DbContext
    {
        #region Config

        public SkillInContext(DbContextOptions<SkillInContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ent");

            base.OnModelCreating(modelBuilder);

            // применить конфигурацию составного ключа для StudentHardSkill
            modelBuilder.ApplyConfiguration(new StudentHardSkill.StudentHardSkillConfiguration());

            // применить конфигурацию составного ключа для StudentSoftSkill
            modelBuilder.ApplyConfiguration(new StudentSoftSkill.StudentSoftSkillConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                          .EnableSensitiveDataLogging();
        }
        
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Conventions.Remove(typeof(
                Microsoft.EntityFrameworkCore.Metadata.Conventions.CascadeDeleteConvention));

            base.ConfigureConventions(builder);
        }

        #endregion Config

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<HardSkill> HardSkills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Olympiad> Olympiads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SoftSkill> SoftSkills { get; set; }
        public DbSet<Speciality> Specializations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentHardSkill> StudentHardSkills { get; set; }
        public DbSet<StudentSoftSkill> StudentSoftSkills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
    }
}