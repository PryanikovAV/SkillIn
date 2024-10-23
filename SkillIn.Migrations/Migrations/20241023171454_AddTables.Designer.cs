﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SkillIn.Entities;

#nullable disable

namespace SkillIn.Migrations.Migrations
{
    [DbContext(typeof(SkillInContext))]
    [Migration("20241023171454_AddTables")]
    partial class AddTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SkillIn.Entities.Chat", b =>
                {
                    b.Property<Guid>("ChatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("ChatID");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("SkillIn.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CourseLevel")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SkillIn.Entities.Discipline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uuid");

                    b.Property<int>("DisciplineName")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourseID");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("SkillIn.Entities.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("FacultyName")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("SkillIn.Entities.Favorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FavoriteUserID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteUserID");

                    b.HasIndex("UserID");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("SkillIn.Entities.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DisciplineID")
                        .HasColumnType("uuid");

                    b.Property<int>("GradeName")
                        .HasColumnType("integer");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineID");

                    b.HasIndex("StudentID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("SkillIn.Entities.HardSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("HardSkills");
                });

            modelBuilder.Entity("SkillIn.Entities.Message", b =>
                {
                    b.Property<Guid>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatID")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ReceiverID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("MessageID");

                    b.HasIndex("ChatID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SkillIn.Entities.Olympiad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OlympiadName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("OlympiadResult")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentID");

                    b.ToTable("Olympiads");
                });

            modelBuilder.Entity("SkillIn.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SkillIn.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentID")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SkillIn.Entities.SoftSkill", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.ToTable("SoftSkills");
                });

            modelBuilder.Entity("SkillIn.Entities.Speciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FacultyID")
                        .HasColumnType("uuid");

                    b.Property<int>("SpecialityName")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FacultyID");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("SkillIn.Entities.StudentHardSkill", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HardSkillId")
                        .HasColumnType("uuid");

                    b.HasKey("StudentId", "HardSkillId");

                    b.HasIndex("HardSkillId");

                    b.ToTable("StudentHardSkills");
                });

            modelBuilder.Entity("SkillIn.Entities.StudentSoftSkill", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SoftSkillId")
                        .HasColumnType("uuid");

                    b.HasKey("StudentId", "SoftSkillId");

                    b.HasIndex("SoftSkillId");

                    b.ToTable("StudentSoftSkills");
                });

            modelBuilder.Entity("SkillIn.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ChatID")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChatID");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SkillIn.Entities.UserPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserPasswords");
                });

            modelBuilder.Entity("SkillIn.Entities.Vacancy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<Guid>("EmployerID")
                        .HasColumnType("uuid");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmployerID");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("SkillIn.Entities.Employer", b =>
                {
                    b.HasBaseType("SkillIn.Entities.User");

                    b.Property<string>("CompanyInfo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasDiscriminator().HasValue("Employer");
                });

            modelBuilder.Entity("SkillIn.Entities.Student", b =>
                {
                    b.HasBaseType("SkillIn.Entities.User");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FacultyID")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("LastName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<Guid>("SpecialityID")
                        .HasColumnType("uuid");

                    b.HasIndex("CourseID");

                    b.HasIndex("FacultyID");

                    b.HasIndex("SpecialityID");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("SkillIn.Entities.Discipline", b =>
                {
                    b.HasOne("SkillIn.Entities.Course", "Course")
                        .WithMany("Disciplines")
                        .HasForeignKey("CourseID")
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SkillIn.Entities.Favorite", b =>
                {
                    b.HasOne("SkillIn.Entities.User", "FavoriteUser")
                        .WithMany()
                        .HasForeignKey("FavoriteUserID")
                        .IsRequired();

                    b.HasOne("SkillIn.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .IsRequired();

                    b.Navigation("FavoriteUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillIn.Entities.Grade", b =>
                {
                    b.HasOne("SkillIn.Entities.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineID")
                        .IsRequired();

                    b.HasOne("SkillIn.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SkillIn.Entities.Message", b =>
                {
                    b.HasOne("SkillIn.Entities.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatID")
                        .IsRequired();

                    b.HasOne("SkillIn.Entities.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverID")
                        .IsRequired();

                    b.HasOne("SkillIn.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderID")
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SkillIn.Entities.Olympiad", b =>
                {
                    b.HasOne("SkillIn.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SkillIn.Entities.Post", b =>
                {
                    b.HasOne("SkillIn.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillIn.Entities.Project", b =>
                {
                    b.HasOne("SkillIn.Entities.Student", "Student")
                        .WithOne("Project")
                        .HasForeignKey("SkillIn.Entities.Project", "StudentID")
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SkillIn.Entities.Speciality", b =>
                {
                    b.HasOne("SkillIn.Entities.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyID")
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("SkillIn.Entities.StudentHardSkill", b =>
                {
                    b.HasOne("SkillIn.Entities.HardSkill", "HardSkill")
                        .WithMany("StudentHardSkills")
                        .HasForeignKey("HardSkillId")
                        .IsRequired();

                    b.HasOne("SkillIn.Entities.Student", "Student")
                        .WithMany("StudentHardSkills")
                        .HasForeignKey("StudentId")
                        .IsRequired();

                    b.Navigation("HardSkill");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SkillIn.Entities.StudentSoftSkill", b =>
                {
                    b.HasOne("SkillIn.Entities.SoftSkill", "SoftSkill")
                        .WithMany("StudentSoftSkills")
                        .HasForeignKey("SoftSkillId")
                        .IsRequired();

                    b.HasOne("SkillIn.Entities.Student", "Student")
                        .WithMany("StudentSoftSkills")
                        .HasForeignKey("StudentId")
                        .IsRequired();

                    b.Navigation("SoftSkill");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SkillIn.Entities.User", b =>
                {
                    b.HasOne("SkillIn.Entities.Chat", null)
                        .WithMany("Participants")
                        .HasForeignKey("ChatID");
                });

            modelBuilder.Entity("SkillIn.Entities.UserPassword", b =>
                {
                    b.HasOne("SkillIn.Entities.User", "User")
                        .WithOne("Password")
                        .HasForeignKey("SkillIn.Entities.UserPassword", "UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillIn.Entities.Vacancy", b =>
                {
                    b.HasOne("SkillIn.Entities.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerID")
                        .IsRequired();

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("SkillIn.Entities.Student", b =>
                {
                    b.HasOne("SkillIn.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .IsRequired();

                    b.HasOne("SkillIn.Entities.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyID")
                        .IsRequired();

                    b.HasOne("SkillIn.Entities.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityID")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Faculty");

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("SkillIn.Entities.Chat", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("SkillIn.Entities.Course", b =>
                {
                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("SkillIn.Entities.HardSkill", b =>
                {
                    b.Navigation("StudentHardSkills");
                });

            modelBuilder.Entity("SkillIn.Entities.SoftSkill", b =>
                {
                    b.Navigation("StudentSoftSkills");
                });

            modelBuilder.Entity("SkillIn.Entities.User", b =>
                {
                    b.Navigation("Password");
                });

            modelBuilder.Entity("SkillIn.Entities.Student", b =>
                {
                    b.Navigation("Project");

                    b.Navigation("StudentHardSkills");

                    b.Navigation("StudentSoftSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
