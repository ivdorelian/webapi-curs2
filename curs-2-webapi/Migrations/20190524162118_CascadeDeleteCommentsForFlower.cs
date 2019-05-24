using Microsoft.EntityFrameworkCore.Migrations;

namespace curs_2_webapi.Migrations
{
    public partial class CascadeDeleteCommentsForFlower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Flowers_FlowerId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Flowers_FlowerId",
                table: "Comments",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Flowers_FlowerId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Flowers_FlowerId",
                table: "Comments",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
