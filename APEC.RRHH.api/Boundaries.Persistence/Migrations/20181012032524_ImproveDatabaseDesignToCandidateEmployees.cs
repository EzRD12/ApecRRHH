using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundaries.Persistence.Migrations
{
    public partial class ImproveDatabaseDesignToCandidateEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CandidateInterviewId",
                table: "CandidateInterview",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateEmployeeAspiratedJobCandidateEmployeeId",
                table: "CandidateInterview",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateEmployeeAspiratedJobId",
                table: "CandidateInterview",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateEmployeeAspiratedJobJobId",
                table: "CandidateInterview",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CandidateEmployeeAspiratedJobs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CandidateInterview_CandidateEmployeeAspiratedJobCandidateEmployeeId_CandidateEmployeeAspiratedJobJobId",
                table: "CandidateInterview",
                columns: new[] { "CandidateEmployeeAspiratedJobCandidateEmployeeId", "CandidateEmployeeAspiratedJobJobId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateInterview_CandidateEmployeeAspiratedJobs_CandidateEmployeeAspiratedJobCandidateEmployeeId_CandidateEmployeeAspirate~",
                table: "CandidateInterview",
                columns: new[] { "CandidateEmployeeAspiratedJobCandidateEmployeeId", "CandidateEmployeeAspiratedJobJobId" },
                principalTable: "CandidateEmployeeAspiratedJobs",
                principalColumns: new[] { "CandidateEmployeeId", "JobId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateInterview_CandidateEmployeeAspiratedJobs_CandidateEmployeeAspiratedJobCandidateEmployeeId_CandidateEmployeeAspirate~",
                table: "CandidateInterview");

            migrationBuilder.DropIndex(
                name: "IX_CandidateInterview_CandidateEmployeeAspiratedJobCandidateEmployeeId_CandidateEmployeeAspiratedJobJobId",
                table: "CandidateInterview");

            migrationBuilder.DropColumn(
                name: "CandidateEmployeeAspiratedJobCandidateEmployeeId",
                table: "CandidateInterview");

            migrationBuilder.DropColumn(
                name: "CandidateEmployeeAspiratedJobId",
                table: "CandidateInterview");

            migrationBuilder.DropColumn(
                name: "CandidateEmployeeAspiratedJobJobId",
                table: "CandidateInterview");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CandidateEmployeeAspiratedJobs");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CandidateInterview",
                newName: "CandidateInterviewId");
        }
    }
}
