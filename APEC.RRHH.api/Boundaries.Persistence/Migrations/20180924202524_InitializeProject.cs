using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundaries.Persistence.Migrations
{
    public partial class InitializeProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competence_Job_JobId",
                table: "Competence");

            migrationBuilder.DropForeignKey(
                name: "FK_Language_Job_JobId",
                table: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Language_JobId",
                table: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Competence_JobId",
                table: "Competence");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Competence");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "varchar(400)",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Users",
                type: "varchar(400)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Language",
                type: "varchar(400)",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Language",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Job",
                type: "varchar(400)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Job",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departament",
                type: "varchar(400)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Departament",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Competence",
                type: "varchar(400)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Competence",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.CreateTable(
                name: "CandidateEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(nullable: false),
                    JobToAspire = table.Column<Guid>(nullable: false),
                    JobId = table.Column<Guid>(nullable: true),
                    SalaryToAspire = table.Column<int>(nullable: false),
                    UserIdWhoRecommendedIt = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateEmployee_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateEmployee_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCompetence",
                columns: table => new
                {
                    JobId = table.Column<Guid>(nullable: false),
                    CompetenceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCompetence", x => new { x.JobId, x.CompetenceId });
                    table.ForeignKey(
                        name: "FK_JobCompetence_Competence_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCompetence_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobLanguage",
                columns: table => new
                {
                    JobId = table.Column<Guid>(nullable: false),
                    LanguageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLanguage", x => new { x.JobId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_JobLanguage_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preparation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(400)", maxLength: 700, nullable: false),
                    AcademicLevel = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateUp = table.Column<DateTime>(nullable: false),
                    Institution = table.Column<string>(type: "varchar(400)", maxLength: 700, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preparation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCompetence",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CompetenceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompetence", x => new { x.UserId, x.CompetenceId });
                    table.ForeignKey(
                        name: "FK_UserCompetence_Competence_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompetence_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LanguageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguage", x => new { x.UserId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_UserLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguage_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(nullable: false),
                    PositionHeld = table.Column<string>(type: "varchar(400)", maxLength: 700, nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateUp = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    CurrencyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperience_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEmployee_JobId",
                table: "CandidateEmployee",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEmployee_UserId",
                table: "CandidateEmployee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCompetence_CompetenceId",
                table: "JobCompetence",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_JobLanguage_LanguageId",
                table: "JobLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Preparation_UserId",
                table: "Preparation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompetence_CompetenceId",
                table: "UserCompetence",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_LanguageId",
                table: "UserLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_UserId",
                table: "WorkExperience",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateEmployee");

            migrationBuilder.DropTable(
                name: "JobCompetence");

            migrationBuilder.DropTable(
                name: "JobLanguage");

            migrationBuilder.DropTable(
                name: "Preparation");

            migrationBuilder.DropTable(
                name: "UserCompetence");

            migrationBuilder.DropTable(
                name: "UserLanguage");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "varchar(400)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 700);

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Users",
                type: "varchar(400)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Language",
                type: "varchar(400)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 700);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Language",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "Language",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Job",
                type: "varchar(400)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Job",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departament",
                type: "varchar(400)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Departament",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Competence",
                type: "varchar(400)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Competence",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "Competence",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Language_JobId",
                table: "Language",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_JobId",
                table: "Competence",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competence_Job_JobId",
                table: "Competence",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Language_Job_JobId",
                table: "Language",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
