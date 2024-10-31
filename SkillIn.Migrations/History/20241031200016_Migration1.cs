using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIn.Migrations.History
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ent");

            migrationBuilder.CreateTable(
                name: "Chats",
                schema: "ent",
                columns: table => new
                {
                    ChatID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FacultyName = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardSkills",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftSkills",
                schema: "ent",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftSkills", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisciplineName = table.Column<int>(type: "integer", nullable: false),
                    CourseID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Courses_CourseID",
                        column: x => x.CourseID,
                        principalSchema: "ent",
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecialityName = table.Column<int>(type: "integer", nullable: false),
                    FacultyID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalSchema: "ent",
                        principalTable: "Faculties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    ChatID = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CompanyInfo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    FirstName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    MiddleName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    LastName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    CourseID = table.Column<Guid>(type: "uuid", nullable: true),
                    FacultyID = table.Column<Guid>(type: "uuid", nullable: true),
                    SpecialityID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Chats_ChatID",
                        column: x => x.ChatID,
                        principalSchema: "ent",
                        principalTable: "Chats",
                        principalColumn: "ChatID");
                    table.ForeignKey(
                        name: "FK_Users_Courses_CourseID",
                        column: x => x.CourseID,
                        principalSchema: "ent",
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalSchema: "ent",
                        principalTable: "Faculties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Specializations_SpecialityID",
                        column: x => x.SpecialityID,
                        principalSchema: "ent",
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteUserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_FavoriteUserID",
                        column: x => x.FavoriteUserID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentID = table.Column<Guid>(type: "uuid", nullable: false),
                    DisciplineID = table.Column<Guid>(type: "uuid", nullable: false),
                    GradeName = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Disciplines_DisciplineID",
                        column: x => x.DisciplineID,
                        principalSchema: "ent",
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentID",
                        column: x => x.StudentID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "ent",
                columns: table => new
                {
                    MessageID = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatID = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverID = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatID",
                        column: x => x.ChatID,
                        principalSchema: "ent",
                        principalTable: "Chats",
                        principalColumn: "ChatID");
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverID",
                        column: x => x.ReceiverID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderID",
                        column: x => x.SenderID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Olympiads",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OlympiadName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StudentID = table.Column<Guid>(type: "uuid", nullable: false),
                    OlympiadResult = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olympiads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Olympiads_Users_StudentID",
                        column: x => x.StudentID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectTitle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProjectDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_StudentID",
                        column: x => x.StudentID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentHardSkills",
                schema: "ent",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    HardSkillId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHardSkills", x => new { x.StudentId, x.HardSkillId });
                    table.ForeignKey(
                        name: "FK_StudentHardSkills_HardSkills_HardSkillId",
                        column: x => x.HardSkillId,
                        principalSchema: "ent",
                        principalTable: "HardSkills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentHardSkills_Users_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentSoftSkills",
                schema: "ent",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftSkillId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSoftSkills", x => new { x.StudentId, x.SoftSkillId });
                    table.ForeignKey(
                        name: "FK_StudentSoftSkills_SoftSkills_SoftSkillId",
                        column: x => x.SoftSkillId,
                        principalSchema: "ent",
                        principalTable: "SoftSkills",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StudentSoftSkills_Users_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPasswords",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPasswords_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                schema: "ent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerID = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Requirements = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Users_EmployerID",
                        column: x => x.EmployerID,
                        principalSchema: "ent",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_CourseID",
                schema: "ent",
                table: "Disciplines",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_FavoriteUserID",
                schema: "ent",
                table: "Favorites",
                column: "FavoriteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserID",
                schema: "ent",
                table: "Favorites",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_DisciplineID",
                schema: "ent",
                table: "Grades",
                column: "DisciplineID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                schema: "ent",
                table: "Grades",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatID",
                schema: "ent",
                table: "Messages",
                column: "ChatID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverID",
                schema: "ent",
                table: "Messages",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderID",
                schema: "ent",
                table: "Messages",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Olympiads_StudentID",
                schema: "ent",
                table: "Olympiads",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                schema: "ent",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudentID",
                schema: "ent",
                table: "Projects",
                column: "StudentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_FacultyID",
                schema: "ent",
                table: "Specializations",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHardSkills_HardSkillId",
                schema: "ent",
                table: "StudentHardSkills",
                column: "HardSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSoftSkills_SoftSkillId",
                schema: "ent",
                table: "StudentSoftSkills",
                column: "SoftSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPasswords_UserId",
                schema: "ent",
                table: "UserPasswords",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChatID",
                schema: "ent",
                table: "Users",
                column: "ChatID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CourseID",
                schema: "ent",
                table: "Users",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacultyID",
                schema: "ent",
                table: "Users",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecialityID",
                schema: "ent",
                table: "Users",
                column: "SpecialityID");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_EmployerID",
                schema: "ent",
                table: "Vacancies",
                column: "EmployerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Grades",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Olympiads",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "StudentHardSkills",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "StudentSoftSkills",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "UserPasswords",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Vacancies",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Disciplines",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "HardSkills",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "SoftSkills",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Chats",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Specializations",
                schema: "ent");

            migrationBuilder.DropTable(
                name: "Faculties",
                schema: "ent");
        }
    }
}
