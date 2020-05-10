using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _10_may1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_User_IDID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_User_IDID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "User_IDID",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserID",
                table: "Project",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_UserID",
                table: "Project",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_UserID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_UserID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "User_IDID",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_User_IDID",
                table: "Project",
                column: "User_IDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_User_IDID",
                table: "Project",
                column: "User_IDID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
