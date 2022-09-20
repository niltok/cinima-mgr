using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class UserS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Sessions",
                newName: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserName",
                table: "Sessions",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserName",
                table: "Sessions",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_UserName",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_UserName",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Sessions",
                newName: "User");
        }
    }
}
