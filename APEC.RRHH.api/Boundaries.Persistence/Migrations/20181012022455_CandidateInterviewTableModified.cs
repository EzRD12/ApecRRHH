using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundaries.Persistence.Migrations
{
    public partial class CandidateInterviewTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateInterview",
                table: "CandidateInterview");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateInterviewId",
                table: "CandidateInterview",
                nullable: false,
                defaultValueSql: "newsequentialid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateInterview",
                table: "CandidateInterview",
                column: "CandidateInterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateInterview_CandidateEmployeeId",
                table: "CandidateInterview",
                column: "CandidateEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateInterview",
                table: "CandidateInterview");

            migrationBuilder.DropIndex(
                name: "IX_CandidateInterview_CandidateEmployeeId",
                table: "CandidateInterview");

            migrationBuilder.DropColumn(
                name: "CandidateInterviewId",
                table: "CandidateInterview");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateInterview",
                table: "CandidateInterview",
                columns: new[] { "CandidateEmployeeId", "JobId" });
        }
    }
}
