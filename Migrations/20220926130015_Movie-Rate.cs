using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class MovieRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserName",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserName",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.AddColumn<int>(
                name: "RateCount",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "RateSum",
                table: "Movies",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditTime",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EditTime_UserId",
                table: "Comments",
                columns: new[] { "EditTime", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EditTime_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RateCount",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RateSum",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "EditTime",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserName",
                table: "Comments",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
