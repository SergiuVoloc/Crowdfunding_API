using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _19mai_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Project_Project_IDID",
                table: "File");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Project_ProjectID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_User_UserID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_UserID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_File_Project_IDID",
                table: "File");

            migrationBuilder.DropColumn(
                name: "Project_IDID",
                table: "File");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Project",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Project",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Project_UserID",
                table: "Project",
                newName: "IX_Project_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Payment",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Payment",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Payment",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_UserID",
                table: "Payment",
                newName: "IX_Payment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_ProjectID",
                table: "Payment",
                newName: "IX_Payment_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "File",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "File",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_ProjectId",
                table: "File",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Project_ProjectId",
                table: "File",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Project_ProjectId",
                table: "Payment",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_User_UserId",
                table: "Payment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_UserId",
                table: "Project",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Project_ProjectId",
                table: "File");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Project_ProjectId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_User_UserId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_UserId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_File_ProjectId",
                table: "File");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "File");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Project",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Project",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Project_UserId",
                table: "Project",
                newName: "IX_Project_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Payment",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Payment",
                newName: "ProjectID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_UserId",
                table: "Payment",
                newName: "IX_Payment_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_ProjectId",
                table: "Payment",
                newName: "IX_Payment_ProjectID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "File",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "Project_IDID",
                table: "File",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_Project_IDID",
                table: "File",
                column: "Project_IDID");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Project_Project_IDID",
                table: "File",
                column: "Project_IDID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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
