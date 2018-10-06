using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundaries.Persistence.Migrations
{
    public partial class AddedCandidateEmployeeAspiratedJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateEmployee_Job_JobId",
                table: "CandidateEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateEmployee_Users_UserId",
                table: "CandidateEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Job_JobId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Departament_DepartamentId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCompetence_Competence_CompetenceId",
                table: "JobCompetence");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCompetence_Job_JobId",
                table: "JobCompetence");

            migrationBuilder.DropForeignKey(
                name: "FK_JobLanguage_Job_JobId",
                table: "JobLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_JobLanguage_Language_LanguageId",
                table: "JobLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_Preparation_Users_UserId",
                table: "Preparation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompetence_Competence_CompetenceId",
                table: "UserCompetence");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompetence_Users_UserId",
                table: "UserCompetence");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguage_Language_LanguageId",
                table: "UserLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguage_Users_UserId",
                table: "UserLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Users_UserId",
                table: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperience",
                table: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLanguage",
                table: "UserLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompetence",
                table: "UserCompetence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preparation",
                table: "Preparation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobLanguage",
                table: "JobLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCompetence",
                table: "JobCompetence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departament",
                table: "Departament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competence",
                table: "Competence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateEmployee",
                table: "CandidateEmployee");

            migrationBuilder.DropIndex(
                name: "IX_CandidateEmployee_JobId",
                table: "CandidateEmployee");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "CandidateEmployee");

            migrationBuilder.DropColumn(
                name: "JobToAspire",
                table: "CandidateEmployee");

            migrationBuilder.DropColumn(
                name: "SalaryToAspire",
                table: "CandidateEmployee");

            migrationBuilder.DropColumn(
                name: "UserIdWhoRecommendedIt",
                table: "CandidateEmployee");

            migrationBuilder.RenameTable(
                name: "WorkExperience",
                newName: "WorkExperiences");

            migrationBuilder.RenameTable(
                name: "UserLanguage",
                newName: "UserLanguages");

            migrationBuilder.RenameTable(
                name: "UserCompetence",
                newName: "UserCompetences");

            migrationBuilder.RenameTable(
                name: "Preparation",
                newName: "Preparations");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "JobLanguage",
                newName: "JobLanguages");

            migrationBuilder.RenameTable(
                name: "JobCompetence",
                newName: "JobCompetences");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Departament",
                newName: "Departaments");

            migrationBuilder.RenameTable(
                name: "Competence",
                newName: "Competences");

            migrationBuilder.RenameTable(
                name: "CandidateEmployee",
                newName: "CandidateEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperience_UserId",
                table: "WorkExperiences",
                newName: "IX_WorkExperiences_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLanguage_LanguageId",
                table: "UserLanguages",
                newName: "IX_UserLanguages_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompetence_CompetenceId",
                table: "UserCompetences",
                newName: "IX_UserCompetences_CompetenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Preparation_UserId",
                table: "Preparations",
                newName: "IX_Preparations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobLanguage_LanguageId",
                table: "JobLanguages",
                newName: "IX_JobLanguages_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCompetence_CompetenceId",
                table: "JobCompetences",
                newName: "IX_JobCompetences_CompetenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_DepartamentId",
                table: "Jobs",
                newName: "IX_Jobs_DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateEmployee_UserId",
                table: "CandidateEmployees",
                newName: "IX_CandidateEmployees_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLanguages",
                table: "UserLanguages",
                columns: new[] { "UserId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompetences",
                table: "UserCompetences",
                columns: new[] { "UserId", "CompetenceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preparations",
                table: "Preparations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobLanguages",
                table: "JobLanguages",
                columns: new[] { "JobId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCompetences",
                table: "JobCompetences",
                columns: new[] { "JobId", "CompetenceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departaments",
                table: "Departaments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competences",
                table: "Competences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateEmployees",
                table: "CandidateEmployees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CandidateEmployeeAspiratedJobs",
                columns: table => new
                {
                    CandidateEmployeeId = table.Column<Guid>(nullable: false),
                    JobId = table.Column<Guid>(nullable: false),
                    SalaryToAspire = table.Column<int>(nullable: false),
                    UserIdWhoRecommendedIt = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateEmployeeAspiratedJobs", x => new { x.CandidateEmployeeId, x.JobId });
                    table.ForeignKey(
                        name: "FK_CandidateEmployeeAspiratedJobs_CandidateEmployees_CandidateEmployeeId",
                        column: x => x.CandidateEmployeeId,
                        principalTable: "CandidateEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateEmployeeAspiratedJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEmployeeAspiratedJobs_JobId",
                table: "CandidateEmployeeAspiratedJobs",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateEmployees_Users_UserId",
                table: "CandidateEmployees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Jobs_JobId",
                table: "Employees",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCompetences_Competences_CompetenceId",
                table: "JobCompetences",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCompetences_Jobs_JobId",
                table: "JobCompetences",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobLanguages_Jobs_JobId",
                table: "JobLanguages",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobLanguages_Languages_LanguageId",
                table: "JobLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Departaments_DepartamentId",
                table: "Jobs",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Preparations_Users_UserId",
                table: "Preparations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompetences_Competences_CompetenceId",
                table: "UserCompetences",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompetences_Users_UserId",
                table: "UserCompetences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_Languages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_Users_UserId",
                table: "UserLanguages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Users_UserId",
                table: "WorkExperiences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateEmployees_Users_UserId",
                table: "CandidateEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Jobs_JobId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCompetences_Competences_CompetenceId",
                table: "JobCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCompetences_Jobs_JobId",
                table: "JobCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobLanguages_Jobs_JobId",
                table: "JobLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_JobLanguages_Languages_LanguageId",
                table: "JobLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Departaments_DepartamentId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Preparations_Users_UserId",
                table: "Preparations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompetences_Competences_CompetenceId",
                table: "UserCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompetences_Users_UserId",
                table: "UserCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_Languages_LanguageId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_Users_UserId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Users_UserId",
                table: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "CandidateEmployeeAspiratedJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLanguages",
                table: "UserLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompetences",
                table: "UserCompetences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preparations",
                table: "Preparations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobLanguages",
                table: "JobLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCompetences",
                table: "JobCompetences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departaments",
                table: "Departaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competences",
                table: "Competences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateEmployees",
                table: "CandidateEmployees");

            migrationBuilder.RenameTable(
                name: "WorkExperiences",
                newName: "WorkExperience");

            migrationBuilder.RenameTable(
                name: "UserLanguages",
                newName: "UserLanguage");

            migrationBuilder.RenameTable(
                name: "UserCompetences",
                newName: "UserCompetence");

            migrationBuilder.RenameTable(
                name: "Preparations",
                newName: "Preparation");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "JobLanguages",
                newName: "JobLanguage");

            migrationBuilder.RenameTable(
                name: "JobCompetences",
                newName: "JobCompetence");

            migrationBuilder.RenameTable(
                name: "Departaments",
                newName: "Departament");

            migrationBuilder.RenameTable(
                name: "Competences",
                newName: "Competence");

            migrationBuilder.RenameTable(
                name: "CandidateEmployees",
                newName: "CandidateEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperiences_UserId",
                table: "WorkExperience",
                newName: "IX_WorkExperience_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLanguages_LanguageId",
                table: "UserLanguage",
                newName: "IX_UserLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompetences_CompetenceId",
                table: "UserCompetence",
                newName: "IX_UserCompetence_CompetenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Preparations_UserId",
                table: "Preparation",
                newName: "IX_Preparation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_DepartamentId",
                table: "Job",
                newName: "IX_Job_DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_JobLanguages_LanguageId",
                table: "JobLanguage",
                newName: "IX_JobLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCompetences_CompetenceId",
                table: "JobCompetence",
                newName: "IX_JobCompetence_CompetenceId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateEmployees_UserId",
                table: "CandidateEmployee",
                newName: "IX_CandidateEmployee_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "CandidateEmployee",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobToAspire",
                table: "CandidateEmployee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SalaryToAspire",
                table: "CandidateEmployee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserIdWhoRecommendedIt",
                table: "CandidateEmployee",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperience",
                table: "WorkExperience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLanguage",
                table: "UserLanguage",
                columns: new[] { "UserId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompetence",
                table: "UserCompetence",
                columns: new[] { "UserId", "CompetenceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preparation",
                table: "Preparation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobLanguage",
                table: "JobLanguage",
                columns: new[] { "JobId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCompetence",
                table: "JobCompetence",
                columns: new[] { "JobId", "CompetenceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departament",
                table: "Departament",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competence",
                table: "Competence",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateEmployee",
                table: "CandidateEmployee",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEmployee_JobId",
                table: "CandidateEmployee",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateEmployee_Job_JobId",
                table: "CandidateEmployee",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateEmployee_Users_UserId",
                table: "CandidateEmployee",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Job_JobId",
                table: "Employees",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Departament_DepartamentId",
                table: "Job",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCompetence_Competence_CompetenceId",
                table: "JobCompetence",
                column: "CompetenceId",
                principalTable: "Competence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCompetence_Job_JobId",
                table: "JobCompetence",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobLanguage_Job_JobId",
                table: "JobLanguage",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobLanguage_Language_LanguageId",
                table: "JobLanguage",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Preparation_Users_UserId",
                table: "Preparation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompetence_Competence_CompetenceId",
                table: "UserCompetence",
                column: "CompetenceId",
                principalTable: "Competence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompetence_Users_UserId",
                table: "UserCompetence",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguage_Language_LanguageId",
                table: "UserLanguage",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguage_Users_UserId",
                table: "UserLanguage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Users_UserId",
                table: "WorkExperience",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
