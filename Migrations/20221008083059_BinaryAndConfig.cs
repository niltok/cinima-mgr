using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class BinaryAndConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Binaries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Binaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Key);
                });

            migrationBuilder.Sql(@"INSERT INTO Binaries SELECT Id, CoverImg FROM Movies");

            migrationBuilder.DropColumn(
                name: "CoverImg",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "CoverId",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"UPDATE Movies SET CoverId=Movies.Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CoverId",
                table: "Movies",
                column: "CoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Binaries_CoverId",
                table: "Movies",
                column: "CoverId",
                principalTable: "Binaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Binaries_CoverId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CoverId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "Movies");

            migrationBuilder.AddColumn<byte[]>(
                name: "CoverImg",
                table: "Movies",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
            
            migrationBuilder.DropTable(
                name: "Binaries");

            migrationBuilder.DropTable(
                name: "Configs");

        }
    }
}
