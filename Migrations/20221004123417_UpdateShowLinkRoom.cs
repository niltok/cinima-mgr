using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class UpdateShowLinkRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Shows");

            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "Shows",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_RoomTemplates_RoomName",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_RoomName",
                table: "Shows");

            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "Shows",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Shows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Shows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
