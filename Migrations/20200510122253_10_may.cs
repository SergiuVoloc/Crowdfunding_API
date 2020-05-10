using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _10_may : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Role",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "User_IDID",
                table: "Project",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Project",
                type: "int",
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
    }
}
