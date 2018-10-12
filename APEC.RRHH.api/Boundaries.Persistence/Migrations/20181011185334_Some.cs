using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundaries.Persistence.Migrations
{
    public partial class Some : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CandidateEmployees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CandidateInterview",
                columns: table => new
                {
                    CandidateEmployeeId = table.Column<Guid>(nullable: false),
                    JobId = table.Column<Guid>(nullable: false),
                    InterviewDate = table.Column<DateTime>(nullable: false),
                    EmployeeIdWhoInterviewed = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    EmployeeNotes = table.Column<string>(type: "varchar(400)", nullable: true),
                    Hired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateInterview", x => new { x.CandidateEmployeeId, x.JobId });
                    table.ForeignKey(
                        name: "FK_CandidateInterview_CandidateEmployees_CandidateEmployeeId",
                        column: x => x.CandidateEmployeeId,
                        principalTable: "CandidateEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateInterview_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateInterview_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateInterview_EmployeeId",
                table: "CandidateInterview",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateInterview_JobId",
                table: "CandidateInterview",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateInterview");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CandidateEmployees");
        }
    }
}
