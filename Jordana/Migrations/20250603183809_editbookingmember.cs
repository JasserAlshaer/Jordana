using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jordana.Migrations
{
    public partial class editbookingmember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceName",
                table: "Booking_Members",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Relationship",
                table: "Booking_Members",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceName",
                table: "Booking_Members");

            migrationBuilder.DropColumn(
                name: "Relationship",
                table: "Booking_Members");
        }
    }
}
