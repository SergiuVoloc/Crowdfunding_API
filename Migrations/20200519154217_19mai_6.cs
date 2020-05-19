using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _19mai_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role_Id",
                table: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role_Id",
                table: "Admin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
