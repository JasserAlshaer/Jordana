using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jordana.Migrations
{
    public partial class editbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccpted",
                table: "Bookings",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccpted",
                table: "Bookings");
        }
    }
}
