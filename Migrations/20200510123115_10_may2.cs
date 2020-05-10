using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfunding_API.Migrations
{
    public partial class _10_may2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Card_name = table.Column<string>(maxLength: 100, nullable: false),
                    Card_number = table.Column<int>(nullable: false),
                    Month = table.Column<int>(maxLength: 30, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    CVC = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Curency = table.Column<string>(nullable: false),
                    Payment_method = table.Column<int>(nullable: false),
                    User_idID = table.Column<int>(nullable: true),
                    Project_idID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_Project_Project_idID",
                        column: x => x.Project_idID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_User_User_idID",
                        column: x => x.User_idID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Project_idID",
                table: "Payment",
                column: "Project_idID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_User_idID",
                table: "Payment",
                column: "User_idID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
