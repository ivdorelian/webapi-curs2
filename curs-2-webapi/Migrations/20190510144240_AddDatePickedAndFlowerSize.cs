using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace curs_2_webapi.Migrations
{
    public partial class AddDatePickedAndFlowerSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePicked",
                table: "Flowers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FlowerSize",
                table: "Flowers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePicked",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "FlowerSize",
                table: "Flowers");
        }
    }
}
