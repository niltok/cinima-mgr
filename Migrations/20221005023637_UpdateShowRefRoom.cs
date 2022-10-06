using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class UpdateShowRefRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "RoomTemplateName",
                table: "Shows");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_RoomId",
                table: "Shows",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_RoomTemplates_RoomId",
                table: "Shows",
                column: "RoomId",
                principalTable: "RoomTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_RoomTemplates_RoomId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_RoomId",
                table: "Shows");

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Shows",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomTemplateName",
                table: "Shows",
                type: "TEXT",
                nullable: true);

        }
    }
}
