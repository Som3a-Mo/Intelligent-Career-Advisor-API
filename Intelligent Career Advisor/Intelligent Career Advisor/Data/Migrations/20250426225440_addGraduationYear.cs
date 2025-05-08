using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent_Career_Advisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class addGraduationYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearsOfExperience",
                table: "UserProfile",
                newName: "GraduationYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GraduationYear",
                table: "UserProfile",
                newName: "YearsOfExperience");
        }
    }
}
