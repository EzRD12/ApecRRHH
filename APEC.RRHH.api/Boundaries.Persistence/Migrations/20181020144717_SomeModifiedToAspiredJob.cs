using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundaries.Persistence.Migrations
{
    public partial class SomeModifiedToAspiredJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CandidateEmployeeAspiratedJobs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CandidateEmployeeAspiratedJobs");
        }
    }
}
