using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class UpdateRoomKeyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTemplates",
                table: "RoomTemplates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTemplates",
                table: "RoomTemplates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTemplates_Name",
                table: "RoomTemplates",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTemplates",
                table: "RoomTemplates");

            migrationBuilder.DropIndex(
                name: "IX_RoomTemplates_Name",
                table: "RoomTemplates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTemplates",
                table: "RoomTemplates",
                column: "Name");
        }
    }
}
