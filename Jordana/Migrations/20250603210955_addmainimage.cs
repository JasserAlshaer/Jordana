using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jordana.Migrations
{
    public partial class addmainimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Tourists_Sites",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Tourists_Sites");
        }
    }
}
