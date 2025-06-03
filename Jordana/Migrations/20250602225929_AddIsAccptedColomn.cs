using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jordana.Migrations
{
    public partial class AddIsAccptedColomn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Reviews",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Reviews");
        }
    }
}
