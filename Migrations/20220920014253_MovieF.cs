using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class MovieF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Movies_MovieId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_UserName",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Users_UserName",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserName",
                table: "Tickets",
                newName: "IX_Tickets_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserName",
                table: "Comments",
                newName: "IX_Comments_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_MovieId",
                table: "Comments",
                newName: "IX_Comments_MovieId");

            migrationBuilder.AddColumn<string>(
                name: "BoxOffice",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "CoverImg",
                table: "Movies",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Preview",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTemplates",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    PosState = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTemplates", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BasePrice = table.Column<double>(type: "REAL", nullable: false),
                    MovieId = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    PosState = table.Column<string>(type: "TEXT", nullable: false),
                    RoomName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePerson",
                columns: table => new
                {
                    MoviesId = table.Column<string>(type: "TEXT", nullable: false),
                    PersonsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePerson", x => new { x.MoviesId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_MoviePerson_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePerson_People_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePerson_PersonsId",
                table: "MoviePerson",
                column: "PersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserName",
                table: "Comments",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserName",
                table: "Tickets",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserName",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserName",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "MoviePerson");

            migrationBuilder.DropTable(
                name: "RoomTemplates");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BoxOffice",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CoverImg",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Preview",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserName",
                table: "Ticket",
                newName: "IX_Ticket_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserName",
                table: "Comment",
                newName: "IX_Comment_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieId",
                table: "Comment",
                newName: "IX_Comment_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Movies_MovieId",
                table: "Comment",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_UserName",
                table: "Comment",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Users_UserName",
                table: "Ticket",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name");
        }
    }
}
