using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class UpdateRoomNameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_RoomTemplates_RoomName",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_RoomName",
                table: "Shows");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shows_RoomName",
                table: "Shows",
                column: "RoomName");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_RoomTemplates_RoomName",
                table: "Shows",
                column: "RoomName",
                principalTable: "RoomTemplates",
                principalColumn: "Name");
        }
    }
}
