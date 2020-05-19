using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _19mai_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Role_RoleID",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "User",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleID",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Role",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Admin",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_RoleID",
                table: "Admin",
                newName: "IX_Admin_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Role_RoleId",
                table: "Admin",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Role_RoleId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "User",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "User",
                newName: "IX_User_RoleID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Role",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Admin",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_RoleId",
                table: "Admin",
                newName: "IX_Admin_RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Role_RoleID",
                table: "Admin",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
