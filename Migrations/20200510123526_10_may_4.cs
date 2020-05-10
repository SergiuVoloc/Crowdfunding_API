using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _10_may_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Project_Project_idID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_User_User_idID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_Project_idID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_User_idID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Project_idID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "User_idID",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Payment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ProjectID",
                table: "Payment",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserID",
                table: "Payment",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Project_ProjectID",
                table: "Payment",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_User_UserID",
                table: "Payment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Project_ProjectID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_User_UserID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ProjectID",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_UserID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "Project_idID",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_idID",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Project_idID",
                table: "Payment",
                column: "Project_idID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_User_idID",
                table: "Payment",
                column: "User_idID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Project_Project_idID",
                table: "Payment",
                column: "Project_idID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_User_User_idID",
                table: "Payment",
                column: "User_idID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
