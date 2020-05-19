using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _19mai_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Role_Role_IDID",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_Role_IDID",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Role_IDID",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Admin",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Admin",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_RoleID",
                table: "Admin",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Role_RoleID",
                table: "Admin",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Role_RoleID",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_RoleID",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "Role_IDID",
                table: "Admin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Role_IDID",
                table: "Admin",
                column: "Role_IDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Role_Role_IDID",
                table: "Admin",
                column: "Role_IDID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
