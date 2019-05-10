using Microsoft.EntityFrameworkCore.Migrations;

namespace curs_2_webapi.Migrations
{
    public partial class AddCommentsForFlower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlowerId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FlowerId",
                table: "Comments",
                column: "FlowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Flowers_FlowerId",
                table: "Comments",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Flowers_FlowerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_FlowerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FlowerId",
                table: "Comments");
        }
    }
}
