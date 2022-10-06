using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinima_mgr.Migrations
{
    public partial class EntityStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Shows_ShowId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Order_OrderId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_RoomTemplates_Name",
                table: "RoomTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShowId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ShowId",
                table: "Order",
                newName: "RefundTime");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Tickets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "ShowId",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanBuyAfter",
                table: "Shows",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Shows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Sessions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "RoomTemplates",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RoomTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelTime",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Order",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayTime",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Order",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireTime",
                table: "DiscountTickets",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowId",
                table: "Tickets",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Order_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Shows_ShowId",
                table: "Tickets",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Order_OrderId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Shows_ShowId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ShowId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CanBuyAfter",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "RoomTemplates");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RoomTemplates");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CancelTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PayTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ExpireTime",
                table: "DiscountTickets");

            migrationBuilder.RenameColumn(
                name: "RefundTime",
                table: "Order",
                newName: "ShowId");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Tickets",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomTemplates_Name",
                table: "RoomTemplates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShowId",
                table: "Order",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Shows_ShowId",
                table: "Order",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Order_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
