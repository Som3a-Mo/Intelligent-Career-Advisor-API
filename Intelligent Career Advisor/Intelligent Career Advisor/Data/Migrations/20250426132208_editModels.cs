using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent_Career_Advisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class editModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proficiency",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "Companies",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "GitHubUrl",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "JobTitles",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ResumeFilePath",
                table: "UserProfile",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "PersonalWebsiteUrl",
                table: "UserProfile",
                newName: "Company");

            migrationBuilder.AddColumn<string>(
                name: "ResumeFileUrl",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumeFileUrl",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "UserProfile",
                newName: "ResumeFilePath");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "UserProfile",
                newName: "PersonalWebsiteUrl");

            migrationBuilder.AddColumn<string>(
                name: "Proficiency",
                table: "UserSkill",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Companies",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GitHubUrl",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitles",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
