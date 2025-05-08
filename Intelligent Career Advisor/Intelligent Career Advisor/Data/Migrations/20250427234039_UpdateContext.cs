using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intelligent_Career_Advisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_AspNetUsers_ApplicationUserId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplicationReminder_JobApplication_JobApplicationId",
                table: "JobApplicationReminder");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_AspNetUsers_ApplicationUserId",
                table: "UserSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkill",
                table: "UserSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication");

            migrationBuilder.RenameTable(
                name: "UserSkill",
                newName: "UserSkills");

            migrationBuilder.RenameTable(
                name: "JobApplication",
                newName: "JobApplications");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkill_ApplicationUserId",
                table: "UserSkills",
                newName: "IX_UserSkills_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_ApplicationUserId",
                table: "JobApplications",
                newName: "IX_JobApplications_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkills",
                table: "UserSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplicationReminder_JobApplications_JobApplicationId",
                table: "JobApplicationReminder",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_AspNetUsers_ApplicationUserId",
                table: "JobApplications",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_AspNetUsers_ApplicationUserId",
                table: "UserSkills",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplicationReminder_JobApplications_JobApplicationId",
                table: "JobApplicationReminder");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_AspNetUsers_ApplicationUserId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_AspNetUsers_ApplicationUserId",
                table: "UserSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkills",
                table: "UserSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.RenameTable(
                name: "UserSkills",
                newName: "UserSkill");

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "JobApplication");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_ApplicationUserId",
                table: "UserSkill",
                newName: "IX_UserSkill_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_ApplicationUserId",
                table: "JobApplication",
                newName: "IX_JobApplication_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkill",
                table: "UserSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_AspNetUsers_ApplicationUserId",
                table: "JobApplication",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplicationReminder_JobApplication_JobApplicationId",
                table: "JobApplicationReminder",
                column: "JobApplicationId",
                principalTable: "JobApplication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_AspNetUsers_ApplicationUserId",
                table: "UserSkill",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
