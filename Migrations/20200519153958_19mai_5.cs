using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _19mai_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role_Id",
                table: "Admin",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role_Id",
                table: "Admin");
        }
    }
}
