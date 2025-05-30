using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jordana.Migrations
{
    public partial class MySQLInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tourists_Sites",
                columns: table => new
                {
                    Site_ID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(now())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true, defaultValueSql: "('System')"),
                    UpdatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    Site_Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Site_Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    City = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Region = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Site_Location = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Lat = table.Column<double>(type: "double", nullable: false),
                    Long = table.Column<double>(type: "double", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Entry_Fee = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Opening_Hours = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Site_ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(now())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true, defaultValueSql: "('System')"),
                    UpdatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    Username = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    User_Type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ProfileImage = table.Column<string>(type: "longtext", unicode: false, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Site_Media",
                columns: table => new
                {
                    Media_ID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(now())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true, defaultValueSql: "('System')"),
                    UpdatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    Site_ID = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "longtext", unicode: false, nullable: false),
                    URL = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Media_ID);
                    table.ForeignKey(
                        name: "FK_SM",
                        column: x => x.Site_ID,
                        principalTable: "Tourists_Sites",
                        principalColumn: "Site_ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Booking_ID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(now())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true, defaultValueSql: "('System')"),
                    UpdatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Site_ID = table.Column<int>(type: "int", nullable: false),
                    Booking_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Booking_Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Booking_EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Transportation = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Booking_ID);
                    table.ForeignKey(
                        name: "FK_SiteBook",
                        column: x => x.Site_ID,
                        principalTable: "Tourists_Sites",
                        principalColumn: "Site_ID");
                    table.ForeignKey(
                        name: "FK_UserBook",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Review_ID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(now())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true, defaultValueSql: "('System')"),
                    UpdatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Site_ID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    Comment = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Review_Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Review_ID);
                    table.ForeignKey(
                        name: "FK_Site",
                        column: x => x.Site_ID,
                        principalTable: "Tourists_Sites",
                        principalColumn: "Site_ID");
                    table.ForeignKey(
                        name: "FK_User",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User_Favorite",
                columns: table => new
                {
                    Fav_ID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(now())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true, defaultValueSql: "('System')"),
                    UpdatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Site_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fav", x => x.Fav_ID);
                    table.ForeignKey(
                        name: "FK_SF",
                        column: x => x.Site_ID,
                        principalTable: "Tourists_Sites",
                        principalColumn: "Site_ID");
                    table.ForeignKey(
                        name: "FK_UF",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Booking_Members",
                columns: table => new
                {
                    Mem_ID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(now())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true, defaultValueSql: "('System')"),
                    UpdatedBy = table.Column<string>(type: "longtext", unicode: false, nullable: true),
                    Booking_ID = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", unicode: false, nullable: false),
                    Gender = table.Column<string>(type: "longtext", unicode: false, nullable: false),
                    NationalID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PassportNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ReferencePhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem", x => x.Mem_ID);
                    table.ForeignKey(
                        name: "FK_BI",
                        column: x => x.Booking_ID,
                        principalTable: "Bookings",
                        principalColumn: "Booking_ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Members_Booking_ID",
                table: "Booking_Members",
                column: "Booking_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Site_ID",
                table: "Bookings",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_User_ID",
                table: "Bookings",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Site_ID",
                table: "Reviews",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_User_ID",
                table: "Reviews",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Site_Media_Site_ID",
                table: "Site_Media",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "UK_Name",
                table: "Tourists_Sites",
                column: "Site_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Favorite_Site_ID",
                table: "User_Favorite",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Favorite_User_ID",
                table: "User_Favorite",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "UK_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Members");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Site_Media");

            migrationBuilder.DropTable(
                name: "User_Favorite");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Tourists_Sites");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
